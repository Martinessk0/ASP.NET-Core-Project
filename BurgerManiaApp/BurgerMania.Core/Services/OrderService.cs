using BurgerManiaApp.Core.Contracts;
using BurgerManiaApp.Infractructure.Data.Common;
using BurgerManiaApp.Infractructure.Data.Entities;
using BurgerManiaApp.Infrastructure.Data;
using BurgerManiaApp.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BurgerManiaApp.Core.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRepository repo;


        public OrderService(IRepository repo)
        {
            this.repo = repo;
        }
        public async Task CreateOrder(string? buyerId,
                                      int? cartId,
                                      string email,
                                      string firstName,
                                      string lastName,
                                      string phoneNumber,
                                      string zipCode,
                                      string streetAddress,
                                      string city,
                                      string? deliveryAddressName)
        {
            var cart = new ShoppingCart("");
            var deliveryAddress = new DeliveryAddress(streetAddress, zipCode, city, deliveryAddressName);


            if (buyerId is not null && cartId is not null)
            {
                cart = await repo.All<ShoppingCart>()
                    .Include(x => x.CartProducts)
                    .Where(x => x.BuyerId == buyerId && x.IsActive)
                    .FirstAsync();

                await repo.AddAsync(new Order(buyerId)
                {
                    Products = cart.CartProducts,
                    DeliveryAddress = deliveryAddress,
                    FullName = $"{firstName} {lastName}",
                    PhoneNumber = phoneNumber,
                    Email = email,
                    OrderNumber = Guid.NewGuid().ToString(),
                });
                 cart.IsActive = false;

                await repo.SaveChangesAsync();
            }

        }
    }
}
