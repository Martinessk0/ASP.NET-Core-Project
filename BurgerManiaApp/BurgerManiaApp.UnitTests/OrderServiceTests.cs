using BurgerManiaApp.Core.Contracts;
using BurgerManiaApp.Core.Services;
using BurgerManiaApp.Infractructure.Data.Common;
using BurgerManiaApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BurgerManiaApp.Infractructure.Data.Entities;
using BurgerManiaApp.Infractructure.Data.Entities.Account;
using BurgerManiaApp.Infrastructure.Data.Entities;

namespace BurgerManiaApp.UnitTests
{
    public class OrderServiceTests
    {
        private IRepository repo;
        private IOrderService orderService;
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
        public async Task TestGetAllOrders()
        {
            var repo = new Repository(context);
            orderService = new OrderService(repo);
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

            await repo.AddRangeAsync(new List<Order>()
            {
                new Order("b416372a-0acf-443d-a28f-a040a62bc8c7")
                {
                    BuyerId = "b416372a-0acf-443d-a28f-a040a62bc8c7",
                    Email = "testov@gmail.com",
                    FullName = "Test Testov",
                    OrderNumber = "asdfgf",
                    PhoneNumber = "+359886543930",
                    OrderStatus = new OrderStatus(){Id = 1,Name="Pending"},
                },
            });

            await repo.SaveChangesAsync();

           var orderCollection = await orderService.GetAllOrders("b416372a-0acf-443d-a28f-a040a62bc8c7");

            Assert.That(1, Is.EqualTo(orderCollection.Orders.Count()));
        }

        [Test]
        public async Task TestCreateOrder()
        {
            var repo = new Repository(context);
            orderService = new OrderService(repo);
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
            var cart = new ShoppingCart("")
            {
                BuyerId = "b416372a-0acf-443d-a28f-a040a62bc8c7",
                CartProducts = new List<ShoppingCartItem>(),
                DateOfCreation = DateTime.Now,
                Id = 2,
                IsActive = true
            };

            await repo.AddAsync(user);
            await repo.AddAsync(cart);
            await repo.SaveChangesAsync();

            var email = "test@gmail.com";
            int cartId = 2;
            var firstName = "Test";
            var lastName = "Test";
            var phoneNumber = "+359776575059";
            var zipcode = "1000";
            var streetAddress = "ul.14 polk 54a";
            var city = "Blagoevgrad";
            var deliveryAddressName = "ivan";

            await orderService.CreateOrder(user.Id,cartId, email, firstName, lastName,phoneNumber,zipcode,streetAddress,city, deliveryAddressName);

            Assert.That(1, Is.EqualTo(repo.AllReadonly<Order>().Count()));
        }

        [Test]
        public async Task TestGetCurrentOrderInfo()
        {
            var repo = new Repository(context);
            orderService = new OrderService(repo);
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

            await repo.AddRangeAsync(new List<Order>()
            {
                new Order("b416372a-0acf-443d-a28f-a040a62bc8c7")
                {
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
            });

            await repo.SaveChangesAsync();

            var orderCollection = await orderService.GetCurrentOrderInfo(1, "b416372a-0acf-443d-a28f-a040a62bc8c7");

            Assert.That(1, Is.EqualTo(orderCollection.OrderNumber));
            Assert.That(orderCollection.OrderNumber = 2, Is.EqualTo(2));
        }


        [TearDown]
        public void TearDown()
        {
            context.Dispose();
        }

    }
}
