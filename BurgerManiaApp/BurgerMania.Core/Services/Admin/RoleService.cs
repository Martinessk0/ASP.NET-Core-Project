using BurgerManiaApp.Core.Constants;
using BurgerManiaApp.Core.Contracts.Admin;
using BurgerManiaApp.Core.Models.Admin;
using BurgerManiaApp.Infractructure.Data.Common;
using BurgerManiaApp.Infractructure.Data.Entities.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerManiaApp.Core.Services.Admin
{
    public class RoleService : IRoleService
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<User> userManager;

        public RoleService(RoleManager<IdentityRole> roleManager, 
            UserManager<User> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        public async Task<IdentityResult> AddRole(string userId,string role)
        {
            var user = await userManager.FindByIdAsync(userId);

            return await userManager.AddToRoleAsync(user, role);
        }

        public async Task<RoleModel> GetModel(string id)
        {
            var user = await userManager.FindByIdAsync(id);

            var result = new RoleModel()
            {
                Id = id,
                Email = user.Email,
                Name = $"{user.FirstName} {user.LastName}",
                Roles = this.GetRoles(),
            };

            return result;
        }

        public List<string> GetRoles()
        {
            var result = new List<string>();

            var roles = roleManager.Roles.ToList();

            foreach (var item in roles)
            {
                result.Add(item.Name);
            }

            return result;
        }

        public async Task<List<string>> GetRolesForThisUser(string userId)
        {
            var user = await userManager.FindByIdAsync(userId);

            var result = new List<string>();

            var roles = userManager.GetRolesAsync(user);

            foreach (var item in roles.Result)
            {
                result.Add(item);
            }

            return result;
        }
    }
}
