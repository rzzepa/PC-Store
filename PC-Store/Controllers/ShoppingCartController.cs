using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PC_Store.Data;
using PC_Store.Interfaces;
using PC_Store.Models;
using PC_Store.ViewModels;

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


            var sCVM = new ShoppingCartViewModel
            {
                ShoppingCart=_shoppingCart,
                ShoppingCartTotal=_shoppingCart.GetShoppingCartTotal()
        };

            return View("View",sCVM);
        }

        public RedirectToActionResult AddtoShoppingCart(int? id, int quantity)
        {
            if (quantity == 0)
                quantity = 1;

                var selectedProduct = _context.Products.FirstOrDefault(p => p.Id == id);
                if(selectedProduct!= null)
                    {
                         _shoppingCart.AddtoCart(selectedProduct, quantity);
                     }
                return RedirectToAction("Index");
         }

        public RedirectToActionResult AddPCtoShoppingCart(string Id)
        {

            var pCCreator = _context.pCCreators.Where(p => p.PcCreatorId == Id).Select(i => new { i.GraphicCardProduct, i.MotherboardProduct, i.PowerSupplyProduct, i.ProcessorProduct, i.RamProduct, i.ComputerCaseProduct }).SingleOrDefault();
            /*var pCCreator =  _context.pCCreators.Select(i=> new {i.GraphicCardProduct,i.MotherboardProduct,i.PowerSupplyProduct,i.ProcessorProduct,i.RamProduct,i.ComputerCaseProduct})
            from PCC in _context.pCCreators
            where PCC.PcCreatorId == Id
            select new PCCreator(_context)
            {
                PcCreatorId = PCC.PcCreatorId,
                ComputerCaseProduct = PCC.ComputerCaseProduct,
                ProcessorProduct = PCC.ProcessorProduct,
                GraphicCardProduct = PCC.GraphicCardProduct,
                MotherboardProduct = PCC.MotherboardProduct,
                PowerSupplyProduct = PCC.PowerSupplyProduct,
                RamProduct = PCC.RamProduct
            };*/

            if (pCCreator.ComputerCaseProduct != null)
            {
                _shoppingCart.AddtoCart(pCCreator.ComputerCaseProduct, 1);
            }

            if (pCCreator.ProcessorProduct != null)
            {
                _shoppingCart.AddtoCart(pCCreator.ProcessorProduct, 1);
            }

            if (pCCreator.RamProduct != null)
            {
                _shoppingCart.AddtoCart(pCCreator.RamProduct, 1);
            }

            if (pCCreator.PowerSupplyProduct != null)
            {
                _shoppingCart.AddtoCart(pCCreator.PowerSupplyProduct, 1);
            }

            if (pCCreator.GraphicCardProduct != null)
            {
                _shoppingCart.AddtoCart(pCCreator.GraphicCardProduct, 1);
            }

            if (pCCreator.MotherboardProduct != null)
            {
                _shoppingCart.AddtoCart(pCCreator.MotherboardProduct, 1);
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