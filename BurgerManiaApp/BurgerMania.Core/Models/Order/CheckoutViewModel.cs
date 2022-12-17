using static BurgerManiaApp.Core.Constants.OrderConstants;
using BurgerManiaApp.Core.Models.Cart;
using System.ComponentModel.DataAnnotations;

namespace BurgerManiaApp.Core.Models.Order
{
    public class CheckoutViewModel
    {
        public string? OrderNumber { get; set; }

        [Required]
        [StringLength(ZipCodeMaxLength, MinimumLength = ZipCodeMinLength)]
        public string PostalCode { get; set; }  = null!;

        [Required]
        [StringLength(StreetAddressMaxLength,MinimumLength = StreetAddressMinLength)]
        public string StreetAddress { get; set; } = null!;

        [Required]
        [StringLength(AddressNameMaxLength, MinimumLength = AddressNameMinLength)]
        public string AddressName { get; set; } = null!;

        [StringLength(CityMaxLength, MinimumLength = CityMinLength)]
        public string City { get; set; } = null!;

        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; } = null!;

        [Required]
        [StringLength(PhoneNumberMaxLength, MinimumLength = PhoneNumberMinLength)]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        [StringLength(FirstNameMaxLength, MinimumLength = FirstNameMinLength)]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(LastNameMaxLength, MinimumLength = LastNameMinLength)]
        public string LastName { get; set; } = null!;


        public ShoppingCartDto? UserCart { get; set; }

        public ICollection<ShoppingCartItemDto>? CartItems { get; set; }

        public decimal TotalPrice()
        {
            return Math.Round(UserCart.CartItems.Sum(x => x.Price * x.Quantity), 2);
        }
    }
}
