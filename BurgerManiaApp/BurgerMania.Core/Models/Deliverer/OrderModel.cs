using System.ComponentModel.DataAnnotations;
using static BurgerManiaApp.Core.Constants.OrderConstants;

namespace BurgerManiaApp.Core.Models.Deliverer
{
    public class OrderModel
    {
        public int OrderId { get; set; }

        [StringLength(OrderStatusNameMaxLength,MinimumLength = OrderStatusNameMinLength)]
        public string OrderStatusName { get; set; }

        public int OrderStatusId { get; set; }

        public string OrderDate { get; set; }
    }
}
