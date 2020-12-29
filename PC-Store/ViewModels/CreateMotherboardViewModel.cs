using Microsoft.AspNetCore.Http;
using PC_Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Store.ViewModels
{
    public class CreateMotherboardViewModel
    {
        public Motherboard Motherboard{ get; set; }
        public IFormFile File { get; set; }
    }
}
