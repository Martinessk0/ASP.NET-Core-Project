using BurgerManiaApp.Data.Constants.Item;
using BurgerManiaApp.Data.Entities.Account;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BurgerManiaApp.Data.Entities.Item
{
    public class Product
    {
        [Key]   
        public int Id { get; set; }

        [Required]
        [StringLength(ProductConstants.ProductNameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(ProductConstants.ProductDescMaxLength)]
        public string Description { get; set; } = null!;

        [Required]
        [Range(ProductConstants.ProductMinPrice, ProductConstants.ProductMaxPrice)]
        public decimal Price { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        [StringLength(ProductConstants.ProductImageMaxLength)]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [Range(ProductConstants.ProductMinRating, ProductConstants.ProductMaxRating)]
        public double Rating { get; set; }

        [Required]
        public bool IsActive { get; set; } = true;

        [Required]
        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Required]
        public DateTime ModifiedAt { get; set; } = DateTime.Now;

        [Required]
        public string CreatedById { get; set; } = null!;

        [ForeignKey(nameof(CreatedById))]
        public User CreatedBy { get; set; } = null!;


    }
}
