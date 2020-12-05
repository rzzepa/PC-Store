using PC_Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Store.Views.ViewModels
{
    public class OrderDetailViewModel
    {
        public Product  Product{ get; set; }

        public OrderDetail OrderDetail { get; set; }
    }
}
