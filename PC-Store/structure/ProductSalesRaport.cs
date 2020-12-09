using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Store.structure
{
    public class ProductSalesRaport:IEnumerable
    {
        public DateTime Date { get; set; }

        public int Processors { get; set; }

        public int Motherboards { get; set; }

        public int Graphiccards { get; set; }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
