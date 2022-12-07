using BurgerManiaApp.Core.Models.Cart;
using BurgerManiaApp.Core.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerManiaApp.Core.Contracts
{
    public interface ICartService
    {
        Task<ShoppingCartDto> GetOrCreateCart(string? userId);

        Task<ShoppingCartDto> CreateCartForUser(string? userId);

        Task AddToCart(string? userId, int productId);

        Task UpdateQuantity(Dictionary<int, int> productAndQuantity);
    }
}
