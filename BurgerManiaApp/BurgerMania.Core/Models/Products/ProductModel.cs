using BurgerManiaApp.Core.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BurgerManiaApp.Core.Models.Products
{
    public class ProductModel : IProductModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 10)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(500, MinimumLength = 20)]
        public string Description { get; set; } = null!;

        [Required]
        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [Display(Name = "Price")]
        [Range(0.00, 2000.00, ErrorMessage = "Price per item must be a positive number and less than {2} leva")]
        public decimal Price { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public IEnumerable<ProductCategoryModel> ProductCategories { get; set; } = new List<ProductCategoryModel>();
    }
}
