using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PC_Store.Models;
using PC_Store.ViewModels;
using PC_Store.structure;
using PC_Store.Structure;

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
        public DbSet<UserPCCreator> userPCCreators { get; set; }


        public DbQuery<ProductSalesRaport> ProductSalesRaport { get; set; }

        public DbQuery<UserSalesRaport> UsersSalesRaport { get; set; }

        public DbQuery<MotherboardCreatorViewModel> motherboardCreatorLists{ get; set; }

        public DbQuery<ProcessorCreatorViewModel> processorCreatorLists { get; set; }

        public DbQuery<ComputerCaseCreatorViewModel> ComputerCaseCreatorLists { get; set; }

        public DbQuery<RamCreatorViewModel> ramCreatorLists { get; set; }

        public DbQuery<PowerSupplyCreatorViewModel> powerSupplyCreatorLists { get; set; }

        public DbQuery<GraphicCardCreatorViewModel> graphicCardCreatorLists { get; set; }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Query<ProductSalesRaport>().ToView("productsalesraport");
            builder.Query<UserSalesRaport>().ToView("usersalesraport");
            builder.Query<MotherboardCreatorViewModel>().ToView("motherboardlist");
            builder.Query<ProcessorCreatorViewModel>().ToView("processorlist");
            builder.Query<ComputerCaseCreatorViewModel>().ToView("computercaselist");
            builder.Query<RamCreatorViewModel>().ToView("ramlist");
            builder.Query<PowerSupplyCreatorViewModel>().ToView("powersupplylist");
            builder.Query<GraphicCardCreatorViewModel>().ToView("graphiccardlist");
        }
    }
}
