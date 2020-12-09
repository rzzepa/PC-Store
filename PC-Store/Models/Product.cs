using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Store.Models
{
    public class Product
    {
        public int Id { get; set; }

        public decimal Price { get; set; }

        public string Name { get; set; }

        public string Picture { get; set; }

        public bool Act { get; set; }

        public string ProductType { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime InsertDate { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime ModifyDate { get; set; }

        public string InsertBy { get; set; }

        public string ModifyBy { get; set; }
    }
}
