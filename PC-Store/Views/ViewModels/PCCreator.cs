using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PC_Store.Data;
using PC_Store.Models;
using System;
using System.Linq;

namespace PC_Store.Views.ViewModels
{
    public class PCCreator
    {
        private readonly ApplicationDbContext _context;

        public PCCreator(ApplicationDbContext context)
        {
            _context = context;
        }

        public string PcCreatorId { get; set; }

        public Product ComputerCaseProduct { get; set; }

        public Product ProcessorProduct { get; set; }

        public Product RamProduct { get; set; }

        public Product GraphicCardProduct { get; set; }

        public Product MotherboardProduct { get; set; }

        public Product PowerSupplyProduct { get; set; }

        public DateTime ModifyDate { get; set; }


        public static PCCreator CreatePcCreator(IServiceProvider service)
        {
            ISession session = service.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;

            var context = service.GetService<ApplicationDbContext>();
            string CreatorId = session.GetString("CreatorId") ?? Guid.NewGuid().ToString();

            session.SetString("CreatorId", CreatorId);

            return new PCCreator(context) { PcCreatorId = CreatorId };
        }

        public PCCreator getPcCreator(string Id)
        {
            return _context.pCCreators.Where(p => p.PcCreatorId == Id).
                Include(s => s.MotherboardProduct).
                Include(s => s.GraphicCardProduct).
                Include(s => s.PowerSupplyProduct).
                Include(s => s.ProcessorProduct).
                Include(s => s.RamProduct).
                Include(s => s.ComputerCaseProduct).
                SingleOrDefault();
        }

        public void AddToCreator(int? Id)
        {
            Product product = null;
            product = _context.Products.Find(Id);
            PCCreator pCCreator = getPcCreator(PcCreatorId);

            if (product.ProductType == "PROCESSOR")
            {
                pCCreator.ProcessorProduct = product;
            }
            else if (product.ProductType == "MOTHERBOARD")
            {
                pCCreator.MotherboardProduct = product;
            }
            else if (product.ProductType == "COMPUTERCASE")
            {
                pCCreator.ComputerCaseProduct = product;
            }
            else if (product.ProductType == "GRAPHICSCARD")
            {
                pCCreator.GraphicCardProduct = product;
            }
            else if (product.ProductType == "RAMMEMORY")
            {
                pCCreator.RamProduct = product;
            }
            else if (product.ProductType == "POWERSUPPLY")
            {
                pCCreator.PowerSupplyProduct = product;
            }

                pCCreator.ModifyDate = DateTime.Now;
                _context.pCCreators.Update(pCCreator);

            _context.SaveChanges();
        }


        public void RemoveFromCreator(int? Id)
        {
            Product product = null;
            product = _context.Products.Find(Id);
            PCCreator pCCreator = getPcCreator(PcCreatorId);
            

            if (product.ProductType == "PROCESSOR")
            {
                pCCreator.ProcessorProduct = null;
            }
            else if (product.ProductType == "MOTHERBOARD")
            {
                pCCreator.MotherboardProduct = null;
            }
            else if (product.ProductType == "COMPUTERCASE")
            {
                pCCreator.ComputerCaseProduct = null;
            }
            else if (product.ProductType == "GRAPHICSCARD")
            {
                pCCreator.GraphicCardProduct = null;
            }
            else if (product.ProductType == "RAMMEMORY")
            {
                pCCreator.RamProduct = null;
            }
            else if (product.ProductType == "POWERSUPPLY")
            {
                pCCreator.PowerSupplyProduct = null;
            }

                _context.pCCreators.Update(pCCreator);

            _context.SaveChanges();
        }

    }
}
