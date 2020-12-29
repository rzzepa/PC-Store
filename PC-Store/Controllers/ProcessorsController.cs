using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PC_Store.Data;
using PC_Store.Models;
using PC_Store.ViewModels;
using System.Web;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Hosting;
using PC_Store.Infrastructure;
using X.PagedList;
using Microsoft.AspNetCore.Identity;


namespace PC_Store.Controllers
{
    public class ProcessorsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public IndexProcessorViewModel indexModel;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly int pageSize;

        public ProcessorsController(ApplicationDbContext context, UserManager<IdentityUser> userManager, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _userManager = userManager;
            pageSize = _context.Dictionary.Where(p => p.CodeDict.Equals("CONFIG")).Where(p => p.CodeItem.Equals("PAGING")).Select(p => p.ExtN2).FirstOrDefault();
        }


        public async Task<IActionResult> Index(string sortOrder, string searchString, string currentFilter, int? pageNumber)
        {
            ViewData["ProdSortParm"] = String.IsNullOrEmpty(sortOrder) ? "producer_desc" : "";

            var processors = from s in _context.Processors select s;

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
                processors = processors.Where(s => s.Producer.ToLower().Contains(searchString.ToLower()) || s.Line.ToLower().Contains(searchString.ToLower()) || s.SocketType.ToLower().Contains(searchString.ToLower())).OrderBy(s=>s.Producer);
            }


            switch (sortOrder)
            {
                case "producer_desc":
                    processors = processors.OrderByDescending(s => s.Producer);
                    break;
                default:
                    processors = processors.OrderBy(s => s.Producer);
                    break;
            }

            return View(await PaginatedList<Processor>.CreateAsync(processors.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        public Task<IActionResult> ProcessorDetail(int? id)
        {
            var x = _context.Processors.Where(p => p.ProductId == id).Select(p => p.Id).FirstOrDefault();
            return Details(x);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var processor = await _context.Processors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (processor == null)
            {
                return NotFound();
            }

            return View("Details",processor);
        }

        public IActionResult ProcessorDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var processor =
            from PRo in _context.Processors
            join PR in _context.Products on PRo.ProductId equals PR.Id
            where PR.Act == true && PRo.ProductId==id
            select new ProcessorProduct
            {
                Processor = PRo,
                Product = PR
            };
            if (processor == null)
            {
                return NotFound();
            }
            ProcessorProduct processorProduct = processor.FirstOrDefault();

            return View(processorProduct);
        }


        public IActionResult Create()
        {
            CreateProcessorViewModel createProcessorViewModel = new CreateProcessorViewModel()
            {
                Producers = _context.Dictionary.Where(p => p.CodeDict.Equals("PRODPROCES")).Select(o => o.CodeValue),
                SocketTypes = _context.Dictionary.Where(p => p.CodeDict.Equals("PROCSOCKET")).Select(o => o.CodeValue)
            };

            return View(createProcessorViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateProcessorViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = UploadedFile(model);
                Product product = new Product();
                product.Picture = uniqueFileName;
                product.Name = model.Processor.Producer + " " + model.Processor.Line;
                product.Price = 0;
                product.Deleted = false;
                product.Act = false;
                product.InsertBy= _userManager.GetUserName(HttpContext.User);
                product.ModifyBy= _userManager.GetUserName(HttpContext.User);
                product.InsertDate= DateTime.Now;
                product.ModifyDate= DateTime.Now;
                product.ProductType = "PROCESSOR";
                product.Quantity = 0;
                _context.Products.Add(product);
                _context.SaveChanges();

                model.Processor.ProductId = product.Id;
                _context.Processors.Add(model.Processor);
                 _context.SaveChanges();
                return RedirectToAction(nameof(Index));
             }
            return RedirectToAction(nameof(Create));
        }

        private string UploadedFile(CreateProcessorViewModel model)
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


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CreateProcessorViewModel createProcessorViewModel = new CreateProcessorViewModel()
            {
                Processor= _context.Processors.Find(id),
                Producers = _context.Dictionary.Where(p => p.CodeDict.Equals("PRODPROCES")).Select(o => o.CodeValue),
                SocketTypes = _context.Dictionary.Where(p => p.CodeDict.Equals("PROCSOCKET")).Select(o => o.CodeValue)
            };
            if (createProcessorViewModel.Processor == null)
            {
                return NotFound();
            }
            return View(createProcessorViewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Processor processor)
        {
            if (id != processor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(processor);
                    await _context.SaveChangesAsync();

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProcessorExists(processor.Id))
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
            return View(processor);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var processor = await _context.Processors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (processor == null)
            {
                return NotFound();
            }

            return View(processor);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var processor = await _context.Processors.FindAsync(id);
            var prod = await _context.Products.FindAsync(processor.ProductId);
            prod.Deleted = true;
            _context.Products.Update(prod);
            _context.Processors.Remove(processor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProcessorExists(int id)
        {
            return _context.Processors.Any(e => e.Id == id);
        }

        public IEnumerable<Dictionary> GetProducers()
        {
            return _context.Dictionary.ToList().Where(o => o.CodeDict.Equals("PRODPROCES"));
        }

        public JsonResult GetSocketByProducer(string codeItem)
        {
            var item = _context.Dictionary.Where(x => x.Ext1 == codeItem).ToList();
            return Json(item, new Newtonsoft.Json.JsonSerializerSettings());
        }
    }
}
