using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PC_Store.Data;
using PC_Store.Models;
using X.PagedList;

namespace PC_Store.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;



        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var items = _context.Dictionary.Where(p => p.CodeDict == "PRODUCTS").OrderBy(p=>p.ExtN1);
            return View(items);
        }

        public IActionResult Privacy()
        {
            return View();
        }


        public ViewResult ProcessorList(string sortOrder, string searchString, int? page)
        {
            if (sortOrder == "producerASC") ViewBag.NameSortParam = "producerDESC";
            else if (sortOrder == "producerDESC") ViewBag.NameSortParam = "producerASC";
            else if (sortOrder == "lineASC") ViewBag.NameSortParam = "lineDESC";
            else if (sortOrder == "lineDESC") ViewBag.NameSortParam = "lineASC";
            else if (sortOrder is null) ViewBag.NameSortParam = "producerASC";
            
            var processors = from s in _context.Processors select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                processors = processors.Where(s => s.Producer.ToLower().Contains(searchString.ToLower()) || s.Line.ToLower().Contains(searchString.ToLower()) || s.SocketType.ToLower().Contains(searchString.ToLower())).OrderBy(s => s.Producer);
            }

            switch (sortOrder)
            {
                case "producerASC":
                    processors = processors.OrderBy(s => s.Producer);
                    break;

                case "producerDESC":
                    processors = processors.OrderByDescending(s => s.Producer);
                    break;

                case "lineASC":
                    processors = processors.OrderBy(s => s.Line);
                    break;

                case "lineDESC":
                    processors = processors.OrderByDescending(s => s.Line);
                    break;
            }

            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(processors.ToPagedList(pageNumber, pageSize));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
