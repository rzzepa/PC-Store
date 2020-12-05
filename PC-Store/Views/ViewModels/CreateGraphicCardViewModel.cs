using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PC_Store.Models;

namespace PC_Store.Views.ViewModels
{
    public class CreateGraphicCardViewModel
    {
        public GraphicCard GraphicCard{ get; set; }
        public IFormFile File { get; set; }
    }
}
