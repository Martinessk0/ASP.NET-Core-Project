using BurgerManiaApp.Core.Contracts.Deliverer;
using BurgerManiaApp.Core.Services.Deliverer;
using BurgerManiaApp.Infractructure.Data.Common;
using BurgerManiaApp.Infractructure.Data.Entities;
using BurgerManiaApp.Infractructure.Data.Entities.Account;
using BurgerManiaApp.Infrastructure.Data;
using BurgerManiaApp.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BurgerManiaApp.UnitTests
{
    public class DelivererOrderServiceTests
    {

        private IRepository repo;
        private IDelivererOrderService delivererOrderService;
        private ApplicationDbContext context;

        [SetUp]
        public void Setup()
        {
            var contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("BurgerDb")
                .EnableSensitiveDataLogging()
                .Options;

            context = new ApplicationDbContext(contextOptions);

            

            context.Database.EnsureDeletedAsync();
            context.Database.EnsureCreatedAsync();
        }

        [Test]
        public async Task TestGetAllOrders()
        {
            var repo = new Repository(context);
            delivererOrderService = new DelivererOrderService(repo);
            await repo.AddRangeAsync(new List<Order>()
            {
                new Order("b416372a-0acf-443d-a28f-a040a62bc8c7")
                {
                    Id = 1,
                    BuyerId = "b416372a-0acf-443d-a28f-a040a62bc8c7",
                    Email = "testov@gmail.com",
                    FullName = "Test Testov",
                    OrderNumber = "asdfgf",
                    PhoneNumber = "+359886543930",
                    OrderStatus = new OrderStatus(){Id = 1,Name="Pending"},
                    DeliveryAddress = new DeliveryAddress("yl.Marica 5","2700","Blagoevgrad","Smth"),
                    Products = new List<ShoppingCartItem>()
                    {
                        new ShoppingCartItem(1,"Cola",7,"",2),
                    },
                },
                new Order("b416372a-0acf-443d-a28f-a040a62bc8c7")
                {
                    Id = 2,
                    BuyerId = "b416372a-0acf-443d-a28f-a040a62bc8c7",
                    Email = "testov@gmail.com",
                    FullName = "Test Testov",
                    OrderNumber = "asdfgf",
                    PhoneNumber = "+359886543930",
                    OrderStatus = new OrderStatus(){Id = 2,Name="In Progress"},
                    DeliveryAddress = new DeliveryAddress("yl.Marica 5","2700","Blagoevgrad","Smth"),
                    Products = new List<ShoppingCartItem>()
                    {
                        new ShoppingCartItem(1,"Cola",7,"",2),
                    },
                },
                new Order("b416372a-0acf-443d-a28f-a040a62bc8c7")
                {
                    Id = 3,
                    BuyerId = "b416372a-0acf-443d-a28f-a040a62bc8c7",
                    Email = "testov@gmail.com",
                    FullName = "Test Testov",
                    OrderNumber = "asdfgf",
                    PhoneNumber = "+359886543930",
                    OrderStatus = new OrderStatus(){Id = 3,Name="Complied"},
                    DeliveryAddress = new DeliveryAddress("yl.Marica 5","2700","Blagoevgrad","Smth"),
                    Products = new List<ShoppingCartItem>()
                    {
                        new ShoppingCartItem(1,"Cola",7,"",2),
                    },
                },
                new Order("b416372a-0acf-443d-a28f-a040a62bc8c7")
                {
                    Id = 4,
                    BuyerId = "b416372a-0acf-443d-a28f-a040a62bc8c7",
                    Email = "testov@gmail.com",
                    FullName = "Test Testov",
                    OrderNumber = "asdfgf",
                    PhoneNumber = "+359886543930",
                    OrderStatus = new OrderStatus(){Id = 4,Name="Cancelled"},
                    DeliveryAddress = new DeliveryAddress("yl.Marica 5","2700","Blagoevgrad","Smth"),
                    Products = new List<ShoppingCartItem>()
                    {
                        new ShoppingCartItem(1,"Cola",7,"",2),
                    },
                },
            });

            await repo.SaveChangesAsync();

            var ordersCollection = await delivererOrderService.GetAllOrders();

            Assert.That(2, Is.EqualTo(ordersCollection.Orders.Count()));
        }

        [Test]
        public async Task TestGetAllOrderStatuses()
        {
            var repo = new Repository(context);
            delivererOrderService = new DelivererOrderService(repo);
            await repo.AddRangeAsync(new List<OrderStatus>()
            {
                new OrderStatus() { Id = 1, Name = "Pending"},
                new OrderStatus() { Id = 2, Name = "In Progress"},
                new OrderStatus() { Id = 3, Name = "Complied"},
                new OrderStatus() { Id = 4, Name = "Cancelled"},
            });

            await repo.SaveChangesAsync();

            var ordersCollection = await delivererOrderService.GetAllOrderStatuses();

            Assert.That(4, Is.EqualTo(ordersCollection.Count()));
            Assert.That(ordersCollection[0], Is.EqualTo("Pending"));
            Assert.That(ordersCollection[1], Is.EqualTo("In Progress"));
            Assert.That(ordersCollection[2], Is.EqualTo("Complied"));
            Assert.That(ordersCollection[3], Is.EqualTo("Cancelled"));

        }

        [Test]
        public async Task TestGetModel()
        {
            var repo = new Repository(context);
            delivererOrderService = new DelivererOrderService(repo);
            await repo.AddRangeAsync(new List<OrderStatus>()
            {
                new OrderStatus() { Id = 1, Name = "Pending"},
                new OrderStatus() { Id = 2, Name = "In Progress"},
                new OrderStatus() { Id = 3, Name = "Complied"},
                new OrderStatus() { Id = 4, Name = "Cancelled"},
            });

            await repo.SaveChangesAsync();

            var model = delivererOrderService.GetModel(2);

            Assert.That(4, Is.EqualTo(model.Statuses.Count));
            Assert.That(2, Is.EqualTo(model.Id));
        }

        [Test]
        public async Task TestChangeStatusToOrder()
        {
            var repo = new Repository(context);
            delivererOrderService = new DelivererOrderService(repo);

            await repo.AddRangeAsync(new List<OrderStatus>()
            {
                new OrderStatus() { Id = 1, Name = "Pending"},
                new OrderStatus() { Id = 2, Name = "In Progress"},
                new OrderStatus() { Id = 3, Name = "Complied"},
                new OrderStatus() { Id = 4, Name = "Cancelled"},
            });
            var order = new Order("b416372a-0acf-443d-a28f-a040a62bc8c7")
                {
                    Id = 1,
                    BuyerId = "b416372a-0acf-443d-a28f-a040a62bc8c7",
                    Email = "testov@gmail.com",
                    FullName = "Test Testov",
                    OrderNumber = "asdfgf",
                    PhoneNumber = "+359886543930",
                    OrderStatusId = 1,
                    DeliveryAddress = new DeliveryAddress("yl.Marica 5", "2700", "Blagoevgrad", "Smth"),
                    Products = new List<ShoppingCartItem>()
                    {
                        new ShoppingCartItem(1,"Cola",7,"",2),
                    },
                };
            await repo.AddAsync(order);

            await repo.SaveChangesAsync();

            delivererOrderService.ChangeStatusToOrder(1, "In Progress");
            await repo.SaveChangesAsync();
            var model = await repo.GetByIdAsync<Order>(1);
            Assert.That("In Progress", Is.EqualTo(model.OrderStatus.Name));
            //Assert.That(20, Is.EqualTo(model.OrderStatus.Id));

            //await delivererOrderService.ChangeStatusToOrder(2, "Complied");

            //var model2 = await repo.GetByIdAsync<Order>(2);
            //Assert.That(30, Is.EqualTo(model2.OrderStatus.Id));
            //Assert.That("Complied", Is.EqualTo(model2.OrderStatus.Name));
        }

        [TearDown]
        public void TearDown()
        {
            context.Dispose();
        }
    }
}
