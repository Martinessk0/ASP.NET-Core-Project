using BurgerManiaApp.Core.Models.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerManiaApp.Core.Models.Admin
{
    public class UsersViewModel
    {
        public List<UserServiceModel> Users { get; set; } = new List<UserServiceModel>();
    }
}
