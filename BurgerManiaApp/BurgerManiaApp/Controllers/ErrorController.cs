using Microsoft.AspNetCore.Mvc;

namespace BurgerManiaApp.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
