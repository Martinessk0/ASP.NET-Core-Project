using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerManiaApp.Core.Models.Cart
{
    public class ShoppingCartItemDto
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; } = null!;
        public int Quantity { get; set; }
        public int ShoppingCartId { get; set; }
        public string ProductName { get; set; } = null!;
        public string ProductCategory { get; set; } = null!;
    }
}
