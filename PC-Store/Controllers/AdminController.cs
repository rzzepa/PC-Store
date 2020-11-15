﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PC_Store.Controllers
{
    public class AdminController : Controller
    {
        [Authorize]
        public IActionResult Panel()
        {
            return View();
        }
    }
}