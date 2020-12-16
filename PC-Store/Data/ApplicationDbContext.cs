using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PC_Store.Models;
using PC_Store.Models.ViewModels;
using PC_Store.structure;
using PC_Store.Views.ViewModels;

namespace PC_Store.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }



        public DbSet<Processor> Processors { get; set; }

        public DbSet<Order> Orders { get; set;}

        public DbSet<OrderDetail> OrderDetails { get; set; }

        public DbSet<Dictionary> Dictionary { get; set; }

        public DbSet<GraphicCard> GraphicCards { get; set; }

        public DbSet<Motherboard> Motherboards { get; set; }

        public DbSet<ComputerCase> ComputerCases { get; set; }

        public DbSet<Ram> Rams { get; set; }

        public DbSet<PowerSupply> PowerSupplies { get; set; }

        public DbSet<ShoppingCardItem> ShoppingCardItems { get; set; }

        public DbSet<PCCreator> pCCreators{ get; set; }


        public DbQuery<ProductSalesRaport> ProductSalesRaport { get; set; }

        public DbQuery<UsersSalesRaport> UsersSalesRaport { get; set; }

        public DbQuery<MotherboardCreatorList> motherboardCreatorLists{ get; set; }

        public DbQuery<ProcessorCreatorList> processorCreatorLists { get; set; }

        public DbQuery<ComputerCaseCreatorList> ComputerCaseCreatorLists { get; set; }

        public DbQuery<RamCreatorList> ramCreatorLists { get; set; }

        public DbQuery<PowerSupplyCreatorList> powerSupplyCreatorLists { get; set; }

        public DbQuery<GraphicCardCreatorList> graphicCardCreatorLists { get; set; }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Query<ProductSalesRaport>().ToView("productsalesraport");
            builder.Query<UsersSalesRaport>().ToView("usersalesraport");
            builder.Query<MotherboardCreatorList>().ToView("motherboardlist");
            builder.Query<ProcessorCreatorList>().ToView("processorlist");
            builder.Query<ComputerCaseCreatorList>().ToView("computercaselist");
            builder.Query<RamCreatorList>().ToView("ramlist");
            builder.Query<PowerSupplyCreatorList>().ToView("powersupplylist");
            builder.Query<GraphicCardCreatorList>().ToView("graphiccardlist");
        }
    }
}
