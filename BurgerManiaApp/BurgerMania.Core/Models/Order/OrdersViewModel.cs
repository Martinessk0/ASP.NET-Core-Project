using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerManiaApp.Core.Models.Order
{
    public class OrdersViewModel
    {
        public List<OrderServiceModel> Orders { get; set; } = new List<OrderServiceModel>();
    }
}
