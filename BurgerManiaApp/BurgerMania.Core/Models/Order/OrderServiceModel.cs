using System.ComponentModel.DataAnnotations;
using static BurgerManiaApp.Core.Constants.OrderConstants;

namespace BurgerManiaApp.Core.Models.Order
{
    public class OrderServiceModel
    {
        public int OrderId { get; set; }

        [StringLength(OrderStatusNameMaxLength, MinimumLength = OrderStatusNameMinLength)]
        public string OrderStatusName { get; set; } = null!;

        public string OrderDate { get; set; } = null!;
    }
}
