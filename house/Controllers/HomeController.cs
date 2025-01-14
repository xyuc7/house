using house.Interfaces;
using house.Models;
using house.Services.Home;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;




namespace house.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductServices _productServices;

        public HomeController(ILogger<HomeController> logger, IProductServices productServices)
        {
            _logger = logger;
            _productServices = productServices;
        }

        public IActionResult Index()
        {
            return View();
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

        public async Task<IActionResult> Products()
        {
            //var productdata = await _productServices.GetAllAsync();

            return View();

        }
        public async Task<IActionResult> Customers()
        {
            return View();

        }
        public async Task<IActionResult> Employees()
        {
            return View();

        }
        public async Task<IActionResult> Orders()
        {
            return View();

        }


    }
}
