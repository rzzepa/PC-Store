using PC_Store.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Store.Views.ViewModels
{
    public class CreateDictionaryViewModel
    {
        public Dictionary Dictionary { get; set; }
        public IEnumerable Dict { get; set; }
    }
}
