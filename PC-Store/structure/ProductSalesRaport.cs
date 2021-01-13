using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Store.Structure
{
    public class ProductSalesRaport:IEnumerable
    {
        public DateTime Date { get; set; }

        public int Processors { get; set; }

        public int Motherboards { get; set; }

        public int Graphiccards { get; set; }
        
        public int Computercases{ get; set; }

        public int Rams { get; set; }

        public int PowerSupplies { get; set; }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
