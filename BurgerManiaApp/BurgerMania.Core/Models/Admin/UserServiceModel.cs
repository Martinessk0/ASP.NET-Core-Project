using System.ComponentModel.DataAnnotations;
using static BurgerManiaApp.Core.Constants.AdminConstants;

namespace BurgerManiaApp.Core.Models.Admin
{
    public class UserServiceModel
    {
        public string Id { get; set; } = null!;

        [EmailAddress]
        public string Email { get; init; } = null!;

        [StringLength(FullNameMaxLength, MinimumLength = FullNameMinLength)]
        public string FullName { get; init; } = null!;

        [StringLength(PhoneNumberMaxLength, MinimumLength = PhoneNumberMinLength)]
        public string PhoneNumber { get; init; } = null!;

        public List<string> Roles { get; set; } = new List<string>();
    }
}
