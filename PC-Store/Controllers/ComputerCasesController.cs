using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PC_Store.Data;
using PC_Store.Infrastructure;
using PC_Store.Models;
using PC_Store.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Store.Controllers
{
    public class ComputerCasesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly int pageSize;

        public ComputerCasesController(ApplicationDbContext context, UserManager<IdentityUser> userManager, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _userManager = userManager;
            pageSize = _context.Dictionary.Where(p => p.CodeDict.Equals("CONFIG")).Where(p => p.CodeItem.Equals("PAGING")).Select(p => p.ExtN2).FirstOrDefault();
        }


        public async Task<IActionResult> Index(string sortOrder, string searchString, string currentFilter, int? pageNumber)
        {

            ViewData["ProdSortParm"] = String.IsNullOrEmpty(sortOrder) ? "Prod_desc" : "";
            ViewData["CaseTypeSortParm"] = sortOrder == "case_asc" ? "case_desc" : "case_asc";

            var computecase = from s in _context.ComputerCases select s;

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
                computecase = computecase.Where(s => s.Producer.ToLower().Contains(searchString) || s.ComputerCaseType.ToLower().Contains(searchString) || s.Compatibility.ToLower().Contains(searchString));
            }

            switch (sortOrder)
            {
                case "Prod_desc":
                    computecase = computecase.OrderByDescending(s => s.Producer);
                    break;
                case "case_asc":
                    computecase = computecase.OrderBy(s => s.ComputerCaseType);
                    break;
                case "case_desc":
                    computecase = computecase.OrderByDescending(s => s.ComputerCaseType);
                    break;
                default:
                    computecase = computecase.OrderBy(s => s.Producer);
                    break;
            }


            return View(await PaginatedList<ComputerCase>.CreateAsync(computecase.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        public Task<IActionResult> ComputerCaseDetail(int? id)
        {
            var x = _context.ComputerCases.Where(p => p.ProductId == id).Select(p => p.Id).FirstOrDefault();
            return Details(x);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var computerCase = await _context.ComputerCases
                .FirstOrDefaultAsync(m => m.Id == id);
            if (computerCase == null)
            {
                return NotFound();
            }

            return View("Details", computerCase);
        }


        public IActionResult ComputerCaseDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var computercase =
            from CC in _context.ComputerCases
            join PR in _context.Products on CC.ProductId equals PR.Id
            where PR.Act == true && CC.ProductId == id
            select new ComputerCaseProduct
            {
                ComputerCase = CC,
                Product = PR
            };
            if (computercase == null)
            {
                return NotFound();
            }
            ComputerCaseProduct computerCaseProduct = computercase.FirstOrDefault();

            return View(computerCaseProduct);
        }

        public IActionResult Create()
        {
            CreateComputerCaseViewModel createComputerCaseViewModel = new CreateComputerCaseViewModel()
            {
                Producers = _context.Dictionary.Where(p => p.CodeDict.Equals("PRODCCASE")).OrderBy(p => p.ExtN1).Select(o => o.CodeValue),
                ComputerCaseType = _context.Dictionary.Where(p => p.CodeDict.Equals("CCASETYPE")).OrderBy(p => p.ExtN1).Select(o => o.CodeValue)
            };
            return View(createComputerCaseViewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateComputerCaseViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = UploadedFile(model);
                Product product = new Product();
                product.Picture = uniqueFileName;
                product.Name = model.ComputerCase.Producer + " " + model.ComputerCase.ProducerCode + " " + model.ComputerCase.Color;
                product.Price = 0;
                product.Deleted = false;
                product.InsertBy = _userManager.GetUserName(HttpContext.User);
                product.ModifyBy = _userManager.GetUserName(HttpContext.User);
                product.InsertDate = DateTime.Now;
                product.ModifyDate = DateTime.Now;
                product.ProductType = "COMPUTERCASE";
                product.Quantity = 0;
                product.Act = false;
                _context.Products.Add(product);

                _context.SaveChanges();

                model.ComputerCase.ProductId = product.Id;
                _context.Add(model.ComputerCase);

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
            CreateComputerCaseViewModel createComputerCaseViewModel = new CreateComputerCaseViewModel()
            {
                ComputerCase = await _context.ComputerCases.FindAsync(id),
                Producers = _context.Dictionary.Where(p => p.CodeDict.Equals("PRODCCASE")).OrderBy(p => p.ExtN1).Select(o => o.CodeValue),
                ComputerCaseType = _context.Dictionary.Where(p => p.CodeDict.Equals("CCASETYPE")).OrderBy(p => p.ExtN1).Select(o => o.CodeValue)
            };

            if (createComputerCaseViewModel.ComputerCase == null)
            {
                return NotFound();
            }
            return View(createComputerCaseViewModel);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,ComputerCase computerCase)
        {
            if (id != computerCase.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(computerCase);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComputerCaseExists(computerCase.Id))
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
            return View(computerCase);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var computerCase = await _context.ComputerCases
                .FirstOrDefaultAsync(m => m.Id == id);
            if (computerCase == null)
            {
                return NotFound();
            }

            return View(computerCase);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var computerCase = await _context.ComputerCases.FindAsync(id);
            var prod = await _context.Products.FindAsync(computerCase.ProductId);
            prod.Deleted = true;
            _context.Products.Update(prod);
            _context.ComputerCases.Remove(computerCase);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ComputerCaseExists(int id)
        {
            return _context.ComputerCases.Any(e => e.Id == id);
        }


        private string UploadedFile(CreateComputerCaseViewModel model)
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
