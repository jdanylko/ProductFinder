using Microsoft.EntityFrameworkCore;
using ProductFinder.SearchBuilder;

namespace ProductFinder.Interfaces
{
    public interface IProductDbContext
    {
        DbSet<Product> Products { get; set; }
    }
}