using BurgerManiaApp.Core.Models.Products;

namespace BurgerManiaApp.Core.Contracts
{
    public interface IProductService
    {
        Task <IEnumerable<ProductHomePageModel>> LastThreeProducts();
    }
}
