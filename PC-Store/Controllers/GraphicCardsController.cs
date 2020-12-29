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
    public class GraphicCardsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly int pageSize;

        public GraphicCardsController(ApplicationDbContext context, UserManager<IdentityUser> userManager, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _userManager = userManager;
            pageSize = _context.Dictionary.Where(p => p.CodeDict.Equals("CONFIG")).Where(p => p.CodeItem.Equals("PAGING")).Select(p => p.ExtN2).FirstOrDefault();
        }

        
        public async Task<IActionResult> Index(string sortOrder, string searchString, string currentFilter, int? pageNumber)
        {
            ViewData["ProdSortParm"] = String.IsNullOrEmpty(sortOrder) ? "Prod_desc" : "";
            ViewData["RamAmountSortParm"] = sortOrder == "ram_asc" ? "ram_desc" : "ram_asc";

            var graphiccard = from s in _context.GraphicCards select s;

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
                graphiccard = graphiccard.Where(s => s.Producer.ToLower().Contains(searchString) || s.ProducerChipset.ToLower().Contains(searchString));
            }

            switch (sortOrder)
            {
                case "Prod_desc":
                    graphiccard = graphiccard.OrderByDescending(s => s.Producer);
                    break;
                case "ram_asc":
                    graphiccard = graphiccard.OrderBy(s => s.AmountOfRAM);
                    break;
                case "ram_desc":
                    graphiccard = graphiccard.OrderByDescending(s => s.AmountOfRAM);
                    break;
                default:
                    graphiccard = graphiccard.OrderBy(s => s.Producer);
                    break;
            }

            return View(await PaginatedList<GraphicCard>.CreateAsync(graphiccard.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        public Task<IActionResult> GraphicCardDetail(int? id)
        {
            var x = _context.GraphicCards.Where(p => p.ProductId == id).Select(p => p.Id).FirstOrDefault();
            return Details(x);
        }

        // GET: GraphicCards/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var graphicCard = await _context.GraphicCards
                .FirstOrDefaultAsync(m => m.Id == id);
            if (graphicCard == null)
            {
                return NotFound();
            }

            return View("Details",graphicCard);
        }

        public IActionResult GraphiccardDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var processor =
            from GC in _context.GraphicCards
            join PR in _context.Products on GC.ProductId equals PR.Id
            where PR.Act == true && GC.ProductId == id
            select new GraphicCardProduct
            {
                GraphicCard = GC,
                Product = PR
            };
            if (processor == null)
            {
                return NotFound();
            }
            GraphicCardProduct graphicCardProduct = processor.FirstOrDefault();

            return View(graphicCardProduct);
        }

        public IActionResult Create()
        {
            CreateGraphicCardViewModel createGraphicCardViewModel = new CreateGraphicCardViewModel()
            {
                Producers= _context.Dictionary.Where(p => p.CodeDict.Equals("PRODGRAPHCARD")).OrderBy(p=>p.ExtN1).Select(o => o.CodeValue),
                ChipsetProducers = _context.Dictionary.Where(p => p.CodeDict.Equals("PRODCHIPSETGC")).OrderBy(p => p.ExtN1).Select(o => o.CodeValue),
                CoolingTypes = _context.Dictionary.Where(p => p.CodeDict.Equals("GCCOOLINGTYPE")).OrderBy(p => p.ExtN1).Select(o => o.CodeValue),
                Resolution = _context.Dictionary.Where(p => p.CodeDict.Equals("GCRESOLUTION")).OrderBy(p => p.ExtN1).Select(o => o.CodeValue),
                MemoryTypes = _context.Dictionary.Where(p => p.CodeDict.Equals("GCMEMORYTYPE")).OrderBy(p => p.ExtN1).Select(o => o.CodeValue)
            };

            return View(createGraphicCardViewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateGraphicCardViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = UploadedFile(model);
                Product product = new Product();
                product.Picture = uniqueFileName;
                product.Name = model.GraphicCard.Producer + " " + model.GraphicCard.ProducerCode + " " + model.GraphicCard.ProducerChipset;
                product.Price = 0;
                product.Deleted = false;
                product.InsertBy = _userManager.GetUserName(HttpContext.User);
                product.ModifyBy = _userManager.GetUserName(HttpContext.User);
                product.InsertDate = DateTime.Now;
                product.ModifyDate = DateTime.Now;
                product.ProductType = "GRAPHICSCARD";
                product.Quantity = 0;
                product.Act = false;
                _context.Products.Add(product);
                await _context.SaveChangesAsync();

                model.GraphicCard.ProductId = product.Id;
                _context.GraphicCards.Add(model.GraphicCard);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }
            return RedirectToAction(nameof(Create));
        }

        private string UploadedFile(CreateGraphicCardViewModel model)
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

            CreateGraphicCardViewModel createGraphicCardViewModel = new CreateGraphicCardViewModel()
            {
                GraphicCard= await _context.GraphicCards.FindAsync(id),
                Producers = _context.Dictionary.Where(p => p.CodeDict.Equals("PRODGRAPHCARD")).Select(o => o.CodeValue),
                ChipsetProducers = _context.Dictionary.Where(p => p.CodeDict.Equals("PRODCHIPSETGC")).Select(o => o.CodeValue),
                CoolingTypes = _context.Dictionary.Where(p => p.CodeDict.Equals("GCCOOLINGTYPE")).Select(o => o.CodeValue),
                Resolution = _context.Dictionary.Where(p => p.CodeDict.Equals("GCRESOLUTION")).Select(o => o.CodeValue),
                MemoryTypes = _context.Dictionary.Where(p => p.CodeDict.Equals("GCMEMORYTYPE")).OrderBy(p => p.ExtN1).Select(o => o.CodeValue)
            };
            if (createGraphicCardViewModel.GraphicCard == null)
            {
                return NotFound();
            }
            return View(createGraphicCardViewModel);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, GraphicCard graphicCard)
        {
            if (id != graphicCard.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(graphicCard);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GraphicCardExists(graphicCard.Id))
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
            return View(graphicCard);
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var graphicCard = await _context.GraphicCards
                .FirstOrDefaultAsync(m => m.Id == id);
            if (graphicCard == null)
            {
                return NotFound();
            }

            return View(graphicCard);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var graphicCard = await _context.GraphicCards.FindAsync(id);
            var prod = await _context.Products.FindAsync(graphicCard.ProductId);
            prod.Deleted = true;
            _context.Products.Update(prod);
            _context.GraphicCards.Remove(graphicCard);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GraphicCardExists(int id)
        {
            return _context.GraphicCards.Any(e => e.Id == id);
        }
    }
}
