using BurgerManiaApp.Core.Contracts.Admin;
using BurgerManiaApp.Infractructure.Data.Entities.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BurgerManiaApp.Areas.Admin.Controllers
{
    public class RoleController : AdminController
    {
        private readonly IRoleService roleService;

        public RoleController(IRoleService roleService)
        {
            this.roleService = roleService;
        }

        public IActionResult AddRole(string userEmail)
        {
            var model = roleService.GetRoles();

            return View(model);
        }
    }
}
