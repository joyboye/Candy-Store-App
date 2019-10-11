using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Candy_Store_App2.Data;

namespace Candy_Store_App2.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Candy_Store_App2.Data.Candy> Candy { get; set; }
        public DbSet<Candy_Store_App2.Data.Manufacturer> Manufacturer { get; set; }
        public DbSet<Candy_Store_App2.Data.Store> Store { get; set; }
    }
}
