using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PC_Store.Models;
using System.Collections;

namespace PC_Store.ViewModels
{
    public class CreateGraphicCardViewModel
    {
        public GraphicCard GraphicCard{ get; set; }
        public IEnumerable Producers { get; set; }
        public IEnumerable ChipsetProducers { get; set; }
        public IEnumerable Resolution { get; set; }
        public IEnumerable CoolingTypes { get; set; }
        public IEnumerable MemoryTypes { get; set; }
        public IFormFile File { get; set; }
    }
}
