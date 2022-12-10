using BurgerManiaApp.Core.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerManiaApp.Core.Models.Admin
{
    public class RoleModel
    {
        public string Id { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Name { get; set; } = null!;

        public List<string> Roles { get; set; } = new List<string>();

        public string Role { get; set; }
    }
}
