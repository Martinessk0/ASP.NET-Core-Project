using System.Security.Claims;

namespace BurgerManiaApp.Extensions
{
    public static class ClaimPrincipalExtension
    {
        public static string Id(this ClaimsPrincipal user)
        {
             return user.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
