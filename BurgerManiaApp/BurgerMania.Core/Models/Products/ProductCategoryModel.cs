using static BurgerManiaApp.Core.Constants.ProductConstants;
using System.ComponentModel.DataAnnotations;

namespace BurgerManiaApp.Core.Models.Products
{
    public class ProductCategoryModel
    {
        public int Id { get; set; }

        [StringLength(CategoryNameMaxLength, MinimumLength = CategoryNameMinLength)]
        public string Name { get; set; } = null!;
    }
}
