using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PC_Store.Data;
using PC_Store.Interfaces;
using PC_Store.Models;
using PC_Store.Models.ViewModels;

namespace PC_Store.Controllers
{
    public class ShoppingCartController : Controller
    {

        private readonly ShoppingCart _shoppingCart;
        private readonly ApplicationDbContext _context;

        public ShoppingCartController(ApplicationDbContext context, ShoppingCart ShoppingCart)
        {
            _context = context;
            _shoppingCart = ShoppingCart;
        }

        public IActionResult Index()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            /*var sCVM =
            from prod in _context.Products
            join cartitems in _shoppingCart.ShoppingCartItems on prod.Id cartitems.Product.Id
            select new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal(),
                //Product = prod
            };*/

            var sCVM = new ShoppingCartViewModel
            {
                ShoppingCart=_shoppingCart,
                ShoppingCartTotal=_shoppingCart.GetShoppingCartTotal()
        };

            return View("View",sCVM);
        }

        [Authorize]
        public RedirectToActionResult AddtoShoppingCart(int? id)
        {
                var selectedProduct = _context.Products.FirstOrDefault(p => p.Id == id);
                if(selectedProduct!= null)
                    {
                         _shoppingCart.AddtoCart(selectedProduct, 1);
                     }
                return RedirectToAction("Index");
            }
        
    

        public RedirectToActionResult RemoveFromShoppingCart(int prodId)
        {
            var selectedProduct = _context.Products.FirstOrDefault(p => p.Id == prodId);
            if (selectedProduct != null)
            {
                _shoppingCart.RemoveFromCart(selectedProduct);
            }
            return RedirectToAction("Index");
        }
        public RedirectToActionResult IncresseAmount(int prodId)
        {
            var selectedProduct = _context.Products.FirstOrDefault(p => p.Id == prodId);
            if (selectedProduct != null)
            {
                _shoppingCart.AddtoCart(selectedProduct,1);
            }
            return RedirectToAction("Index");
        }
    }
}