using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Umbrella.Web.Models;
using Umbrella.Web.Models.Catalog;
using Umbrella.Web.ViewModels;

namespace Umbrella.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public IEnumerable<ProductModel> ProductList { get; set; } = new List<ProductModel>();
        private readonly ICatalogService _catalogService;

        public HomeController(ICatalogService service, ILogger<HomeController> logger)
        {
            _logger = logger;
            this._catalogService = service;
        }

        public async Task<IActionResult> Index( int? PageNumber=1 , int? PageSize=10)
        {

            var  results =await  _catalogService.GetProducts();
            ProductList = results.Products;
            HomeIndexViewModel homeIndexViewModel = new HomeIndexViewModel();
            if (ProductList.Count() == 0)
                return RedirectToPage("Error");

            homeIndexViewModel.Products = ProductList.ToList();


            return View(homeIndexViewModel);
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
