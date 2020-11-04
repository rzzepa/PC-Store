using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PC_Store.Data;
using PC_Store.Models.ViewModels;

namespace PC_Store.Controllers
{
    public class GraphicCardsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GraphicCardsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GraphicCards
        public async Task<IActionResult> Index()
        {
            return View(await _context.GraphicCards.ToListAsync());
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

            return View(graphicCard);
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
        public async Task<IActionResult> Create([Bind("Id,Producer,ProducerCode,ProducerChipset,CoreClock,CoreClockBoost,ConnectorType,Resolution,RecommendedPSUPower,AmountOfRAM,TypeOfRAM,DataBus,MemoryClock,CoolingType,NumberOfFans,DSub,DisplayPort,HDMI,DVI")] GraphicCard graphicCard)
        {
            if (ModelState.IsValid)
            {
                _context.Add(graphicCard);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(graphicCard);
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
