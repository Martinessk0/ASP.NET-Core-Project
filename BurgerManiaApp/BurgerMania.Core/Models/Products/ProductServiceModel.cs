using static BurgerManiaApp.Core.Constants.ProductConstants;
using BurgerManiaApp.Core.Contracts;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace BurgerManiaApp.Core.Models.Products
{
    public class ProductServiceModel : IProductModel
    {
        public int Id { get; init; }

        [StringLength(NameMaxLength)]
        public string Name { get; init; } = null!;

        [Display(Name = "Image URL")]
        [StringLength(ImageURLMaxLength)]
        public string ImageUrl { get; init; } = null!;

        [Display(Name = "Price")]
        [Precision(PricePrecesion1,PricePrecesion2)]
        public decimal Price { get; init; }

    }
}
