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
        public string Email { get; set; }
        public string Name { get; set; }
        public List<string> Roles { get; set; }
    }
}
