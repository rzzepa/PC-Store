using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Store.Views.ViewModels
{
    public class RoleListViewModel
    {
        public List<IdentityRole> RoleList { get; set; }
    }
}
