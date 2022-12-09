using BurgerManiaApp.Core.Contracts;
using BurgerManiaApp.Core.Models.Products;
using BurgerManiaApp.Infractructure.Data.Common;
using BurgerManiaApp.Infrastructure.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BurgerManiaApp.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository repo;
        private readonly ILogger logger;

        public ProductService(IRepository repo,
            ILogger<ProductService> _logger)
        {
            this.repo = repo;
            logger = _logger;
        }
        public async Task<ProductQueryModel> All(string? category = null, string? searchTerm = null, ProductSorting sorting = ProductSorting.Newest, int currentPage = 1, int productsPerPage = 1)
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
                .Skip((currentPage - 1) * productsPerPage)
                .Take(productsPerPage)
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

        public async Task<IEnumerable<ProductCategoryModel>> AllCategories()
        {
            return await repo.AllReadonly<Category>()
               .OrderBy(c => c.Name)
               .Select(c => new ProductCategoryModel()
               {
                   Id = c.Id,
                   Name = c.Name
               })
               .ToListAsync();
        }

        public async Task<int> Create(ProductModel model)
        {
            var product = new Product()
            {
                CategoryId = model.CategoryId,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                Price = model.Price,
                Name = model.Name,
            };

            try
            {
                await repo.AddAsync(product);
                await repo.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(nameof(Create), ex);
                throw new ApplicationException("Database failed to save info", ex);
            }

            return product.Id;
        }

        public async Task<bool> CategoryExists(int categoryId)
        {
            return await repo.AllReadonly<Category>()
                .AnyAsync(c => c.Id == categoryId);
        }

        public async Task<int> GetProductCategoryId(int productId)
        {
            return (await repo.GetByIdAsync<Product>(productId)).CategoryId;
        }

        public async Task Edit(int productId, ProductModel model)
        {
            var product = await repo.GetByIdAsync<Product>(productId);

            product.Description = model.Description;
            product.ImageUrl = model.ImageUrl;
            product.Price = model.Price;
            product.Name = model.Name;
            product.CategoryId = model.CategoryId;

            await repo.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var product = await repo.GetByIdAsync<Product>(id);
            product.IsActive = false;

            await repo.SaveChangesAsync();
        }
    }
}
