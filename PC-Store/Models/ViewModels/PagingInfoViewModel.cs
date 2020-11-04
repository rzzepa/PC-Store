using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Store.Models.ViewModels
{
    public class PagingInfoViewModel
    {
        public int TotalItems { get; set; }
        public int CurrentPage { get; set; }
        public int ItemPerPage { get; set; }

        public int TotalPages =>
            (int)Math.Ceiling((decimal)TotalItems / ItemPerPage);
    }

}
