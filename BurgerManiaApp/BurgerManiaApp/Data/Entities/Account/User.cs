using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace BurgerManiaApp.Data.Entities.Account
{
    public class User : IdentityUser
    {
        [Required]
        [StringLength(25,MinimumLength = 2)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(25, MinimumLength = 2)] 
        public string LastName { get; set; }
    }
}
