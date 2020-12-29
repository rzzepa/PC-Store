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
using PC_Store.Infrastructure;
using PC_Store.Models;
using PC_Store.structure;
using PC_Store.ViewModels;

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
            if (model.FromDate == DateTime.MinValue)
            {
                model.FromDate = DateTime.Now.Date;
            }
            if (model.ToDate == DateTime.MinValue)
            {
                model.ToDate = DateTime.Now.Date.AddDays(1);
            }
            var salesraport = _context.ProductSalesRaport.Where(p => p.Date >= model.FromDate).Where(p => p.Date <= model.ToDate).ToList();
            if (salesraport.Count > 0)
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
            }
            else
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




        /*public async Task<IActionResult> ManagementOrders(int? pageNumber, string filter)
        {
            ViewData["Filter"] = String.IsNullOrEmpty(filter) ? "" : filter;
            ViewBag.dictitems = _context.Dictionary.Where(p => p.CodeDict == "ORDERSTATUS").Select(p => p.CodeValue);

            List<ManagmentOrdersViewModel> managmentOrdersViewModels = new List<ManagmentOrdersViewModel>();
            var item = _context.Orders.OrderByDescending(p => p.OrderPlaced);
            foreach(var it in item)
            {
                ManagmentOrdersViewModel managment = new ManagmentOrdersViewModel()
                {
                    Order = it,
                    StatusOrder = _context.Dictionary.Where(p => p.CodeDict.Equals("ORDERSTATUS")).Where(p => p.CodeValue.Equals(filter)).Select(p=>p.CodeItem).DefaultIfEmpty().ToString()
                };
                managmentOrdersViewModels.Add(managment);
            }
            if (filter != null)
            {
                *//*item = from or in _context.Orders
                           where or.StatusOrder==filter
                           orderby or.OrderPlaced descending
                           select new ManagmentOrdersViewModel
                           {
                               Order = or,
                               StatusOrder = _context.Dictionary.Where(p => p.CodeDict.Equals("ORDERSTATUS")).Where(p => p.CodeValue.Equals(filter)).Select(p => p.CodeItem).FirstOrDefault()
                           };*//*
            }*/

        public async Task<IActionResult> ManagementOrders(int? pageNumber, string filter, string searchString, string currentFilter, string fromDate, string toDate)
        {
            if (fromDate == null)
            {
                fromDate = DateTime.Now.Date.ToString();
            }
            if (toDate == null)
            {
                toDate = DateTime.Now.AddDays(1).Date.ToString();
            }
            ViewData["Filter"] = String.IsNullOrEmpty(filter) ? "" : filter;
            ViewData["fromDate"] = fromDate;
            ViewData["toDate"] = toDate;
            ViewData["pageNumber"] = pageNumber;
            ViewBag.dictitems = _context.Dictionary.Where(p => p.CodeDict == "ORDERSTATUS").Select(p => p.CodeValue);

            //var item = _context.Orders.OrderByDescending(p => p.OrderPlaced);

            var item = from order in _context.Orders
                     orderby order.OrderPlaced descending
                     select new ManagmentOrdersViewModel
                     {
                         Order = order,
                         StatusOrder = _context.Dictionary.Where(p => p.CodeDict == "ORDERSTATUS").Where(p => p.CodeItem.Equals(order.StatusOrder)).Select(p => p.CodeValue).FirstOrDefault()
                };

            if (filter != null)
            {
                //var it = _context.Dictionary.Where(p => p.CodeDict == "ORDERSTATUS").Where(p => p.CodeValue.Equals(filter)).Select(p => p.CodeItem).FirstOrDefault();
                item = item.Where(p => p.StatusOrder.Equals(filter));
            }


              item = item.Where(p => p.Order.OrderPlaced.Date >= DateTime.Parse(fromDate)).Where(p => p.Order.OrderPlaced.Date <= DateTime.Parse(toDate));


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
                item = item.Where(s => s.Order.City.ToLower().Contains(searchString) || s.Order.Country.ToLower().Contains(searchString) || s.Order.FirstName.ToLower().Contains(searchString) || s.Order.LastName.ToLower().Contains(searchString) || s.Order.AddressLine.ToLower().Contains(searchString));
            }

            int pageSize = 5;
            return View(await PaginatedList<ManagmentOrdersViewModel>.CreateAsync(item.AsNoTracking(), pageNumber ?? 1, pageSize));
        }



        public IActionResult DetailsOrder(int? id, int? pageNumber, string filter, string searchString, string currentFilter, string fromDate, string toDate)
        {
            ViewData["Filter"] = String.IsNullOrEmpty(filter) ? "" : filter;
            ViewData["fromDate"] = fromDate;
            ViewData["toDate"] = toDate;
            ViewData["PageNumber"]=pageNumber;
            ViewData["OrderId"] = id;
            ViewData["Status"] = _context.Dictionary.Where(p => p.CodeDict.Equals("ORDERSTATUS")).Where(p => p.CodeItem.Equals(_context.Orders.Where(p=>p.OrderId==id).Select(p=>p.StatusOrder).FirstOrDefault())).Select(p => p.CodeValue).FirstOrDefault();
            ViewBag.dictitems = _context.Dictionary.Where(p => p.CodeDict == "ORDERSTATUS").Select(p => p.CodeValue);
            if (id == null)
            {
                return NotFound();
            }
            var orderDetail =
           from detail in _context.OrderDetails
           join prod in _context.Products on detail.ProdId equals prod.Id
           where detail.OrderId == id
           select new OrderDetailViewModel { Product = prod, OrderDetail = detail };


            if (orderDetail == null)
            {
                return NotFound();
            }

            ViewData["CurrentFilter"] = currentFilter;



            return View(orderDetail);
        }

        [HttpPost]
        public IActionResult ChangeStatus(string status, int? id)
        {
            
            var order = _context.Orders.Where(p => p.OrderId.Equals(id)).FirstOrDefault();
            status = _context.Dictionary.Where(p => p.CodeDict == "ORDERSTATUS").Where(p => p.CodeValue.Equals(status)).Select(p => p.CodeItem).FirstOrDefault();
            order.StatusOrder = status;
            _context.Orders.Update(order);
            _context.SaveChanges();
            return RedirectToAction(nameof(ManagementOrders));
        }

    }
}

