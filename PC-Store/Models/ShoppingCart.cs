using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PC_Store.Data;
using PC_Store.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Store.Models
{
    public class ShoppingCart: IEnumerable
    {
        private readonly ApplicationDbContext _context;

        private ShoppingCart(ApplicationDbContext context)
        {
            _context = context;
        }


        public string ShoppingCartId { get; set; }

        public List<ShoppingCardItem> ShoppingCartItems { get; set; }


        public static ShoppingCart GetCart(IServiceProvider service)
        {
            ISession session = service.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;

            var context = service.GetService<ApplicationDbContext>();
            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", cartId);
            return new ShoppingCart(context) { ShoppingCartId=cartId};
        }

        public void AddtoCart(Processor product,int amount)
        {
            ShoppingCardItem shoppingCartItem;
            try
            {
                shoppingCartItem = _context.shoppingCardItems.AsEnumerable().SingleOrDefault(s => s.Product.Id == product.GetId() && s.ShoppingCardId == ShoppingCartId);
            }
            catch
            {
                shoppingCartItem = null;
            }
                if(shoppingCartItem == null)
                {
                    shoppingCartItem = new ShoppingCardItem
                    {
                        ShoppingCardId = ShoppingCartId,
                        Product = product,
                        Amount = amount
                    };
                    _context.shoppingCardItems.Add(shoppingCartItem);
                }
                else
                {
                    shoppingCartItem.Amount++;
                }
                _context.SaveChanges();
            }

        public int RemoveFromCart(Processor product)
        {
            var shoppingCartItem = _context.shoppingCardItems.SingleOrDefault(s => s.Product.GetId() == product.Id && s.ShoppingCardId == ShoppingCartId);

            var localAmount = 0;

            if(shoppingCartItem!=null)
            {
                if(shoppingCartItem.Amount>1)
                {
                    shoppingCartItem.Amount--;
                    localAmount = shoppingCartItem.Amount;
                }
                else
                {
                    _context.shoppingCardItems.Remove(shoppingCartItem);
                }
            }

            _context.SaveChanges();
            return localAmount;
        }

        public List<ShoppingCardItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ?? (ShoppingCartItems = _context.shoppingCardItems.Where(c => c.ShoppingCardId == ShoppingCartId).Include(s=> s.Product).ToList());
        }

        public void ClearCart()
        {
            var cartItems = _context.shoppingCardItems.Where(c => c.ShoppingCardId == ShoppingCartId);

            _context.shoppingCardItems.RemoveRange(cartItems);
            _context.SaveChanges();
        }

        public decimal GetShoppingCartTotal()
        {
            try { 
            var total = _context.shoppingCardItems.Where(c => c.ShoppingCardId == ShoppingCartId)
                .Select(c => c.Product.GetPrice() * c.Amount).Sum();
                return total;
            }
            catch
            {
                return 0;
            }    
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
