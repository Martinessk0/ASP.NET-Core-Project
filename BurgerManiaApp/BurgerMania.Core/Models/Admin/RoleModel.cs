using System.ComponentModel.DataAnnotations;
using static BurgerManiaApp.Core.Constants.AdminConstants;

namespace BurgerManiaApp.Core.Models.Admin
{
    public class RoleModel
    {
        public string Id { get; set; } = null!;

        [EmailAddress]
        public string Email { get; set; } = null!;

        [StringLength(NameMaxLength,MinimumLength = NameMinLength)]
        public string Name { get; set; } = null!;

        public List<string> Roles { get; set; } = new List<string>();

        public string Role { get; set; }
    }
}
