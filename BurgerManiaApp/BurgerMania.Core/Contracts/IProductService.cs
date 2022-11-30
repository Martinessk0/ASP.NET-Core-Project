using BurgerManiaApp.Core.Models.Products;
using Microsoft.AspNetCore.Mvc;

namespace BurgerManiaApp.Core.Contracts
{
    public interface IProductService
    {
        Task <IEnumerable<ProductHomePageModel>> LastThreeBurgers();

        Task<bool> Exists(int id);

        Task<ProductDetailsModel> ProductDetailsById(int id);

        Task<IEnumerable<string>> AllCategoriesNames();

        Task<bool> CategoryExists(int categoryId);

        Task<int> Create(ProductModel model);

        Task Edit(int productId, ProductModel model);

        Task Delete(int id);

        Task<int> GetProductCategoryId(int productId);

        Task<IEnumerable<ProductCategoryModel>> AllCategories();

        Task<ProductQueryModel> All(
           string? category = null,
           string? searchTerm = null,
           ProductSorting sorting = ProductSorting.Newest,
           int currentPage = 1,
           int housesPerPage = 1);
    }
}
