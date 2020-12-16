using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
    public class PowerSuppliesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly UserManager<IdentityUser> _userManager;

        public PowerSuppliesController(ApplicationDbContext context, UserManager<IdentityUser> userManager, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index(string sortOrder, string searchString, string currentFilter, int? pageNumber)
        {
            ViewData["ProdSortParm"] = String.IsNullOrEmpty(sortOrder) ? "prod_desc" : "";
            ViewData["StandardSortParm"] = sortOrder == "standard_asc" ? "standard_desc" : "standard_asc";
            ViewData["PowerSortParm"] = sortOrder == "power_asc" ? "power_desc" : "power_asc";

            var powersupp = from s in _context.PowerSupplies select s;

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
                powersupp = powersupp.Where(s => s.Producer.Contains(searchString) || s.Standard.Contains(searchString) || s.Power.ToString().Contains(searchString));
            }

            switch (sortOrder)
            {
                case "prod_desc":
                    powersupp = powersupp.OrderByDescending(s => s.Producer);
                    break;
                case "standard_asc":
                    powersupp = powersupp.OrderBy(s => s.Standard);
                    break;
                case "standard_desc":
                    powersupp = powersupp.OrderByDescending(s => s.Standard);
                    break;
                case "power_asc":
                    powersupp = powersupp.OrderBy(s => s.Power);
                    break;
                case "power_desc":
                    powersupp = powersupp.OrderByDescending(s => s.Power);
                    break;
                default:
                    powersupp = powersupp.OrderBy(s => s.Producer);
                    break;
            }

            int pageSize = 15;
            return View(await PaginatedList<PowerSupply>.CreateAsync(powersupp.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        public Task<IActionResult> PowerSupplyDetail(int? id)
        {
            var x = _context.PowerSupplies.Where(p => p.ProductId == id).Select(p => p.Id).FirstOrDefault();
            return Details(x);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rams = await _context.PowerSupplies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rams == null)
            {
                return NotFound();
            }

            return View("Details", rams);
        }


        public IActionResult PowerSupplyDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var powerSupply =
            from PS in _context.PowerSupplies
            join PR in _context.Products on PS.ProductId equals PR.Id
            where PR.Act == true && PS.ProductId == id
            select new PowerSupplyProduct
            {
                powerSupply = PS,
                Product = PR
            };
            if (powerSupply == null)
            {
                return NotFound();
            }
            PowerSupplyProduct powerSupp = powerSupply.FirstOrDefault();

            return View(powerSupp);
        }

        public IActionResult Create()
        {
            CreatePowerSupplyViewModel createPowerSupply = new CreatePowerSupplyViewModel()
            {
                Producers = _context.Dictionary.Where(p => p.CodeDict.Equals("PRODPOWSUPPLY")).OrderBy(p => p.ExtN1).Select(o => o.CodeValue),
                Certificate = _context.Dictionary.Where(p => p.CodeDict.Equals("CERTIFICATEPRODSUPPLY")).OrderBy(p => p.ExtN1).Select(o => o.CodeValue),
                ModularCabling = _context.Dictionary.Where(p => p.CodeDict.Equals("PSUPPLYMODULAR")).OrderBy(p => p.ExtN1).Select(o => o.CodeValue),
                CoolingType =_context.Dictionary.Where(p => p.CodeDict.Equals("PSUPPLYCOOLINGTYPE")).OrderBy(p => p.ExtN1).Select(o => o.CodeValue),
                Standard = _context.Dictionary.Where(p => p.CodeDict.Equals("PSUPPLYSTANDARD")).OrderBy(p => p.ExtN1).Select(o => o.CodeValue)
            };
            return View(createPowerSupply);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreatePowerSupplyViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = UploadedFile(model);
                Product product = new Product();
                product.Picture = uniqueFileName;
                product.Name = model.powerSupply.Producer + " " + model.powerSupply.ProducerCode + " " + model.powerSupply.Power+"W";
                product.Price = 0;
                product.Deleted = false;
                product.InsertBy = _userManager.GetUserName(HttpContext.User);
                product.ModifyBy = _userManager.GetUserName(HttpContext.User);
                product.InsertDate = DateTime.Now;
                product.ModifyDate = DateTime.Now;
                product.ProductType = "POWERSUPPLY";
                product.Act = false;
                _context.Products.Add(product);

                _context.SaveChanges();

                model.powerSupply.ProductId = product.Id;
                _context.PowerSupplies.Add(model.powerSupply);

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

            CreatePowerSupplyViewModel createPowerSupply = new CreatePowerSupplyViewModel()
            {
                powerSupply = await _context.PowerSupplies.FindAsync(id),
                Producers = _context.Dictionary.Where(p => p.CodeDict.Equals("PRODPOWSUPPLY")).OrderBy(p => p.ExtN1).Select(o => o.CodeValue),
                Certificate = _context.Dictionary.Where(p => p.CodeDict.Equals("CERTIFICATEPRODSUPPLY")).OrderBy(p=>p.ExtN1).Select(o => o.CodeValue),
                ModularCabling = _context.Dictionary.Where(p => p.CodeDict.Equals("PSUPPLYMODULAR")).OrderBy(p => p.ExtN1).Select(o => o.CodeValue),
                CoolingType = _context.Dictionary.Where(p => p.CodeDict.Equals("PSUPPLYCOOLINGTYPE")).OrderBy(p => p.ExtN1).Select(o => o.CodeValue),
                Standard = _context.Dictionary.Where(p => p.CodeDict.Equals("PSUPPLYSTANDARD")).OrderBy(p => p.ExtN1).Select(o => o.CodeValue)
            };

            if (createPowerSupply.powerSupply == null)
            {
                return NotFound();
            }
            return View(createPowerSupply);
        }
         


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, PowerSupply powerSupply)
        {
            if (id != powerSupply.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(powerSupply);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RamExists(powerSupply.Id))
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
            return View(powerSupply);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ram = await _context.PowerSupplies
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
            var powerSupply = await _context.PowerSupplies.FindAsync(id);
            _context.PowerSupplies.Remove(powerSupply);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RamExists(int id)
        {
            return _context.PowerSupplies.Any(e => e.Id == id);
        }


        private string UploadedFile(CreatePowerSupplyViewModel model)
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
