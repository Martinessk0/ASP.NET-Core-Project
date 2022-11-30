using BurgerManiaApp.Core.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BurgerManiaApp.Controllers
{
    [Authorize]
    public class AdministratorController : Controller
    {
        private readonly IAdministratorService _administratorService;

        public AdministratorController(IAdministratorService administratorService)
        {
            _administratorService = administratorService;
        }

        [HttpGet]
        public async Task<IActionResult> Become()
        {
            return View();
        }
    }
}
