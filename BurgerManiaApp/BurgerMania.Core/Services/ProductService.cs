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
        public async Task<ProductQueryModel> All(string? category = null, string? searchTerm = null, ProductSorting sorting = ProductSorting.Newest, int currentPage = 1, int housesPerPage = 1)
        {
            var result = new ProductQueryModel();
            var products = repo.AllReadonly<Product>()
                .Where(h => h.IsActive);

            if (string.IsNullOrEmpty(category) == false)
            {
                products = products
                    .Where(h => h.Category.Name == category);
            }

            if (string.IsNullOrEmpty(searchTerm) == false)
            {
                searchTerm = $"%{searchTerm.ToLower()}%";

                products = products
                    .Where(h => EF.Functions.Like(h.Name.ToLower(), searchTerm) ||
                        EF.Functions.Like(h.Description.ToLower(), searchTerm));
            }

            products = sorting switch
            {
                ProductSorting.Newest => products
                    .OrderBy(p => p.CreatedAt),
                ProductSorting.Price => products
                    .OrderByDescending(p => p.Price),
                ProductSorting.Ascending => products
                    .OrderBy(p => p.Name),
                _ => products.OrderByDescending(p => p.Name)
            };

            result.Products = await products
                .Skip((currentPage - 1) * housesPerPage)
                .Take(housesPerPage)
                .Select(h => new ProductServiceModel()
                {
                    Id = h.Id,
                    ImageUrl = h.ImageUrl,
                    Price = h.Price,
                    Name = h.Name
                })
                .ToListAsync();

            result.TotalProductsCount = await products.CountAsync();

            return result;
        }

        public async Task<IEnumerable<string>> AllCategoriesNames()
        {
            return await repo.AllReadonly<Category>()
               .Select(c => c.Name)
               .Distinct()
               .ToListAsync();
        }

        public async Task<bool> Exists(int id)
        {
            return await repo.AllReadonly<Product>()
               .AnyAsync(h => h.Id == id && h.IsActive);
        }

        public async Task<ProductDetailsModel> ProductDetailsById(int id)
        {
            return await repo.AllReadonly<Product>()
               .Where(h => h.IsActive)
               .Where(h => h.Id == id)
               .Select(h => new ProductDetailsModel()
               {
                   Category = h.Category.Name,
                   Description = h.Description,
                   Id = id,
                   ImageUrl = h.ImageUrl,
                   Price = h.Price,
                   Name = h.Name,

               })
               .FirstAsync();
        }

        public async Task<IEnumerable<ProductHomePageModel>> LastThreeBurgers()
        {
            return await repo.AllReadonly<Product>()
                .Where(p => p.CategoryId == 1)
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
