using BurgerManiaApp.Core.Contracts.Admin;
using BurgerManiaApp.Infractructure.Data.Common;
using Microsoft.AspNetCore.Identity;
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
        private readonly IRepository repo;

        public RoleService(RoleManager<IdentityRole> roleManager, IRepository repo)
        {
            this.roleManager = roleManager;
            this.repo = repo;
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
    }
}
