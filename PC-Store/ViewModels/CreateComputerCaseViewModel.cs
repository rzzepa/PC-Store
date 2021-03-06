﻿using Microsoft.AspNetCore.Http;
using PC_Store.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Store.ViewModels
{
    public class CreateComputerCaseViewModel
    {
        public ComputerCase ComputerCase { get; set; }
        public IEnumerable Producers { get; set; }
        public IEnumerable ComputerCaseType { get; set; }
        public IFormFile File { get; set; }
    }
}
