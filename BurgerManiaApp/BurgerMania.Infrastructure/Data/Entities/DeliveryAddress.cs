using static BurgerManiaApp.Infrastructure.Data.Constants.DeliveryAddressConstants;
using System.ComponentModel.DataAnnotations;

namespace BurgerManiaApp.Infrastructure.Data.Entities
{
    public class DeliveryAddress
    {
        public DeliveryAddress(string streetAddress, string zipCode, string city, string? name)
        {
            StreetAddress = streetAddress;
            ZipCode = zipCode;
            City = city;
            Name = name;
        }
        [Key]
        public int Id { get; set; }
        [StringLength(StreetAddressMaxLength)]
        public string StreetAddress { get; set; }
        [StringLength(ZipCodeMaxLength)]
        public string ZipCode { get; set; }
        [StringLength(CityMaxLength)]
        public string City { get; set; }
        [StringLength(NameMaxLength)]
        public string? Name { get; set; }
    }
}
