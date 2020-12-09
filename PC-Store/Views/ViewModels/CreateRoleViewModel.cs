﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Store.Views.ViewModels
{
    public class CreateRoleViewModel
    {
            [Required]
            [Display(Name = "Role")]
            public string RoleName { get; set; }
    }
}
