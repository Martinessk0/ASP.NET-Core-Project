using BurgerManiaApp.Core.Contracts;
using BurgerManiaApp.Core.Models.Cart;
using BurgerManiaApp.Core.Models.Order;
using BurgerManiaApp.Infractructure.Data.Common;
using BurgerManiaApp.Infractructure.Data.Entities;
using BurgerManiaApp.Infractructure.Data.Entities.Account;
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

        public async Task<OrdersViewModel> GetAllOrders(string? userId)
        {
            var result = new OrdersViewModel();
            var user = await repo.GetByIdAsync<User>(userId);
            
            var orders = await repo.AllReadonly<Order>()
                .Where(o => o.BuyerId == userId)
                .Include(o => o.OrderStatus)
                .Select(o => new OrderServiceModel()
                {
                    OrderId = o.Id,
                    OrderDate = o.OrderDate.ToString(),
                    OrderStatusName = o.OrderStatus.Name,
                })
                .OrderByDescending(x => x.OrderId)
                .ToListAsync();
            result.Orders.AddRange(orders);

            return result;
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

        public async Task<CurrentOrderViewModel> GetCurrentOrderInfo(int id,string userId)
        {

            var order = await repo.All<Order>()
                .Where(x => x.Id == id)
                .Include(x => x.OrderStatus)
                .Include(x => x.Products)
                .Select(x => new CurrentOrderViewModel()
                {
                    OrderNumber = x.Id,
                    FullName = x.FullName,
                    OrderStatus = x.OrderStatus.Name,
                    Email = x.Email,
                    PhoneNumber = x.PhoneNumber,
                    DeliveryAddress = x.DeliveryAddress.StreetAddress,
                    City = x.DeliveryAddress.City,
                    Products = x.Products.ToList(),
                    TotalPrice = x.TotalOrderPrice(),
                    OrderDate = x.OrderDate.ToString(),
                })
                .FirstOrDefaultAsync();



            return order;
        }
    }
}
