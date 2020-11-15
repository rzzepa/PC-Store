using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Store.Interfaces
{
    public interface IProducts
    {
        public int GetId();

        public decimal GetPrice();
    }
}
