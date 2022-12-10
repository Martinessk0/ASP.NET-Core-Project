using BurgerManiaApp.Core.Models.Admin;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerManiaApp.Core.Contracts.Admin
{
    public interface IRoleService
    {
        List<string> GetRoles();

        Task<List<string>> GetRolesForThisUser(string userId);

        Task<RoleModel> GetModel(string id);

        Task<IdentityResult> AddRole(string userId,string role);
    }
}
