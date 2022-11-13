using BurgerManiaApp.Data.Constants.Item;
using System.ComponentModel.DataAnnotations;

namespace BurgerManiaApp.Data.Entities.Item
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(CategoryConstants.CategoryNameMaxLength)]
        public string Name { get; set; } = null!;
        [Required]
        [StringLength(CategoryConstants.CategoryDescMaxLenght)]
        public string Description { get; set; } = null!;
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
