using static BurgerManiaApp.Core.Constants.ProductConstants;
using System.ComponentModel.DataAnnotations;

namespace BurgerManiaApp.Core.Models.Products
{
    public class ProductDetailsModel : ProductServiceModel
    {
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        public string Description { get; set; } = null!;

        public string Category { get; set; } = null!;
    }
}
