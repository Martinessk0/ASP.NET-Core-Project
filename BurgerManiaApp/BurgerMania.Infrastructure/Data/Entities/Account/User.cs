using BurgerManiaApp.Infrastructure.Data.Entities;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using static BurgerManiaApp.Infrastructure.Data.Constants.UserConstants;

namespace BurgerManiaApp.Infractructure.Data.Entities.Account
{
    public class User : IdentityUser
    {
        [Required]
        [StringLength(FirstNameMaxLength)]
        public string FirstName { get; set; } = null!;
        [Required]
        [StringLength(LastNameMaxLength)] 
        public string LastName { get; set; } = null!;
        [StringLength(AddressMaxLength)]
        public string Address { get; set; } = null!;

        public List<UserOrder> UserOrders { get; set; } = new List<UserOrder>();

    }
}
