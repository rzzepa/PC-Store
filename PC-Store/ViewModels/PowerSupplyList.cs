using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PC_Store.Models;

namespace PC_Store.ViewModels
{
    public class PowerSupplyList : IEnumerable
    {
        public PowerSupply powerSupply { get; set; }
        public Product Product { get; set; }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
