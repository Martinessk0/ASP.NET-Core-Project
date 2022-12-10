using BurgerManiaApp.Core.Contracts.Admin;
using BurgerManiaApp.Core.Models.Admin;
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

        public async Task<IActionResult> AddRole(string id)
        {
            var result =await roleService.GetModel(id);
            var model = new RoleModel()
            {
                Email = result.Email,
                Name = result.Name,
                Roles = result.Roles.ToList(),
            };

            return View(model);
        }

        public async Task<IActionResult> AddRoleToUser(string id,string role)
        {
            await roleService.AddRole(id,role);

            return RedirectToAction("Index", "Home");
        }
    }
}
