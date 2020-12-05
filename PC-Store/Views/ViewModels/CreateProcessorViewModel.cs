using Microsoft.AspNetCore.Http;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PC_Store.Models;

namespace PC_Store.Views.ViewModels
{
    public class CreateProcessorViewModel
    {
        public Processor Processor { get; set; }
        public IEnumerable Producers { get; set; }
        public IEnumerable SocketTypes { get; set; }
        public IFormFile File { get; set; }
    }
}
