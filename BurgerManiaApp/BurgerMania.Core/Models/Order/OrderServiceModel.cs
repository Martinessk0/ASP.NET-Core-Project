using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerManiaApp.Core.Models.Order
{
    public class OrderServiceModel
    {
        public int OrderId { get; set; }

        public string OrderStatusName { get; set; }

        public string OrderDate { get; set; } 
    }
}
