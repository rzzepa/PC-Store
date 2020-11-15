using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using PC_Store.Interfaces;
using PC_Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Store.Data
{
    public class OrderRepository : IOrderRepository
    {

        private readonly ApplicationDbContext _context;
        private readonly ShoppingCart _shoppingCart;

        public OrderRepository (ApplicationDbContext context, ShoppingCart shoppingCart)
        {
            _context = context;
            _shoppingCart = shoppingCart;
        }

        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;
            _context.Orders.Add(order);  
            _context.SaveChanges();
            CreateOrderDetail(order);
        }

        public void CreateOrderDetail(Order order)
        {
            var shoppingCartItems = _shoppingCart.ShoppingCartItems;

            foreach (var item in shoppingCartItems)
            {
                var orderDetail = new OrderDetail()
                {
                    Amount = item.Amount,
                    ProdId = item.Product.GetId(),
                    OrderId = order.OrderId,
                    Price = item.Product.GetPrice()
                };
                _context.OrderDetails.Add(orderDetail);
            }
        }

    }
}
