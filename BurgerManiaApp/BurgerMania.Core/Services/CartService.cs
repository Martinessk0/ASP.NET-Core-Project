using BurgerManiaApp.Core.Contracts;
using BurgerManiaApp.Core.Models.Cart;
using BurgerManiaApp.Infractructure.Data.Common;
using BurgerManiaApp.Infractructure.Data.Entities;
using BurgerManiaApp.Infrastructure.Data;
using BurgerManiaApp.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerManiaApp.Core.Services
{
    public class CartService : ICartService
    {
        private readonly IRepository repo;

        public CartService(IRepository repo)
        {
            this.repo = repo;
        }

        public async Task<ShoppingCartDto> CreateCartForUser(string? userId)
        {
            var cart = new ShoppingCart(userId);
            await repo.AddAsync<ShoppingCart>(cart);

            await repo.SaveChangesAsync();

            return await repo.All<ShoppingCart>()
                .Where(x => x.BuyerId == userId && x.IsActive)
                .Select(x => new ShoppingCartDto()
                {
                    BuyerId = x.BuyerId,
                    DateOfCreation = x.DateOfCreation,
                    CartItems = x.CartProducts.Select(p => new ShoppingCartItemDto()
                    {
                        Id = p.Id,
                        ImageUrl = p.ImageUrl,
                        Price = p.Price,
                        ProductName = p.ProductName,
                        Quantity = p.Quantity,
                        ShoppingCartId = p.ShoppingCart.Id
                    }).ToList()
                })
                .FirstAsync();
        }

        public async Task<ShoppingCartDto> GetOrCreateCart(string? userId)
        {
            var cart = await repo.All<ShoppingCart>()
                .Include(x => x.CartProducts)
                .Where(x => x.BuyerId == userId && x.IsActive)
                .Select(x => new ShoppingCartDto()
                {
                    BuyerId = x.BuyerId,
                    DateOfCreation = x.DateOfCreation,
                    CartItems = x.CartProducts.Select(p => new ShoppingCartItemDto()
                    {
                        Id = p.Id,
                        ImageUrl = p.ImageUrl,
                        Price = p.Price,
                        ProductName = p.ProductName,
                        Quantity = p.Quantity,
                        ShoppingCartId = p.ShoppingCart.Id
                    }).ToList()
                })
                .FirstOrDefaultAsync();


            if (cart == null)
            {
                return await CreateCartForUser(userId);
            }

            return cart;
        }

        public async Task AddToCart(string? userId, int productId)
        {
            var cart = await repo.All<ShoppingCart>()
                .Where(x => x.BuyerId == userId && x.IsActive)
                .FirstOrDefaultAsync();

            if (cart == null)
            {
                cart = new ShoppingCart(userId);
                await repo.AddAsync(cart);
            }

            var product = await repo.AllReadonly<Product>()
                .Include(x => x.Category)
                .Where(x => x.Id == productId)
                .FirstOrDefaultAsync();

            cart.AddItem(product, 1);

            await repo.SaveChangesAsync();
        }

        public async Task UpdateQuantity(Dictionary<int, int> productAndQuantity)
        {
            var cartItems = await repo.All<ShoppingCartItem>()
                .Where(x => productAndQuantity.Keys
                .Any(p => p == x.Id)).Include(x => x.ShoppingCart)
                .ToListAsync();


            foreach (var cartItem in cartItems)
            {
                foreach (var p in productAndQuantity)
                {
                    if (p.Key == cartItem.Id)
                    {
                        cartItem.SetQuantity(p.Value);
                    }
                }

                cartItem.ShoppingCart.RemoveEmptyItems();
            }

            await repo.SaveChangesAsync();
        }

    }
}
