using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ProductFinder.Extensions;
using ProductFinder.Interfaces;
using ProductFinder.Models;
using ProductFinder.SearchBuilder;

namespace ProductFinder.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _service;

        public HomeController(IProductService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            var searchParam = new SearchParameters();
            var model = new ProductViewModel
            {
                SearchParameter = searchParam,
                Products = _service.GetProducts().ToList()
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Index(ProductViewModel model)
        {
            model.Products = _service.GetProducts(model.SearchParameter).ToList();
            model.SearchParameter.ProcessorList = typeof(ProcessorType).ToSelectList<ProcessorType>(model.SearchParameter.ProcessorList);
            model.SearchParameter.RamList = typeof(RamCapacity).ToSelectList<RamCapacity>(model.SearchParameter.RamList);

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
