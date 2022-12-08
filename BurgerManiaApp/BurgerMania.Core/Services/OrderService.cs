﻿using BurgerManiaApp.Core.Contracts;
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
        private readonly ApplicationDbContext _context;

        public OrderService(IRepository repo, ApplicationDbContext context)
        {
            this.repo = repo;
            _context = context;
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
                cart = await _context.ShoppingCarts
                    .Include(x => x.CartProducts)
                    .Where(x => x.BuyerId == buyerId)
                    .FirstAsync();

                await repo.AddAsync<Order>(new Order(buyerId)
                {
                    Products = cart.CartProducts,
                    DeliveryAddress = deliveryAddress,
                    FullName = $"{firstName} {lastName}",
                    PhoneNumber = phoneNumber,
                    Email = email,
                    OrderNumber = Guid.NewGuid().ToString(),
                });

                _context.ShoppingCarts.Remove(cart);

                _context.SaveChanges();
                //await repo.DeleteAsync<ShoppingCart>(cart);

                await repo.SaveChangesAsync();
            }

        }
    }
}
