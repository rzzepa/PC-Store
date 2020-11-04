using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PC_Store.Models;
using PC_Store.Models.ViewModels;

namespace PC_Store.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }



        public DbSet<Processor> Processors { get; set; }



        public DbSet<Dictionary> Dictionary { get; set; }

        public DbSet<GraphicCard> GraphicCards { get; set; }

        public DbSet<Motherboard> Motherboards { get; set; }
    }
}
