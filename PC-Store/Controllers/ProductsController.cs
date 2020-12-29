using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Differencing;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using PC_Store.Data;
using PC_Store.Infrastructure;
using PC_Store.Models;
using PC_Store.ViewModels;

namespace PC_Store.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductsController(ApplicationDbContext context, UserManager<IdentityUser> userManager, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _userManager = userManager;
        }


        public async Task<IActionResult> Index(string sortOrder, string searchString, string currentFilter, int? pageNumber, string filter)
        {
            ViewData["TypeProdSortParm"] = String.IsNullOrEmpty(sortOrder) ? "Type_desc" : "";
            ViewData["PriceSortParm"] = sortOrder == "price_asc" ? "price_desc" : "price_asc";
            ViewData["Filter"] = String.IsNullOrEmpty(filter) ? "" : filter;
            ViewData["pageNumber"] = pageNumber;
            ViewBag.products = _context.Dictionary.Where(p=>p.CodeDict== "PRODUCTS").Select(p => p.CodeValue).Distinct();
            var prod = from s in _context.Products where s.Deleted==false select s;

            if (filter != null)
            {
                filter = _context.Dictionary.Where(p => p.CodeDict == "PRODUCTS").Where(p => p.CodeValue == filter).Select(p => p.CodeItem).FirstOrDefault();
                prod = prod.Where(p => p.ProductType.Equals(filter));
            }
                

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
                searchString = searchString.ToLower();
                prod = prod.Where(s => s.ProductType.ToLower().Contains(searchString) || s.Name.ToLower().Contains(searchString));
            }

            switch (sortOrder)
            {
                case "Type_desc":
                    prod = prod.OrderByDescending(s => s.ProductType).ThenBy(s => s.Name);
                    break;
                case "price_asc":
                    prod = prod.OrderBy(s => s.Price).ThenBy(s => s.Name);
                    break;
                case "price_desc":
                    prod = prod.OrderByDescending(s => s.Price).ThenBy(s => s.Name);
                    break;
                default:
                    prod = prod.OrderBy(s => s.ProductType).ThenBy(s => s.Name);
                    break;
            }

            int pageSize = 15;
            return View(await PaginatedList<Product>.CreateAsync(prod.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        public int ProcessorDetail(int? id)
        {
            var itemId =
            from PROC in _context.Processors
            join PR in _context.Products on PROC.ProductId equals PR.Id
            where PR.Id == id
            select new Processor { Id= PROC.Id };

            return itemId.Select(p=>p.Id).FirstOrDefault(); 
        }

        public int GraphicCardDetail(int? id)
        {
            var itemId =
            from GC in _context.GraphicCards
            join PR in _context.Products on GC.ProductId equals PR.Id
            where PR.Id == id
            select new GraphicCard { Id = GC.Id };

            return itemId.Select(p => p.Id).FirstOrDefault();
        }

        public int MotherboardDetail(int? id)
        {
            var itemId =
            from MB in _context.Motherboards
            join PR in _context.Products on MB.ProductId equals PR.Id
            where PR.Id == id
            select new Motherboard { Id = MB.Id };

            return itemId.Select(p => p.Id).FirstOrDefault();
        }

        public int ComputerCaseDetail(int? id)
        {
            var itemId =
            from CC in _context.ComputerCases
            join PR in _context.Products on CC.ProductId equals PR.Id
            where PR.Id == id
            select new Motherboard { Id = CC.Id };

            return itemId.Select(p => p.Id).FirstOrDefault();
        }

        public int RamDetail(int? id)
        {
            var itemId =
            from Ra in _context.Rams
            join PR in _context.Products on Ra.ProductId equals PR.Id
            where PR.Id == id
            select new Ram { Id = Ra.Id };

            return itemId.Select(p => p.Id).FirstOrDefault();
        }

        public int PowerSupplyDetail(int? id)
        {
            var itemId =
            from PS in _context.PowerSupplies
            join PR in _context.Products on PS.ProductId equals PR.Id
            where PR.Id == id
            select new Ram { Id = PS.Id };

            return itemId.Select(p => p.Id).FirstOrDefault();
        }

/*        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Price,Name,Picture")] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }*/


        public async Task<IActionResult> Edit(int? id,string message, int? pageNumber, string filter, string currentFilter)
        {
            ViewData["Filter"] = String.IsNullOrEmpty(filter) ? "" : filter;

            if (id == null)
            {
                return NotFound();
            }
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            if(message != null)
            {
                ViewBag.Mess = message;
            }

            ViewData["CurrentFilter"] = currentFilter;

            EditProductViewModel editProductViewModel = null;

            if (product.ProductType.Equals("PROCESSOR"))
            {
                editProductViewModel= new EditProductViewModel()
                {
                    Product = product,
                    Id = ProcessorDetail(product.Id)
                };
            }
            else if(product.ProductType.Equals("GRAPHICSCARD"))
            {
                editProductViewModel = new EditProductViewModel()
                {
                    Product = product,
                    Id = GraphicCardDetail(product.Id)
                };
            }
            else if (product.ProductType.Equals("MOTHERBOARD"))
            {
                editProductViewModel = new EditProductViewModel()
                {
                    Product = product,
                    Id = MotherboardDetail(product.Id)
                };
            }
            else if (product.ProductType.Equals("COMPUTERCASE"))
            {
                editProductViewModel = new EditProductViewModel()
                {
                    Product = product,
                    Id = ComputerCaseDetail(product.Id)
                };
            }
            else if (product.ProductType.Equals("RAMMEMORY"))
            {
                editProductViewModel = new EditProductViewModel()
                {
                    Product = product,
                    Id = RamDetail(product.Id)
                };
            }
            else if (product.ProductType.Equals("POWERSUPPLY"))
            {
                editProductViewModel = new EditProductViewModel()
                {
                    Product = product,
                    Id = PowerSupplyDetail(product.Id)
                };
            }


            return View(editProductViewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EditProductViewModel model)
        {
            if (id != model.Product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Product product = GetProduct(id);
                    product.Name = model.Product.Name;
                    if(model.File!=null)
                    {
                        product.Picture = UploadedFile(model);
                    }
                    product.Price = model.Product.Price;
                    product.Act = model.Product.Act;
                    product.ModifyDate= DateTime.Now;
                    product.ModifyBy = _userManager.GetUserName(HttpContext.User);
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(model.Product.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddQuantity(EditProductViewModel model, int? pageNumber, string filter, string currentFilter)
        {
            var product =  _context.Products.Where(p => p.Id == model.Product.Id).FirstOrDefault();
            product.Quantity += model.OrderProduct;
            _context.Products.Update(product);
            _context.SaveChanges();
            return RedirectToAction ("Edit",new { id = model.Product.Id, message= "Zamówienie dotarło do magazynu", pageNumber= pageNumber, filter= filter, currentFilter= currentFilter });
        }

        private Product GetProduct(int? id)
        {
            Product product = _context.Products.Where(p => p.Id == id).SingleOrDefault();

            return product;
        }

        private string UploadedFile(EditProductViewModel model)
        {
            string uniqueFileName = null;

            if (model.File != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.File.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.File.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }

        /*        public async Task<IActionResult> Delete(int? id)
                {
                    if (id == null)
                    {
                        return NotFound();
                    }

                    var product = await _context.Products
                        .FirstOrDefaultAsync(m => m.Id == id);
                    if (product == null)
                    {
                        return NotFound();
                    }

                    return View(product);
                }*/

        /*        [HttpPost, ActionName("Delete")]
                [ValidateAntiForgeryToken]
                public async Task<IActionResult> DeleteConfirmed(int id)
                {
                    var product = await _context.Products.FindAsync(id);
                        _context.Products.Remove(product);
                        await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
                }*/

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
