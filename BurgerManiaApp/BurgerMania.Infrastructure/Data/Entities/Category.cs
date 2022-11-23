using System.ComponentModel.DataAnnotations;

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
        [StringLength(50)]
        public string Name { get; set; } = null!;

        public List<Product> Products { get; set; }
    }
}