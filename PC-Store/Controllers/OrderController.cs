using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PC_Store.Data;
using PC_Store.Interfaces;
using PC_Store.Models;
using PC_Store.Views.ViewModels;

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
                    _orderRepository.CreateOrder(order);
                    _shoppingCart.ClearCart();
                    return RedirectToAction("CheckoutComplete");
                }
            }

            return View(order);
        }

        public IActionResult GetMyOrders()
        {
            var item = _context.Orders.Where(p => p.User == _userManager.GetUserName(HttpContext.User)).OrderByDescending(p=>p.OrderPlaced);

            return View(item);
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
           where detail.OrderId == id
           select new OrderDetailViewModel { Product= prod, OrderDetail=detail };

            if (orderDetail == null)
            {
                return NotFound();
            }
            else

            return View(orderDetail);
        }

        public IActionResult CheckoutComplete()
        {
            ViewBag.CheckoutCompleteMessage = "Dziękujemy za zakupy! :) ";
            return View();
        }
    }
}