using BurgerManiaApp.Core.Contracts;
using BurgerManiaApp.Core.Models.Products;
using BurgerManiaApp.Core.Services;
using BurgerManiaApp.Infractructure.Data.Common;
using BurgerManiaApp.Infrastructure.Data;
using BurgerManiaApp.Infrastructure.Data.Entities;
using Castle.Core.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;

namespace BurgerManiaApp.UnitTests
{
    public class ProductServiceTests
    {
        private IRepository repo;
        private ILogger<ProductService> logger;
        private IProductService productService;
        private ApplicationDbContext context;

        [SetUp]
        public void Setup()
        {
            var contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("BurgerDb")
                .Options;

            context = new ApplicationDbContext(contextOptions);

            context.Database.EnsureDeletedAsync();
            context.Database.EnsureCreatedAsync();
        }

        [Test]
        public async Task TestLastThreeBurgers()
        {
            var loggerMock = new Mock<ILogger<ProductService>>();
            logger = loggerMock.Object;
            var repo = new Repository(context);

            productService = new ProductService(repo, logger);

            await repo.AddRangeAsync(new List<Product>()
            {
                new Product(){ Id = 1, Name = "Spicy Burger",Description = "Spicy Burger",ImageUrl = "",Price = 7,CategoryId = 1,IsActive = true,},
                new Product(){ Id = 2, Name = "Spicy Burger",Description = "Spicy Burger",ImageUrl = "",Price = 7,CategoryId = 1,IsActive = true,},
                new Product(){ Id = 4, Name = "Spicy Burger",Description = "Spicy Burger",ImageUrl = "",Price = 7,CategoryId = 1,IsActive = true,},
                new Product(){ Id = 3, Name = "Spicy Burger",Description = "Spicy Burger",ImageUrl = "",Price = 7,CategoryId = 1,IsActive = true,}
            });

            await repo.SaveChangesAsync();
            var productCollection = await productService.LastThreeBurgers();

            Assert.That(3, Is.EqualTo(productCollection.Count()));
            Assert.That(productCollection.Any(h => h.Id == 1), Is.False);
        }

        [Test]
        public async Task TestCreate()
        {
            var loggerMock = new Mock<ILogger<ProductService>>();
            logger = loggerMock.Object;
            var repo = new Repository(context);

            productService = new ProductService(repo, logger);
            var model = new ProductModel()
            {
                Id = 1,
                Name = "Spicy Burger",
                Description = "Spicy Burger",
                ImageUrl = "",
                Price = 7,
                CategoryId = 1,
            };

            await productService.Create(model);

            Assert.That(1, Is.EqualTo(repo.AllReadonly<Product>().Count()));
        }

        [Test]
        public async Task TestAllCategoriesNames()
        {

            var loggerMock = new Mock<ILogger<ProductService>>();
            logger = loggerMock.Object;
            var repo = new Repository(context);
            productService = new ProductService(repo, logger);

            await repo.AddRangeAsync(new List<Category>()
            {
                new Category() { Id = 1, Name = "Burger"},
                 new Category() { Id = 2, Name = "Drink"}
            });

            await repo.SaveChangesAsync();
            var categoriesCollection = await productService.AllCategoriesNames();

            Assert.That(2, Is.EqualTo(categoriesCollection.Count()));
        }

        [Test]
        public async Task TestExists()
        {

            var loggerMock = new Mock<ILogger<ProductService>>();
            logger = loggerMock.Object;
            var repo = new Repository(context);
            productService = new ProductService(repo, logger);

            await repo.AddRangeAsync(new List<Product>()
            {
                new Product(){ Id = 1, Name = "Spicy Burger",Description = "Spicy Burger",ImageUrl = "",Price = 7,CategoryId = 1,IsActive = true,},
                new Product(){ Id = 2, Name = "Spicy Burger",Description = "Spicy Burger",ImageUrl = "",Price = 7,CategoryId = 1,IsActive = true,},
                new Product(){ Id = 4, Name = "Spicy Burger",Description = "Spicy Burger",ImageUrl = "",Price = 7,CategoryId = 1,IsActive = true,},
                new Product(){ Id = 3, Name = "Spicy Burger",Description = "Spicy Burger",ImageUrl = "",Price = 7,CategoryId = 1,IsActive = false,}
            });

            await repo.SaveChangesAsync();

            Assert.That(true, Is.EqualTo(await productService.Exists(1)));
            Assert.That(false, Is.EqualTo(await productService.Exists(3)));
            Assert.That(false, Is.EqualTo(await productService.Exists(5)));
        }

        [Test]
        public async Task TestProductDetailsById()
        {

            var loggerMock = new Mock<ILogger<ProductService>>();
            logger = loggerMock.Object;
            var repo = new Repository(context);
            productService = new ProductService(repo, logger);

            await repo.AddRangeAsync(new List<Product>()
            {
                new Product(){ Id = 1, Name = "Spicy Burger",Description = "Spicy Burger",ImageUrl = "",Price = 7,CategoryId = 1,IsActive = true,},
                new Product(){ Id = 2, Name = "Spicy Burger",Description = "Spicy Burger",ImageUrl = "",Price = 7,CategoryId = 1,IsActive = true,},
                new Product(){ Id = 3, Name = "Spicy Burger",Description = "Spicy Burger",ImageUrl = "",Price = 7,CategoryId = 1,IsActive = false,}
            });
            await repo.SaveChangesAsync();


            var productDetailsModel = new ProductDetailsModel()
            {
                Category = "Burger", Description = "Spicy Burger", Id = 1, ImageUrl = "", Name = "Spicy Burger",
                Price = 7
            };


            Assert.That(productDetailsModel.Id, Is.EqualTo(productService.ProductDetailsById(1).Id));
        }

