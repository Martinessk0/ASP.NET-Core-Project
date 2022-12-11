using static BurgerManiaApp.Infrastructure.Data.Constants.OrderStatusConstants;
using System.ComponentModel.DataAnnotations;

namespace BurgerManiaApp.Infrastructure.Data.Entities
{
    public class OrderStatus
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
