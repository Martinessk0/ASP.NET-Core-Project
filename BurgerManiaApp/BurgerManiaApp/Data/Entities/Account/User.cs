using BurgerManiaApp.Data.Constants.Account;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace BurgerManiaApp.Data.Entities.Account
{
    public class User : IdentityUser
    {
        [Required]
        [StringLength(UserConstants.UserFisrtNameMaxLength)]
        public string FirstName { get; set; } = null!;
        [Required]
        [StringLength(UserConstants.UserFisrtNameMaxLength)] 
        public string LastName { get; set; } = null!;
        [StringLength(UserConstants.UserAddressMaxLength)]
        public string Address { get; set; } 

    }
}
