using static BurgerManiaApp.Core.Constants.ProductConstants;
using BurgerManiaApp.Core.Contracts;
using System.ComponentModel.DataAnnotations;

namespace BurgerManiaApp.Core.Models.Products
{
    public class ProductHomePageModel : IProductModel
    {
        public int Id { get; set; }

        [StringLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        [StringLength(ImageURLMaxLength)]
        public string ImageUrl { get; set; } = null!;
    }
}
