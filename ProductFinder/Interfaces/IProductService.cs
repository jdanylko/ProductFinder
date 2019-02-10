using System.Collections.Generic;
using ProductFinder.SearchBuilder;

namespace ProductFinder.Interfaces
{
    public interface IProductService
    {
        List<Product> GetProducts(ISearchParameters parameters);
        List<Product> GetProducts();
    }
}