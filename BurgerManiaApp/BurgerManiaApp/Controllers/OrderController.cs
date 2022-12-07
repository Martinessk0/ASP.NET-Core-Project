using Microsoft.AspNetCore.Mvc;

namespace BurgerManiaApp.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
