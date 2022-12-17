using BurgerManiaApp.Core.Contracts;
using BurgerManiaApp.Core.Services;
using BurgerManiaApp.Infractructure.Data.Common;
using BurgerManiaApp.Infractructure.Data.Entities;
using BurgerManiaApp.Infractructure.Data.Entities.Account;
using BurgerManiaApp.Infrastructure.Data;
using BurgerManiaApp.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BurgerManiaApp.UnitTests
{
    public class CartServiceTests
    {
        private IRepository repo;
        private ICartService cartService;
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
        public async Task TestCreateCartForUser()
        {
            var repo = new Repository(context);
            cartService = new CartService(repo);

            var user = new User()
            {
                Id = "b416372a-0acf-443d-a28f-a040a62bc8c7",
                FirstName = "Test",
                LastName = "Testov",
                UserName = "Test123",
                NormalizedUserName = "TEST",
                Email = "test@gmail.com",
                NormalizedEmail = "TEST@GMAIL.COM",
                Address = "Test Street 3"
            };
            await repo.AddAsync(user);

            await cartService.CreateCartForUser("b416372a-0acf-443d-a28f-a040a62bc8c7");
            await cartService.CreateCartForUser("b416372a-0acf-443d-a28f-a040a62bc8c7");

            Assert.That(2, Is.EqualTo(repo.AllReadonly<ShoppingCart>().Count()));
        }

        [Test]
        public async Task TestGetOrCreateCart()
        {
            var repo = new Repository(context);
            cartService = new CartService(repo);

            var user = new User()
            {
                Id = "b416372a-0acf-443d-a28f-a040a62bc8c7",
                FirstName = "Test",
                LastName = "Testov",
                UserName = "Test123",
                NormalizedUserName = "TEST",
                Email = "test@gmail.com",
                NormalizedEmail = "TEST@GMAIL.COM",
                Address = "Test Street 3"
            };
            await repo.AddAsync(user);

            await repo.SaveChangesAsync();

            var model =await cartService.GetOrCreateCart("b416372a-0acf-443d-a28f-a040a62bc8c7");
            await cartService.GetOrCreateCart("b416372a-0acf-443d-a28f-a040a62bc8c7");
            Assert.That(1, Is.EqualTo(repo.AllReadonly<ShoppingCart>().Count()));
        }

        [Test]
        public async Task TestAddToCart()
        {
            var repo = new Repository(context);
            cartService = new CartService(repo);

            var user = new User()
            {
                Id = "b416372a-0acf-443d-a28f-a040a62bc8c7",
                FirstName = "Test",
                LastName = "Testov",
                UserName = "Test123",
                NormalizedUserName = "TEST",
                Email = "test@gmail.com",
                NormalizedEmail = "TEST@GMAIL.COM",
                Address = "Test Street 3"
            };
            await repo.AddAsync(user);
            var product = new Product()
            {
                Id = 1,
                CategoryId = 1,
                Category = new Category(){Id = 1,Name="Burger"},
                CreatedAt = DateTime.Now,
                Description = "asdf",
                ImageUrl = "",
                IsActive = true,
                Name = "Cola",
                Price = 4.32M,
            };
            await repo.AddAsync(product);
            await repo.SaveChangesAsync();

            await cartService.AddToCart("b416372a-0acf-443d-a28f-a040a62bc8c7",1);
            Assert.That(1, Is.EqualTo(repo.AllReadonly<ShoppingCart>().Count()));
            Assert.That(1, Is.EqualTo(repo.AllReadonly<ShoppingCartItem>().Count()));
        }

        [Test]
        public async Task TestUpdateQuantity()
        {
            var repo = new Repository(context);
            cartService = new CartService(repo);

            var user = new User()
            {
                Id = "b416372a-0acf-443d-a28f-a040a62bc8c7",
                FirstName = "Test",
                LastName = "Testov",
                UserName = "Test123",
                NormalizedUserName = "TEST",
                Email = "test@gmail.com",
                NormalizedEmail = "TEST@GMAIL.COM",
                Address = "Test Street 3"
            };
            var product = new Product()
            {
                Id = 1,
                CategoryId = 1,
                Category = new Category() { Id = 1, Name = "Burger" },
                CreatedAt = DateTime.Now,
                Description = "asdf",
                ImageUrl = "",
                IsActive = true,
                Name = "Cola",
                Price = 4.32M,
            };
            var shoppingCart = new ShoppingCart("b416372a-0acf-443d-a28f-a040a62bc8c7")
            {
                CartProducts = new List<ShoppingCartItem>()
                {
                    new ShoppingCartItem(1,"Cola",1.29M,"",1)
                }
            };
            await repo.AddAsync(user);
            await repo.AddAsync(product);
            await repo.AddAsync(shoppingCart);
            await repo.SaveChangesAsync();

            var pQuantity = new Dictionary<int, int>();
            pQuantity.Add(1, 3);
            await cartService.UpdateQuantity(pQuantity);
            var itemColletion =await repo.AllReadonly<ShoppingCartItem>()
                .FirstOrDefaultAsync(x => x.Id == 1);

            Assert.That(1, Is.EqualTo(itemColletion.Id));
            Assert.That(3, Is.EqualTo(itemColletion.Quantity));
        }


        [TearDown]
        public void TearDown()
        {
            context.Dispose();
        }
    }
}
