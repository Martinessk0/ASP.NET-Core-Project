using BurgerManiaApp.Infractructure.Data.Entities;
using static BurgerManiaApp.Core.Constants.OrderConstants;
using System.ComponentModel.DataAnnotations;

namespace BurgerManiaApp.Core.Models.Order
{
    public class CurrentOrderViewModel
    {
        public int OrderNumber { get; set; }

        public string BuyerId { get; set; } = null!;

        [EmailAddress]
        public string Email { get; set; } = null!;

        [StringLength(FullNameMaxLength, MinimumLength = FullNameMinLength)]
        public string FullName { get; set; } = null!;

        [StringLength(PhoneNumberMaxLength, MinimumLength = PhoneNumberMinLength)]
        public string PhoneNumber { get; set; } = null!;

        [StringLength(OrderStatusNameMaxLength,MinimumLength = OrderStatusNameMinLength)]
        public string OrderStatus { get; set; } = null!;

        public string OrderDate { get; set; } = null!;

        [StringLength(StreetAddressMaxLength, MinimumLength = StreetAddressMinLength)]
        public string DeliveryAddress { get; set; } = null!;

        [StringLength(CityMaxLength, MinimumLength = CityMinLength)]
        public string City { get; set; } = null!;

        [Range(PriceMinRange,PriceMaxRange)]
        public decimal TotalPrice { get; set; }

        public List<ShoppingCartItem> Products { get; set; } = new List<ShoppingCartItem>();
    }
}
