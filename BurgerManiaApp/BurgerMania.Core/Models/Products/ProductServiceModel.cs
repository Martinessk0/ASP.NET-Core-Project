using System.ComponentModel.DataAnnotations;

namespace BurgerManiaApp.Core.Models.Products
{
    public class ProductServiceModel
    {
        public int Id { get; init; }

        public string Name { get; init; } = null!;

        [Display(Name = "Image URL")]
        public string ImageUrl { get; init; } = null!;

        [Display(Name = "Price")]
        public decimal Price { get; init; }

    }
}
