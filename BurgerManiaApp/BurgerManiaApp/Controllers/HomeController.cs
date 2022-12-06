using BurgerManiaApp.Core.Contracts;
using BurgerManiaApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using static BurgerManiaApp.Areas.Admin.Constants.AdminConstants;

namespace BurgerManiaApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService productService;

        public HomeController(ILogger<HomeController> logger, IProductService productService)
        {
            _logger = logger;
            this.productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            if (this.User.IsInRole(AdminRoleName))
            {
                return RedirectToAction("Index", "Home", new { area = "Admin" });
            }

            var model = await productService.LastThreeBurgers();

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}