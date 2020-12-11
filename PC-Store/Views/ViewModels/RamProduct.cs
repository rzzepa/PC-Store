using PC_Store.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Store.Views.ViewModels
{
    public class RamProduct : IEnumerable
    {
        public Ram ram { get; set; }
        public Product Product { get; set; }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
