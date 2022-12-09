using BurgerManiaApp.Core.Models.Cart;
using BurgerManiaApp.Infractructure.Data.Entities;
using BurgerManiaApp.Infrastructure.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerManiaApp.Core.Models.Order
{
    public class CurrentOrderViewModel
    {
        public int OrderNumber { get; set; }
        public string BuyerId { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string OrderStatus { get; set; } = null!;
        public string OrderDate { get; set; } = null!; 
        public string DeliveryAddress { get; set; } = null!;
        public string City { get; set; } = null!;
        public decimal TotalPrice { get; set; }
        public List<ShoppingCartItem> Products { get; set; } = new List<ShoppingCartItem>();
    }
}
