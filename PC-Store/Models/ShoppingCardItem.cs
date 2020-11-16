using PC_Store.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Store.Models
{
    public class ShoppingCardItem
    {
        [Key]
        public int ShoppingCarditemId { get; set; }

        public Product Product { get; set; }

        public int Amount { get; set; }

        public string ShoppingCardId { get; set; }
    }
}
