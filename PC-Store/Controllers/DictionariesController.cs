using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PC_Store.Data;
using PC_Store.Infrastructure;
using PC_Store.Models;
using PC_Store.Views.ViewModels;

namespace PC_Store.Controllers
{
    public class DictionariesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DictionariesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Dictionaries
        public async Task<IActionResult> Index(string sortOrder, string searchString, string currentFilter, int? pageNumber, string filter)
        {
            ViewData["DictSortParm"] = String.IsNullOrEmpty(sortOrder) ? "DICT_desc" : "";
            ViewData["Filter"] =  String.IsNullOrEmpty(filter) ? "" : filter;
            ViewBag.dictitems = _context.Dictionary.Select(p => p.CodeDict).Distinct();
            
            var dict = from s in _context.Dictionary select s;

            if (filter != null)
                dict=dict.Where(p => p.CodeDict.Equals(filter));

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
                dict = dict.Where(s => s.CodeDict.Contains(searchString) || s.CodeItem.Contains(searchString) || s.CodeValue.Contains(searchString));
            }

            switch (sortOrder)
            {
            case "DICT_desc":
                dict = dict.OrderByDescending(s => s.CodeDict).ThenBy(s=>s.ExtN1);
                break;
            default:
                dict = dict.OrderBy(s => s.CodeDict).ThenBy(s => s.ExtN1);
                break;
            }
            int pageSize = 15;
            return View(await PaginatedList<Dictionary>.CreateAsync(dict.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        // GET: Dictionaries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dictionary = await _context.Dictionary
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dictionary == null)
            {
                return NotFound();
            }

            return View(dictionary);
        }

        // GET: Dictionaries/Create
        public IActionResult Create()
        {

            return View();
        }

        // POST: Dictionaries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Dictionary dictionary)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dictionary);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dictionary);
        }

        // GET: Dictionaries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dictionary = await _context.Dictionary.FindAsync(id);
            if (dictionary == null)
            {
                return NotFound();
            }
            return View(dictionary);
        }

        // POST: Dictionaries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CodeItem,CodeDict,CodeValue,Ext1,Ext2,ExtN1,ExtN2")] Dictionary dictionary)
        {
            if (id != dictionary.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dictionary);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DictionaryExists(dictionary.Id))
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
            return View(dictionary);
        }

        // GET: Dictionaries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dictionary = await _context.Dictionary
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dictionary == null)
            {
                return NotFound();
            }

            return View(dictionary);
        }

        // POST: Dictionaries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dictionary = await _context.Dictionary.FindAsync(id);
            _context.Dictionary.Remove(dictionary);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DictionaryExists(int id)
        {
            return _context.Dictionary.Any(e => e.Id == id);
        }
    }
}
