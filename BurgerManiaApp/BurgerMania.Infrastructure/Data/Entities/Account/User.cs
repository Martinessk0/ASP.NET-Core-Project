using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace BurgerManiaApp.Infractructure.Data.Entities.Account
{
    public class User : IdentityUser
    {
        [Required]
        [StringLength(60)]
        public string FirstName { get; set; } = null!;
        [Required]
        [StringLength(60)] 
        public string LastName { get; set; } = null!;
        [StringLength(60)]
        public string Address { get; set; } 

    }
}
