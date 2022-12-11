namespace BurgerManiaApp.Core.Models.Products
{
    public class ProductQueryModel
    {
        public int TotalProductsCount { get; set; }

        public IEnumerable<ProductServiceModel> Products { get; set; } = new List<ProductServiceModel>();
    }
}
