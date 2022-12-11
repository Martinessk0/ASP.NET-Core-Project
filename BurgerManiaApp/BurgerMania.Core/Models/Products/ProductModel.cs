using static BurgerManiaApp.Core.Constants.ProductConstants;
using BurgerManiaApp.Core.Contracts;
using System.ComponentModel.DataAnnotations;

namespace BurgerManiaApp.Core.Models.Products
{
    public class ProductModel : IProductModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        public string Description { get; set; } = null!;

        [Required]
        [Display(Name = "Image URL")]
        [StringLength(ImageURLMaxLength)]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [Display(Name = "Price")]
        [Range(PriceMinRange, PriceMaxRange, ErrorMessage = "Price per item must be a positive number and less than {2} leva")]
        public decimal Price { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public IEnumerable<ProductCategoryModel> ProductCategories { get; set; } = new List<ProductCategoryModel>();
    }
}
