using BurgerManiaApp.Core.Contracts;

namespace BurgerManiaApp.Core.Models.Products
{
    public class ProductHomePageModel : IProductModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;
    }
}
