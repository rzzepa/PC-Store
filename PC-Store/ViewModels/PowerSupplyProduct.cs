﻿using Microsoft.AspNetCore.Mvc;
using PC_Store.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Store.ViewModels
{
    public class PowerSupplyProduct : IEnumerable
    {
        public PowerSupply powerSupply{ get; set; }
        public Product Product { get; set; }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
