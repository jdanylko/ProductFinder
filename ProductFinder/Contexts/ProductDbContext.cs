using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ProductFinder.Interfaces;
using ProductFinder.SearchBuilder;

namespace ProductFinder.Contexts
{
    public class ProductDbContext : DbContext, IProductDbContext
    {
        public ProductDbContext()
        { }

        public ProductDbContext(DbContextOptions<ProductDbContext> options)
            : base(options)
        { }
        
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EFProviders.InMemory;Trusted_Connection=True;ConnectRetryCount=0");
            }
        }

        public void SeedDatabase()
        {
            Products.AddRange(GetProducts());
            SaveChanges();
        }

        public List<Product> GetProducts()
        {
            return new List<Product>
            {
                new Product
                {
                    Id = 1,
                    Title = "Intel Big''n Processor", Price = 800.00, Processor = ProcessorType.IntelCorei7,
                    RAM = RamCapacity.TwelveGbAndUp, Rating = 5
                },
                new Product
                {
                    Id = 2,
                    Title = "Intel Medium Processor", Price = 600.00, Processor = ProcessorType.IntelCorei5,
                    RAM = RamCapacity.EightGb, Rating = 3
                },
                new Product
                {
                    Id = 3,
                    Title = "Intel Small Processor", Price = 350.00, Processor = ProcessorType.IntelCorei3,
                    RAM = RamCapacity.SixGb, Rating = 4
                },
                new Product
                {
                    Id = 4,
                    Title = "Intel Lite Processor", Price = 250.00, Processor = ProcessorType.IntelXeon,
                    RAM = RamCapacity.FourGb, Rating = 3
                },
                new Product
                {
                    Id = 5,
                    Title = "Intel Xtra Processor", Price = 150.00, Processor = ProcessorType.IntelCore2,
                    RAM = RamCapacity.FourGb, Rating = 4
                }
            };
        }
    }

}