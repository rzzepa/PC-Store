﻿using System;
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
using PC_Store.Models;
using PC_Store.Views.ViewModels;

namespace PC_Store.Controllers
{
    public class GraphicCardsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public GraphicCardsController(ApplicationDbContext context, UserManager<IdentityUser> userManager, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _userManager = userManager;
        }

        // GET: GraphicCards
        public async Task<IActionResult> Index()
        {
            return View(await _context.GraphicCards.ToListAsync());
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

        public async Task<IActionResult> GraphiccardDetails(int? id)
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
                graphicCard = GC,
                Product = PR
            };
            if (processor == null)
            {
                return NotFound();
            }
            GraphicCardProduct graphicCardProduct = processor.FirstOrDefault();

            return View(graphicCardProduct);
        }

        // GET: GraphicCards/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GraphicCards/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
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
                product.Act = false;
                _context.Products.Add(product);
                await _context.SaveChangesAsync();

                model.GraphicCard.ProductId = product.Id;
                _context.GraphicCards.Add(model.GraphicCard);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }
            return View();
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

        // GET: GraphicCards/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var graphicCard = await _context.GraphicCards.FindAsync(id);
            if (graphicCard == null)
            {
                return NotFound();
            }
            return View(graphicCard);
        }

        // POST: GraphicCards/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Producer,ProducerCode,ProducerChipset,CoreClock,CoreClockBoost,ConnectorType,Resolution,RecommendedPSUPower,AmountOfRAM,TypeOfRAM,DataBus,MemoryClock,CoolingType,NumberOfFans,DSub,DisplayPort,HDMI,DVI")] GraphicCard graphicCard)
        {
            if (id != graphicCard.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    /*var item = _context.Products.Where(p => p.Id == graphicCard.ProductId).SingleOrDefault();
                    Product product = item;
                    product.ModifyBy = _userManager.GetUserName(HttpContext.User);
                    product.ModifyDate = product.ModifyDate = DateTime.Now;

                    _context.Update(product);*/
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

        // GET: GraphicCards/Delete/5
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

        // POST: GraphicCards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var graphicCard = await _context.GraphicCards.FindAsync(id);
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
