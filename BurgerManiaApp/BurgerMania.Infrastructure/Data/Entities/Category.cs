using System.ComponentModel.DataAnnotations;
using static BurgerManiaApp.Infrastructure.Data.Constants.CategoryConstants;

namespace BurgerManiaApp.Infrastructure.Data.Entities
{
    public class Category
    {
        public Category()
        {
            Products = new List<Product>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        public List<Product> Products { get; set; }
    }
}