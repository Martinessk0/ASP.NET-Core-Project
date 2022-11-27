using BurgerManiaApp.Core.Contracts;
using BurgerManiaApp.Core.Models.Products;
using BurgerManiaApp.Infractructure.Data.Common;
using BurgerManiaApp.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BurgerManiaApp.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository repo;

        public ProductService(IRepository repo)
        {
            this.repo = repo;
        }

        public async Task<IEnumerable<ProductHomePageModel>> LastThreeProducts()
        {
            return await repo.AllReadonly<Product>()
                .Where(h => h.IsActive)
                .OrderByDescending(h => h.Id)
                .Select(h => new ProductHomePageModel()
                {
                    Id = h.Id,
                    ImageUrl = h.ImageUrl,
                    Name = h.Name
                })
                .Take(3)
                .ToListAsync();
        }
    }
}
