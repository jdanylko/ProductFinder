using System.Collections.Generic;
using System.Linq;
using ProductFinder.Interfaces;
using ProductFinder.SearchBuilder;

namespace ProductFinder.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductDbContext _context;

        public ProductService(IProductDbContext context)
        {
            _context = context;
        }

        public List<Product> GetProducts()
        {
            return _context.Products.ToList();
        }

        public List<Product> GetProducts(ISearchParameters parameters)
        {
            var searchBuilder = new ProductBuilder(parameters);
            var predicate = searchBuilder.Build();

            return parameters.EmptyParameters
                ? _context.Products.ToList()
                : _context.Products
                    .Where(predicate)
                    .ToList();
        }
    }

}