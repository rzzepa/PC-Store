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
using PC_Store.Views.ViewModels;
using System.Web;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Hosting;
using PC_Store.Infrastructure;
using X.PagedList;

namespace PC_Store.Controllers
{
    public class ProcessorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly IWebHostEnvironment _webHostEnvironment;

        public IndexProcessorViewModel indexModel;

        public int PageSize = 4;

        public ProcessorsController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Processors
        /*public async Task<IActionResult> Index()
        {
            return View(await _context.Processors.ToListAsync());
        }*/

        public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            if (sortOrder == "producerASC") ViewBag.NameSortParam = "producerDESC";
            else if (sortOrder == "producerDESC") ViewBag.NameSortParam = "producerASC";
            else if (sortOrder == "lineASC") ViewBag.NameSortParam = "lineDESC";
            else if (sortOrder == "lineDESC") ViewBag.NameSortParam = "lineASC";
            else if (sortOrder is null) ViewBag.NameSortParam = "producerASC";

            var processors = from s in _context.Processors select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                processors = processors.Where(s => s.Producer.ToLower().Contains(searchString.ToLower()) || s.Line.ToLower().Contains(searchString.ToLower()) || s.SocketType.ToLower().Contains(searchString.ToLower())).OrderBy(s=>s.Producer);
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

        // GET: Processors/Details/5
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

            return View(processor);
        }

        // GET: Processors/Create
        public IActionResult Create(string Param)
        {
            CreateProcessorViewModel createProcessorViewModel = new CreateProcessorViewModel()
            {
                Producers = _context.Dictionary.Where(p => p.CodeDict.Equals("PRODPROCES")).Select(o => o.CodeValue),
                SocketTypes = _context.Dictionary.Where(p => (p.CodeDict.Equals("PROCSOCKET")) && ((p.Ext1.Equals(Param)) || String.IsNullOrEmpty(Param))).Select(o =>  o.CodeValue)
            };

            return View(createProcessorViewModel);
        }

        // POST: Processors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
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
                _context.Products.Add(product);
                await _context.SaveChangesAsync();

                model.Processor.ProductId = product.Id;
                _context.Add(model.Processor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
             }
                return View();
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


        // GET: Processors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var processor = await _context.Processors.FindAsync(id);
            if (processor == null)
            {
                return NotFound();
            }
            return View(processor);
        }

        // POST: Processors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Producer,Line,Cooling,SocketType,NumberOfCores,NumberOfThreads,ProcessorClockFrequency,TurboMaximumFrequency,IntegratedGraphics,UnlockedMultiplier,Architecture,TypesOfSupportedMemory")] Processor processor)
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

        // GET: Processors/Delete/5
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

        // POST: Processors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var processor = await _context.Processors.FindAsync(id);
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
    }
}
