using BurgerManiaApp.Infrastructure.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerManiaApp.Core.Models.Cart
{
    public class ShoppingCartDto
    {
        public int Id { get; set; }
        public string BuyerId { get; set; }
        public List<ShoppingCartItemDto> CartItems { get; set; } = new List<ShoppingCartItemDto>();
        public DateTime DateOfCreation { get; set; }
    }
}
