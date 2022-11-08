using System.ComponentModel.DataAnnotations;

namespace BurgerManiaApp.Data.Entities.Menu
{
    public class Drink
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(25)]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        [StringLength(200)]
        public string Description { get; set; }
        [Required]
        [StringLength(200)]
        public string ImageUrl { get; set; }
    }
}
