using static BurgerManiaApp.Core.Constants.OrderConstants;
using BurgerManiaApp.Core.Models.Cart;
using System.ComponentModel.DataAnnotations;

namespace BurgerManiaApp.Core.Models.Order
{
    public class CheckoutViewModel
    {
        public string? OrderNumber { get; set; }

        [StringLength(ZipCodeMaxLength, MinimumLength = ZipCodeMinLength)]
        public string? PostalCode { get; set; }
        [StringLength(StreetAddressMaxLength,MinimumLength = StreetAddressMinLength)]
        public string? StreetAddress { get; set; }

        [StringLength(AddressNameMaxLength, MinimumLength = AddressNameMinLength)]
        public string? AddressName { get; set; }

        [StringLength(CityMaxLength, MinimumLength = CityMinLength)]
        public string? City { get; set; }

        [EmailAddress]
        public string? EmailAddress { get; set; }

        [StringLength(PhoneNumberMaxLength, MinimumLength = PhoneNumberMinLength)]
        public string? PhoneNumber { get; set; }

        [Required]
        [StringLength(FirstNameMaxLength, MinimumLength = FirstNameMinLength)]
        public string? FirstName { get; set; }

        [Required]
        [StringLength(LastNameMaxLength, MinimumLength = LastNameMinLength)]
        public string? LastName { get; set; }


        public ShoppingCartDto? UserCart { get; set; }

        public ICollection<ShoppingCartItemDto>? CartItems { get; set; }

        public decimal TotalPrice()
        {
            return Math.Round(UserCart.CartItems.Sum(x => x.Price * x.Quantity), 2);
        }
    }
}
