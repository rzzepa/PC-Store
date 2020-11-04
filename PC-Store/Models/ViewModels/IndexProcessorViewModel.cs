using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Store.Models.ViewModels
{
    public class IndexProcessorViewModel
    {
        public IQueryable<Processor> Processors { get; set; }
        public PagingInfoViewModel PagingInfo { get; set; }
    }
}
