using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PC_Store.Data;
using PC_Store.Infrastructure;
using PC_Store.Interfaces;
using PC_Store.Models;
using PC_Store.ViewModels;

namespace PC_Store.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ShoppingCart _shoppingCart;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ApplicationDbContext _context;

        public OrderController(IOrderRepository orderRepository, ShoppingCart shoppingCart, UserManager<IdentityUser> userManager, ApplicationDbContext context)
        {
            _orderRepository = orderRepository;
            _shoppingCart = shoppingCart;
            _userManager = userManager;
            _context = context;
        }
        [HttpGet]
        public IActionResult Checkout()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            return View("Checkout");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Checkout(Order order)
        {
            _shoppingCart.ShoppingCartItems = _shoppingCart.GetShoppingCartItems();
            if (ModelState.IsValid)
            {
                if(_shoppingCart.ShoppingCartItems.Count!=0)
                {
                    order.OrderTotal = _shoppingCart.GetShoppingCartTotal();
                    order.User = _userManager.GetUserName(HttpContext.User);
                    order.StatusOrder = "ORDERWASPLACED";
                    _orderRepository.CreateOrder(order);
                    _shoppingCart.ClearCart();
                    return RedirectToAction("CheckoutComplete");
                }
            }

            return View(order);
        }

        public async Task<IActionResult> GetMyOrders(int? pageNumber)
        {

            var item = from order in _context.Orders
                       where order.User == _userManager.GetUserName(HttpContext.User)
                       orderby order.OrderPlaced descending
                       select new ManagmentOrdersViewModel
                       {
                           Order = order,
                           StatusOrder = _context.Dictionary.Where(p => p.CodeDict == "ORDERSTATUS").Where(p => p.CodeItem.Equals(order.StatusOrder)).Select(p => p.CodeValue).FirstOrDefault()
                       };

            int pageSize = 10;
            return View(await PaginatedList<ManagmentOrdersViewModel>.CreateAsync(item.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        public  IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var orderDetail =
           from detail in _context.OrderDetails
           join prod in _context.Products on detail.ProdId equals prod.Id
           join order in _context.Orders on detail.OrderId equals order.OrderId
           where detail.OrderId == id
           select new OrderDetailViewModel { Product= prod, OrderDetail=detail};

            ViewData["Status"] = _context.Dictionary.Where(p => p.CodeDict.Equals("ORDERSTATUS")).Where(p => p.CodeItem.Equals(_context.Orders.Where(p => p.OrderId == id).Select(p => p.StatusOrder).FirstOrDefault())).Select(p => p.CodeValue).FirstOrDefault();

            if (orderDetail == null)
            {
                return NotFound();
            }
            else

            return View(orderDetail);
        }

        public IActionResult SummaryOrder(Order order)
        {
            if (ModelState.IsValid)
            { 
                if (order.Payment.Equals("CASHONDELIVERY"))
                ViewData["Payment"] = _context.Dictionary.Where(p => p.CodeDict.Equals("PAYMENT")).Where(p => p.CodeItem.Equals("CASHONDELIVERY")).Select(p => p.CodeValue).FirstOrDefault();
            else
                ViewData["Payment"] = _context.Dictionary.Where(p => p.CodeDict.Equals("PAYMENT")).Where(p => p.CodeItem.Equals("CASHONDELIVERY")).Select(p => p.CodeValue).FirstOrDefault();
            }
            return View(order);
        }

        public IActionResult CheckoutComplete()
        {
            ViewBag.CheckoutCompleteMessage = "Dziękujemy za zakupy! :) ";
            return View();
        }
    }
}