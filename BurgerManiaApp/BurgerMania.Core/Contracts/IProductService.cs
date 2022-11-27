using BurgerManiaApp.Core.Models.Products;

namespace BurgerManiaApp.Core.Contracts
{
    public interface IProductService
    {
        Task <IEnumerable<ProductHomePageModel>> LastThreeBurgers();

        Task<bool> Exists(int id);

        Task<ProductDetailsModel> ProductDetailsById(int id);

        Task<IEnumerable<string>> AllCategoriesNames();

        Task<ProductQueryModel> All(
           string? category = null,
           string? searchTerm = null,
           ProductSorting sorting = ProductSorting.Newest,
           int currentPage = 1,
           int housesPerPage = 1);
    }
}
