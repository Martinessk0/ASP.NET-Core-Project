using System.ComponentModel.DataAnnotations;
using static BurgerManiaApp.Core.Constants.ProductConstants;

namespace BurgerManiaApp.Core.Models.Cart
{
    public class ShoppingCartItemDto
    {
        public int Id { get; set; }

        [Range(PriceMinRange,PriceMaxRange)]
        public decimal Price { get; set; }

        [StringLength(ImageURLMaxLength,MinimumLength = ImageURLMinLength)]
        public string ImageUrl { get; set; } = null!;

        public int Quantity { get; set; }

        public int ShoppingCartId { get; set; }

        [StringLength(NameMaxLength,MinimumLength = NameMinLength)]
        public string ProductName { get; set; } = null!;

        [StringLength(CategoryNameMaxLength,MinimumLength = CategoryNameMinLength)]
        public string ProductCategory { get; set; } = null!;
    }
}
