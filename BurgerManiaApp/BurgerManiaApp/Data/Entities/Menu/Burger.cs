using System.ComponentModel.DataAnnotations;

namespace BurgerManiaApp.Data.Entities.Menu
{
    public class Burger
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        [StringLength(200)]
        public string Description { get; set; }
        [Required]
        [StringLength(200)]
        public string ImageUrl { get; set; }
        [Required]
        [Range(0.0,10.0)]
        public double Rating { get; set; }
        [Required]
        public bool IsActive { get; set; }

        public bool Tomato { get; set; }
        public bool Cucumber { get; set; }
        public bool Cheese { get; set; }
        public bool Egg { get; set; }
        public bool Chicken { get; set; }
        public bool Beef { get; set; }
        public bool Vegan { get; set; }
    }
}
