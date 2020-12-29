using PC_Store.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PC_Store.Models;

namespace PC_Store.ViewModels
{
    public class IndexProcessorViewModel
    {
        public IQueryable<Processor> Processors { get; set; }
    }
}