        [Test]
        public async Task TestAllCategories()
        {

            var loggerMock = new Mock<ILogger<ProductService>>();
            logger = loggerMock.Object;
            var repo = new Repository(context);
            productService = new ProductService(repo, logger);

            await repo.AddRangeAsync(new List<Category>()
            {
                new (){Id = 1,Name = "Burger"},
                new (){Id = 2,Name = "Drink"}
            });
            await repo.SaveChangesAsync();

            var categoriesCollection = await productService.AllCategories();

            Assert.That(2, Is.EqualTo(categoriesCollection.Count()));
        }

        [Test]
        public async Task TestCategoryExists()
        {

            var loggerMock = new Mock<ILogger<ProductService>>();
            logger = loggerMock.Object;
            var repo = new Repository(context);
            productService = new ProductService(repo, logger);

            await repo.AddRangeAsync(new List<Category>()
            {
                new (){Id = 1,Name = "Burger"},
                new (){Id = 2,Name = "Drink"}
            });
            await repo.SaveChangesAsync();


            Assert.That(true, Is.EqualTo(await productService.CategoryExists(2)));
            Assert.That(true, Is.EqualTo(await productService.CategoryExists(1)));
            Assert.That(false, Is.EqualTo(await productService.CategoryExists(3)));
        }

        [Test]
        public async Task TestGetProductCategoryId()
        {

            var loggerMock = new Mock<ILogger<ProductService>>();
            logger = loggerMock.Object;
            var repo = new Repository(context);
            productService = new ProductService(repo, logger);

            await repo.AddRangeAsync(new List<Category>()
            {
                new (){Id = 1,Name = "Burger"},
                new (){Id = 2,Name = "Drink"}
            });

            await repo.AddRangeAsync(new List<Product>()
            {
                new Product()
                {
                    Id = 1, Name = "Spicy Burger", Description = "Spicy Burger", ImageUrl = "", Price = 7,
                    CategoryId = 1, IsActive = true,
                },
                new Product()
                {
                    Id = 2, Name = "Cola", Description = "Cola", ImageUrl = "", Price = 7,
                    CategoryId = 2, IsActive = true,
                },
                new Product()
                {
                    Id = 3, Name = "Spicy Burger", Description = "Spicy Burger", ImageUrl = "", Price = 7,
                    CategoryId = 1, IsActive = false,
                }
            });
            await repo.SaveChangesAsync();


            Assert.That(1, Is.EqualTo(await productService.GetProductCategoryId(1)));
            Assert.That(2, Is.EqualTo(await productService.GetProductCategoryId(2)));
        }

        [Test]
        public async Task TestDelete()
        {

            var loggerMock = new Mock<ILogger<ProductService>>();
            logger = loggerMock.Object;
            var repo = new Repository(context);
            productService = new ProductService(repo, logger);

            var productCollection = new List<Product>()
            {
                new Product()
                {
                    Id = 1, Name = "Spicy Burger", Description = "Spicy Burger", ImageUrl = "", Price = 7,
                    CategoryId = 1, IsActive = true,
                },
                new Product()
                {
                    Id = 2, Name = "Cola", Description = "Cola", ImageUrl = "", Price = 7,
                    CategoryId = 2, IsActive = true,
                },
            };
            await repo.AddRangeAsync(productCollection);
            await repo.SaveChangesAsync();

            await productService.Delete(2);

            Assert.That(1, Is.EqualTo(repo.AllReadonly<Product>().Where(x => x.IsActive).Count()));
        }


        [Test]
        public async Task TestEdit()
        {

            var loggerMock = new Mock<ILogger<ProductService>>();
            logger = loggerMock.Object;
            var repo = new Repository(context);
            productService = new ProductService(repo, logger);

            var product = new Product()
            {
                Id = 1,
                Name = "Spicy Burger",
                Description = "Spicy Burger",
                ImageUrl = "",
                Price = 7,
                CategoryId = 1,
                IsActive = true,
            };
            await repo.AddAsync(product);
            await repo.SaveChangesAsync();

            var productModel = new ProductModel()
            {
                Id = 1,
                Name = "Smth Burger",
                Description = "Smth Burger",
                ImageUrl = "",
                Price = 3,
                CategoryId = 1,
            };
            await productService.Edit(1, productModel);
            var editModel = await repo.GetByIdAsync<Product>(1);

            Assert.That(product.Name, Is.EqualTo(editModel.Name));
            Assert.That(product.Description, Is.EqualTo(editModel.Description));
            Assert.That(product.Price, Is.EqualTo(editModel.Price));
            Assert.That(product.CategoryId, Is.EqualTo(editModel.CategoryId));
            //Assert.That(2, Is.EqualTo(await productService.GetProductCategoryId(2)));
        }


        [TearDown]
        public void TearDown()
        {
            context.Dispose();
        }
    }
}
