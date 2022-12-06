using BurgerManiaApp.Core.Contracts.Admin;
using Microsoft.AspNetCore.Mvc;

namespace BurgerManiaApp.Areas.Admin.Controllers
{
    public class UserController : AdminController
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        public async Task<IActionResult> All()
        {
            var model = await userService.All();

            return View(model);
        }
    }
}
