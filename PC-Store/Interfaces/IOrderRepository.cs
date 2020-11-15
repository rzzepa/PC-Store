using PC_Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Store.Interfaces
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order);
    }
}
