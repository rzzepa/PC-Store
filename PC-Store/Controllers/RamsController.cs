using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PC_Store.Data;
using PC_Store.Infrastructure;
using PC_Store.Models;
using PC_Store.Views.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Store.Controllers
{
    public class RamsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly UserManager<IdentityUser> _userManager;

        public RamsController(ApplicationDbContext context, UserManager<IdentityUser> userManager, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index(string sortOrder, string searchString, string currentFilter, int? pageNumber)
        {
            ViewData["ProdSortParm"] = String.IsNullOrEmpty(sortOrder) ? "Prod_desc" : "";
            ViewData["TypeConSortParm"] = sortOrder == "typecon_asc" ? "typecon_desc" : "typecon_asc";
            ViewData["TotalCapSortParm"] = sortOrder == "totalcap_asc" ? "totalcap_desc" : "totalcap_asc";

            var ram = from s in _context.Rams select s;

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
                ram = ram.Where(s => s.Producer.Contains(searchString) || s.MemoryType.Contains(searchString) || s.Line.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "Prod_desc":
                    ram = ram.OrderByDescending(s => s.Producer);
                    break;
                case "typecon_asc":
                    ram = ram.OrderBy(s => s.ConnectorType);
                    break;
                case "typecon_desc":
                    ram = ram.OrderByDescending(s => s.ConnectorType);
                    break;
                case "totalcap_asc":
                    ram = ram.OrderBy(s => s.TotalCapacity);
                    break;
                case "totalcap_desc":
                    ram = ram.OrderByDescending(s => s.TotalCapacity);
                    break;
                default:
                    ram = ram.OrderBy(s => s.Producer);
                    break;
            }

            int pageSize = 15;
            return View(await PaginatedList<Ram>.CreateAsync(ram.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        public Task<IActionResult> RamDetail(int? id)
        {
            var x = _context.Rams.Where(p => p.ProductId == id).Select(p => p.Id).FirstOrDefault();
            return Details(x);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rams = await _context.Rams
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rams == null)
            {
                return NotFound();
            }

            return View("Details", rams);
        }


        public IActionResult RamDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ram =
            from Ra in _context.Rams
            join PR in _context.Products on Ra.ProductId equals PR.Id
            where PR.Act == true && Ra.ProductId == id
            select new RamProduct
            {
                ram = Ra,
                Product = PR
            };
            if (ram == null)
            {
                return NotFound();
            }
            RamProduct ramProduct = ram.FirstOrDefault();

            return View(ramProduct);
        }

        public IActionResult Create()
        {
            CreateRamViewModel createRamViewModel = new CreateRamViewModel()
            {
                Producers= _context.Dictionary.Where(p => p.CodeDict.Equals("PRODRAM")).OrderBy(p=>p.ExtN1).Select(o => o.CodeValue),
                ConnectorType = _context.Dictionary.Where(p => p.CodeDict.Equals("RAMCONN")).OrderBy(p => p.ExtN1).Select(o => o.CodeValue),
                Delay = _context.Dictionary.Where(p => p.CodeDict.Equals("RAMDELAY")).OrderBy(p => p.ExtN1).Select(o => o.CodeValue),
                MemoryType = _context.Dictionary.Where(p => p.CodeDict.Equals("RAMTYPE")).OrderBy(p => p.ExtN1).Select(o => o.CodeValue),
                TotalCapacity = _context.Dictionary.Where(p => p.CodeDict.Equals("RAMAMMOUNT")).OrderBy(p => p.ExtN1).Select(o => o.CodeValue)
            };
            return View(createRamViewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateRamViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = UploadedFile(model);
                Product product = new Product();
                product.Picture = uniqueFileName;
                product.Name = model.Ram.Producer + " " + model.Ram.ProducerCode + " " + model.Ram.TotalCapacity;
                product.Price = 0;
                product.Deleted = false;
                product.InsertBy = _userManager.GetUserName(HttpContext.User);
                product.ModifyBy = _userManager.GetUserName(HttpContext.User);
                product.InsertDate = DateTime.Now;
                product.ModifyDate = DateTime.Now;
                product.ProductType = "RAMMEMORY";
                product.Act = false;
                _context.Products.Add(product);

                _context.SaveChanges();

                model.Ram.ProductId = product.Id;
                _context.Add(model.Ram);

                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CreateRamViewModel createRamViewModel = new CreateRamViewModel()
            {
                Ram= await _context.Rams.FindAsync(id),
                Producers = _context.Dictionary.Where(p => p.CodeDict.Equals("PRODRAM")).OrderBy(p => p.ExtN1).Select(o => o.CodeValue),
                ConnectorType = _context.Dictionary.Where(p => p.CodeDict.Equals("RAMCONN")).OrderBy(p => p.ExtN1).Select(o => o.CodeValue),
                Delay = _context.Dictionary.Where(p => p.CodeDict.Equals("RAMDELAY")).OrderBy(p => p.ExtN1).Select(o => o.CodeValue),
                MemoryType = _context.Dictionary.Where(p => p.CodeDict.Equals("RAMTYPE")).OrderBy(p => p.ExtN1).Select(o => o.CodeValue),
                TotalCapacity = _context.Dictionary.Where(p => p.CodeDict.Equals("RAMAMMOUNT")).OrderBy(p => p.ExtN1).Select(o => o.CodeValue)
            };

            if (createRamViewModel.Ram== null)
            {
                return NotFound();
            }
            return View(createRamViewModel);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Ram ram)
        {
            if (id != ram.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ram);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RamExists(ram.Id))
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
            return View(ram);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ram = await _context.Rams
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ram == null)
            {
                return NotFound();
            }

            return View(ram);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ram = await _context.Rams.FindAsync(id);
            var prod = await _context.Products.FindAsync(ram.ProductId);
            prod.Deleted = true;
            _context.Products.Update(prod);
            _context.Rams.Remove(ram);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RamExists(int id)
        {
            return _context.Rams.Any(e => e.Id == id);
        }


        private string UploadedFile(CreateRamViewModel model)
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
    }
}
