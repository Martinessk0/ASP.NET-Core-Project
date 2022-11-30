using BurgerManiaApp.Core.Models.Products;

namespace BurgerManiaApp.Models
{
    public class AllProductsQueryModel
    {
        public const int ProductPerPage = 6;

        public string? Category { get; set; }

        public string? SearchTerm { get; set; }

        public ProductSorting Sorting { get; set; }

        public int CurrentPage { get; set; } = 1;

        public int TotalProductsCount { get; set; }

        public IEnumerable<string> Categories { get; set; } = Enumerable.Empty<string>();

        public IEnumerable<ProductServiceModel> Houses { get; set; } = Enumerable.Empty<ProductServiceModel>();
    }
}
