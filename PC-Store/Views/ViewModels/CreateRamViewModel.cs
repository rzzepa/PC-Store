using Microsoft.AspNetCore.Http;
using PC_Store.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Store.Views.ViewModels
{
    public class CreateRamViewModel
    {
        public Ram Ram { get; set; }
        public IEnumerable Producers { get; set; }
        public IEnumerable ConnectorType { get; set; }
        public IEnumerable Delay { get; set; }
        public IEnumerable MemoryType { get; set; }
        public IEnumerable TotalCapacity { get; set; }
        public IFormFile File { get; set; }
    }
}
