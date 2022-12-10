using Microsoft.AspNetCore.Mvc;

namespace BurgerManiaApp.Areas.Deliverer.Controllers
{
    public class HomeController : DelivererController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
