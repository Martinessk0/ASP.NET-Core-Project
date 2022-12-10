using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerManiaApp.Core.Models.Deliverer
{
    public class OrderModel
    {
        public int OrderId { get; set; }

        public string OrderStatusName { get; set; }

        public int OrderStatusId { get; set; }

        public string OrderDate { get; set; }
    }
}
