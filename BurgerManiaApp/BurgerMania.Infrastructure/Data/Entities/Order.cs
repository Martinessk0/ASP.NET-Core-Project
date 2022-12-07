using BurgerManiaApp.Infractructure.Data.Entities;
using BurgerManiaApp.Infractructure.Data.Entities.Account;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerManiaApp.Infrastructure.Data.Entities
{
    public class Order
    {
        public Order(string buyerId)
        {
            BuyerId = buyerId;
        }
        [Key]
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public string BuyerId { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTimeOffset OrderDate { get; private set; } = DateTimeOffset.Now;
        public DeliveryAddress DeliveryAddress { get; set; }
        public int DeliveryAddressId { get; set; }
        public List<ShoppingCartItem> Products { get; set; } = new List<ShoppingCartItem>();

        [Required]
        public int OrderStatusId { get; set; }
        [ForeignKey(nameof(OrderStatusId))]
        public OrderStatus OrderStatus { get; set; }

        public decimal TotalOrderPrice()
        {
            var total = 0m;

            foreach (var item in Products)
            {
                total += item.Price * item.Quantity;
            }
            return total;
        }
    }
}
