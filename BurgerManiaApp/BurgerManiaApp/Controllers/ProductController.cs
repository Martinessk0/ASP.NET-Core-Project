using Microsoft.AspNetCore.Mvc;

namespace BurgerManiaApp.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
