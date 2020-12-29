using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PC_Store.Data;
using PC_Store.Infrastructure;
using PC_Store.Models;
using PC_Store.ViewModels;

namespace PC_Store.Controllers
{
    public class MotherboardsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly int pageSize;

        public MotherboardsController(ApplicationDbContext context, UserManager<IdentityUser> userManager, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _userManager = userManager;
            pageSize = _context.Dictionary.Where(p => p.CodeDict.Equals("CONFIG")).Where(p => p.CodeItem.Equals("PAGING")).Select(p => p.ExtN2).FirstOrDefault();
        }


        public async Task<IActionResult> Index(string sortOrder, string searchString, string currentFilter, int? pageNumber)
        {
            ViewData["ProdSortParm"] = String.IsNullOrEmpty(sortOrder) ? "Prod_desc" : "";
            ViewData["StandardSortParm"] = sortOrder == "standard_asc" ? "standard_desc" : "standard_asc";
            ViewData["SocketSortParm"] = sortOrder == "socket_asc" ? "socket_desc" : "socket_asc";

            var motherboard = from s in _context.Motherboards select s;

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
                motherboard = motherboard.Where(s => s.Producer.ToLower().Contains(searchString) || s.ProducerCode.ToLower().Contains(searchString) || s.SocketType.ToLower().Contains(searchString) || s.StandardMemory.ToLower().Contains(searchString));
            }

            switch (sortOrder)
            {
                case "Prod_desc":
                    motherboard = motherboard.OrderByDescending(s => s.Producer);
                    break;
                case "standard_asc":
                    motherboard = motherboard.OrderBy(s => s.Standard);
                    break;
                case "standard_desc":
                    motherboard = motherboard.OrderByDescending(s => s.Standard);
                    break;
                case "socket_asc":
                    motherboard = motherboard.OrderBy(s => s.SocketType);
                    break;
                case "socket_desc":
                    motherboard = motherboard.OrderByDescending(s => s.SocketType);
                    break;
                default:
                    motherboard = motherboard.OrderBy(s => s.Producer);
                    break;
            }


            return View(await PaginatedList<Motherboard>.CreateAsync(motherboard.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        public Task<IActionResult> MotherboardDetail(int? id)
        {
            var x = _context.Motherboards.Where(p => p.ProductId == id).Select(p => p.Id).FirstOrDefault();
            return Details(x);
        }

        // GET: Motherboards/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var motherboard = await _context.Motherboards
                .FirstOrDefaultAsync(m => m.Id == id);
            if (motherboard == null)
            {
                return NotFound();
            }

            return View("Details",motherboard);
        }

        public IActionResult MotherboardDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var motherboard =
            from MB in _context.Motherboards
            join PR in _context.Products on MB.ProductId equals PR.Id
            where PR.Act == true && MB.ProductId == id
            select new MotherboardProduct
            {
                Motherboard = MB,
                Product = PR
            };
            if (motherboard == null)
            {
                return NotFound();
            }
            MotherboardProduct motherboardProduct = motherboard.FirstOrDefault();

            return View(motherboardProduct);
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateMotherboardViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = UploadedFile(model);
                Product product = new Product();
                product.Picture = uniqueFileName;
                product.Name = model.Motherboard.Producer + " " +model.Motherboard.Chipset+" "+model.Motherboard.SocketType;
                product.Price = 0;
                product.Deleted = false;
                product.InsertBy = _userManager.GetUserName(HttpContext.User);
                product.ModifyBy = _userManager.GetUserName(HttpContext.User);
                product.InsertDate = DateTime.Now;
                product.ModifyDate = DateTime.Now;
                product.ProductType = "MOTHERBOARD";
                product.Quantity = 0;
                product.Act = false;
                _context.Products.Add(product);

                 _context.SaveChanges();

                model.Motherboard.ProductId = product.Id;
                _context.Add(model.Motherboard);

                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Create));
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var motherboard = await _context.Motherboards.FindAsync(id);
            if (motherboard == null)
            {
                return NotFound();
            }
            return View(motherboard);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Motherboard motherboard)
        {
            if (id != motherboard.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(motherboard);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MotherboardExists(motherboard.Id))
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
            return View(motherboard);
        }

        // GET: Motherboards/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var motherboard = await _context.Motherboards
                .FirstOrDefaultAsync(m => m.Id == id);
            if (motherboard == null)
            {
                return NotFound();
            }

            return View(motherboard);
        }

        // POST: Motherboards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var motherboard = await _context.Motherboards.FindAsync(id);
            var prod = await _context.Products.FindAsync(motherboard.ProductId);
            prod.Deleted = true;
            _context.Products.Update(prod);
            _context.Motherboards.Remove(motherboard);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MotherboardExists(int id)
        {
            return _context.Motherboards.Any(e => e.Id == id);
        }


        private string UploadedFile(CreateMotherboardViewModel model)
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
