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
using PC_Store.Models;
using PC_Store.Views.ViewModels;

namespace PC_Store.Controllers
{
    public class MotherboardsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly UserManager<IdentityUser> _userManager;

        public MotherboardsController(ApplicationDbContext context, UserManager<IdentityUser> userManager, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _userManager = userManager;
        }

        // GET: Motherboards
        public async Task<IActionResult> Index()
        {
            return View(await _context.Motherboards.ToListAsync());
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

        // GET: Motherboards/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Motherboards/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
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
                product.Act = false;
                _context.Products.Add(product);

                 _context.SaveChanges();

                model.Motherboard.ProductId = product.Id;
                _context.Add(model.Motherboard);

                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: Motherboards/Edit/5
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

        // POST: Motherboards/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Producer,ProducerCode,Standard,Chipset,SocketType,Technologies")] Motherboard motherboard)
        {
            if (id != motherboard.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    /*var item = _context.Products.Where(p => p.Id == motherboard.ProductId).SingleOrDefault();
                    Product product= item;
                    product.ModifyBy= _userManager.GetUserName(HttpContext.User);
                    product.ModifyDate= product.ModifyDate = DateTime.Now;
                    
                    _context.Update(product);*/
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
