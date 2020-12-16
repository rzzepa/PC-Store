using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PC_Store.Data;
using PC_Store.structure;
using PC_Store.Views.ViewModels;

namespace PC_Store.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        
        public IActionResult Panel()
        {
            return View();
        }

        [Authorize]
        public IActionResult RaportView()
        {
            ViewBag.Mess = "";
            RaportViewModel model = new RaportViewModel
            {
                ToDate = DateTime.Now,
                FromDate = DateTime.Now
            };
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult GetProductSalesRaport(RaportViewModel model)
        {
            ViewBag.Mess = "";
            if(model.FromDate==DateTime.MinValue)
            {
                model.FromDate = DateTime.Now.Date;
            }
            if (model.ToDate == DateTime.MinValue)
            {
                model.ToDate = DateTime.Now.Date.AddDays(1);
            }
            var salesraport = _context.ProductSalesRaport.Where(p => p.Date >= model.FromDate).Where(p => p.Date <= model.ToDate).ToList();
            if(salesraport.Count>0)
            {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("ProductSalesRaport");
                var currentRow = 1;
                worksheet.ColumnWidth = 15;
                worksheet.Cell(currentRow, 1).Value = "Dzień";
                worksheet.Cell(currentRow, 2).Value = "Procesory";
                worksheet.Cell(currentRow, 3).Value = "Karty graficzne";
                worksheet.Cell(currentRow, 4).Value = "Płyty główne";
                worksheet.Cell(currentRow, 5).Value = "Obudowy";
                worksheet.Cell(currentRow, 6).Value = "Ramy";
                worksheet.Cell(currentRow, 7).Value = "Zasilacze";

                    foreach (var item in salesraport)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = item.Date;
                    worksheet.Cell(currentRow, 2).Value = item.Processors;
                    worksheet.Cell(currentRow, 3).Value = item.Graphiccards;
                    worksheet.Cell(currentRow, 4).Value = item.Motherboards;
                    worksheet.Cell(currentRow, 5).Value = item.Computercases;
                    worksheet.Cell(currentRow, 6).Value = item.Rams;
                    worksheet.Cell(currentRow, 7).Value = item.PowerSupplies;
                    }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content,
                        "application/vnd.openxmlformats-officedocument.spreads",
                        "RaportSale.xlsx");
                }
                }
            }else
            {
                ViewBag.Mess = "Nie znaleziono rekordów";
            }

            return View("RaportView");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult GetUserSalesRaport(RaportViewModel model)
        {
            ViewBag.Mess2 = "";
            if (model.FromDate == DateTime.MinValue)
            {
                model.FromDate = DateTime.Now.Date;
            }
            if (model.ToDate == DateTime.MinValue)
            {
                model.ToDate = DateTime.Now.Date.AddDays(1);
            }
            var salesraport = _context.UsersSalesRaport.Where(p => p.Date >= model.FromDate).Where(p => p.Date <= model.ToDate).ToList();
            if (salesraport.Count > 0)
            {
                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add("UserSalesRaport");
                    var currentRow = 1;
                    worksheet.ColumnWidth = 20;
                    worksheet.Cell(currentRow, 1).Value = "Dzień";
                    worksheet.Cell(currentRow, 2).Value = "Użytkownik";
                    worksheet.Cell(currentRow, 3).Value = "Nazwa produktu";
                    worksheet.Cell(currentRow, 4).Value = "Cena";
                    worksheet.Cell(currentRow, 5).Value = "Ilość";
                    worksheet.Cell(currentRow, 6).Value = "Cena łącznie";

                    foreach (var item in salesraport)
                    {
                        currentRow++;
                        worksheet.Cell(currentRow, 1).Value = item.Date;
                        worksheet.Cell(currentRow, 2).Value = item.User;
                        worksheet.Cell(currentRow, 3).Value = item.ProductName;
                        worksheet.Cell(currentRow, 4).Value = item.Price;
                        worksheet.Cell(currentRow, 5).Value = item.Quantity;
                        worksheet.Cell(currentRow, 6).Value = item.SumPrice;
                    }

                    using (var stream = new MemoryStream())
                    {
                        workbook.SaveAs(stream);
                        var content = stream.ToArray();
                        return File(content,
                            "application/vnd.openxmlformats-officedocument.spreads",
                            "RaportSale.xlsx");
                    }
                }
            }
            else
            {
                ViewBag.Mess2 = "Nie znaleziono rekordów";
            }

            return View("RaportView");
        }
    }
}