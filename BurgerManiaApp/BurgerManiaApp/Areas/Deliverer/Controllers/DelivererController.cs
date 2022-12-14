using System.Diagnostics;
using BurgerManiaApp.Models;
using static BurgerManiaApp.Areas.Deliverer.Constants.DelivererConstants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace BurgerManiaApp.Areas.Deliverer.Controllers
{
    [Area(AreaName)]
    [Authorize(Roles = DelivererRoleName)]
    public class DelivererController : Controller
    {
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
