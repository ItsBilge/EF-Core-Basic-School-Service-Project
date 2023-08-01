using E_Ticaret_Practice.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Ticaret_Practice
{
    public class ETicaretContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = LAPTOP-3AOA7VRF\\SQLEXPRESS; database = ETicaterEFPractice ; trusted_connection = true; TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CostumerProduct>().HasKey(cp => new { cp.ProductID, cp.CostumerID });
        }
        public DbSet<Product> products { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Costumer> costumers { get; set; }
        public DbSet<CostumerProduct> costumerProducts { get; set; }
    }
}
