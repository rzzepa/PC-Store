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

        public DbSet<ShoppingCardItem> ShoppingCardItems { get; set; }

        
        public DbQuery<ProductSalesRaport> ProductSalesRaport { get; set; }

        public DbQuery<UsersSalesRaport> UsersSalesRaport { get; set; }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Query<ProductSalesRaport>().ToView("productsalesraport");
            builder.Query<UsersSalesRaport>().ToView("usersalesraport");

        }
    }
}
