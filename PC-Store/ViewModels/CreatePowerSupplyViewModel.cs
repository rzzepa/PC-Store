using Microsoft.AspNetCore.Http;
using PC_Store.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Store.ViewModels
{
    public class CreatePowerSupplyViewModel
    {
        public PowerSupply powerSupply{ get; set; }
        public IEnumerable Producers { get; set; }
        public IEnumerable Certificate { get; set; }
        public IEnumerable ModularCabling { get; set; }
        public IEnumerable CoolingType { get; set; }
        public IEnumerable Standard { get; set; }
        public IFormFile File { get; set; }
    }
}
