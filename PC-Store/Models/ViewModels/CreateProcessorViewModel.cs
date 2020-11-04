using Microsoft.AspNetCore.Http;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace PC_Store.Models.ViewModels
{
    public class CreateProcessorViewModel
    {
        public Processor Processor { get; set; }
        public IEnumerable Producers { get; set; }
        public IEnumerable SocketTypes { get; set; }
        public IFormFile File { get; set; }
    }
}
