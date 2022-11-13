using BurgerManiaApp.Data.Constants.Item;
using BurgerManiaApp.Data.Entities.Account;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BurgerManiaApp.Data.Entities.Item
{
    public class ShoppingSesson
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; } = null!;

        [ForeignKey(nameof(UserId))]
        public User User { get; set; } = null!;

        [Required]
        [Range(ShoppingSessonConstants.ShoppingSessonPriceMinRange, ShoppingSessonConstants.ShoppingSessonPriceMaxRange)]
        public decimal Total { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Required]
        public DateTime ModifiedAt { get; set; } = DateTime.Now;
    }
}
