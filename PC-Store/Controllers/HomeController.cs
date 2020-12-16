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
using PC_Store.Views.ViewModels;
using PC_Store.Infrastructure;
using Microsoft.EntityFrameworkCore;

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


        public async Task<IActionResult> ProcessorList(string sortOrder, string searchString, string currentFilter, int? pageNumber)
        {
            ViewData["sortOrder"] = sortOrder == "price_desc" ? "price_asc" : "price_desc";

            var processors =
            from PRo in _context.Processors
            join PR in _context.Products on PRo.ProductId equals PR.Id
            where PR.Act == true
            select new ProcessorProduct
            {
                Processor = PRo,
                Product = PR
            };

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            if (!String.IsNullOrEmpty(searchString))
            {
                processors = processors.Where(s => s.Processor.Producer.ToLower().Contains(searchString.ToLower()) || s.Processor.SocketType.ToLower().Contains(searchString.ToLower()));
            }

            switch (sortOrder)
            {
                case "price_desc":
                    processors = processors.OrderByDescending(s => s.Product.Price);
                    break;
                default:
                    processors = processors.OrderBy(s => s.Product.Price) ;
                    break;
            }



            int pageSize = 15;
            return View(await PaginatedList<ProcessorProduct>.CreateAsync(processors.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        public async Task<IActionResult> MotherboardList(string sortOrder, string searchString, string currentFilter, int? pageNumber)
        {
            ViewData["sortOrder"] = sortOrder == "price_desc" ? "price_asc" : "price_desc";

            var MotherBoard =
            from MB in _context.Motherboards
            join PR in _context.Products on MB.ProductId equals PR.Id
            where PR.Act == true
            select new MotherboardProduct
            {
                Motherboard = MB,
                Product=PR
            };

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            if (!String.IsNullOrEmpty(searchString))
            {
                MotherBoard = MotherBoard.Where(s => s.Motherboard.Producer.ToLower().Contains(searchString.ToLower()) || s.Motherboard.SocketType.ToLower().Contains(searchString.ToLower()) || s.Motherboard.StandardMemory.ToLower().Contains(searchString.ToLower()) || s.Motherboard.Chipset.ToLower().Contains(searchString.ToLower()));
            }

            switch (sortOrder)
            {
                case "price_desc":
                    MotherBoard = MotherBoard.OrderByDescending(s => s.Product.Price);
                    break;
                default:
                    MotherBoard = MotherBoard.OrderBy(s => s.Product.Price);
                    break;
            }

            int pageSize = 15;
            return View(await PaginatedList<MotherboardProduct>.CreateAsync(MotherBoard.AsNoTracking(), pageNumber ?? 1, pageSize));
        }
        
        public async Task<IActionResult> GraphicCardList(string sortOrder, string searchString, string currentFilter, int? pageNumber)
        {
            ViewData["sortOrder"] = sortOrder == "price_desc" ? "price_asc" : "price_desc";

            var GraphicCards =
            from GC in _context.GraphicCards
            join PR in _context.Products on GC.ProductId equals PR.Id
            where PR.Act == true
            select new GraphicCardProduct
            {
                GraphicCard=GC,
                Product=PR
            };
            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            if (!String.IsNullOrEmpty(searchString))
            {
                GraphicCards = GraphicCards.Where(s => s.GraphicCard.Producer.ToLower().Contains(searchString.ToLower()) || s.GraphicCard.ProducerChipset.ToLower().Contains(searchString.ToLower()) || s.GraphicCard.ProducerCode.ToLower().Contains(searchString.ToLower()));
            }

            switch (sortOrder)
            {
                case "price_desc":
                    GraphicCards = GraphicCards.OrderByDescending(s => s.Product.Price);
                    break;
                default:
                    GraphicCards = GraphicCards.OrderBy(s => s.Product.Price);
                    break;
            }

            int pageSize = 15;
            return View(await PaginatedList<GraphicCardProduct>.CreateAsync(GraphicCards.AsNoTracking(), pageNumber ?? 1, pageSize));
        }
        
        public async Task<IActionResult> ComputerCaseList(string sortOrder, string searchString, string currentFilter, int? pageNumber)
        {
            ViewData["sortOrder"] = sortOrder == "price_desc" ? "price_asc" : "price_desc";

            var ComputerCase =
            from CC in _context.ComputerCases
            join PR in _context.Products on CC.ProductId equals PR.Id
            where PR.Act == true
            select new ComputerCaseProduct
            {
                ComputerCase = CC,
                Product = PR
            };

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            if (!String.IsNullOrEmpty(searchString))
            {
                ComputerCase = ComputerCase.Where(s => s.ComputerCase.Producer.ToLower().Contains(searchString.ToLower()) || s.ComputerCase.ProducerCode.ToLower().Contains(searchString.ToLower()) || s.ComputerCase.Compatibility.ToLower().Contains(searchString.ToLower()));
            }

            switch (sortOrder)
            {
                case "price_desc":
                    ComputerCase = ComputerCase.OrderByDescending(s => s.Product.Price);
                    break;
                default:
                    ComputerCase = ComputerCase.OrderBy(s => s.Product.Price);
                    break;
            }

            int pageSize = 15;
            return View(await PaginatedList<ComputerCaseProduct>.CreateAsync(ComputerCase.AsNoTracking(), pageNumber ?? 1, pageSize));
        }
        
        public async Task<IActionResult> RamList(string sortOrder, string searchString, string currentFilter, int? pageNumber)
        {
            ViewData["sortOrder"] = sortOrder == "price_desc" ? "price_asc" : "price_desc";

            var ram =
            from Ra in _context.Rams
            join PR in _context.Products on Ra.ProductId equals PR.Id
            where PR.Act == true
            select new RamProduct
            {
                ram = Ra,
                Product = PR
            };

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            if (!String.IsNullOrEmpty(searchString))
            {
                ram = ram.Where(s => s.ram.Producer.ToLower().Contains(searchString.ToLower()) || s.ram.ProducerCode.ToLower().Contains(searchString.ToLower()) || s.ram.MemoryType.ToLower().Contains(searchString.ToLower()));
            }

            switch (sortOrder)
            {
                case "price_desc":
                    ram = ram.OrderByDescending(s => s.Product.Price);
                    break;
                default:
                    ram = ram.OrderBy(s => s.Product.Price);
                    break;
            }

            int pageSize = 15;
            return View(await PaginatedList<RamProduct>.CreateAsync(ram.AsNoTracking(), pageNumber ?? 1, pageSize));
        }
        
        public async Task<IActionResult> PowerSupplyList(string sortOrder, string searchString, string currentFilter, int? pageNumber)
        {
            ViewData["sortOrder"] = sortOrder == "price_desc" ? "price_asc" : "price_desc";

            var powerSupplies =
            from PS in _context.PowerSupplies
            join PR in _context.Products on PS.ProductId equals PR.Id
            where PR.Act == true
            select new PowerSupplyProduct
            {
                powerSupply = PS,
                Product = PR
            };

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            if (!String.IsNullOrEmpty(searchString))
            {
                powerSupplies = powerSupplies.Where(s => s.powerSupply.Producer.ToLower().Contains(searchString.ToLower()) || s.powerSupply.ProducerCode.ToLower().Contains(searchString.ToLower()) || s.powerSupply.Standard.ToLower().Contains(searchString.ToLower()));
            }

            switch (sortOrder)
            {
                case "price_desc":
                    powerSupplies = powerSupplies.OrderByDescending(s => s.Product.Price);
                    break;
                default:
                    powerSupplies = powerSupplies.OrderBy(s => s.Product.Price);
                    break;
            }

            int pageSize = 15;
            return View(await PaginatedList<PowerSupplyProduct>.CreateAsync(powerSupplies.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
