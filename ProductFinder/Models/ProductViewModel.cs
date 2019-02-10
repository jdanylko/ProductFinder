using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProductFinder.Extensions;
using ProductFinder.SearchBuilder;

namespace ProductFinder.Models
{
    public class ProductViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public SearchParameters SearchParameter { get; set; }
    }
}