using BurgerManiaApp.Core.Contracts;
using System.Text;
using System.Text.RegularExpressions;

namespace BurgerManiaApp.Core.Extensions
{
    public static class ModelExtensions
    {
        public static string GetInformation(this IProductModel product)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(product.Name.Replace(" ", "-"));
            sb.Append("-");
            sb.Append(GetDescription(product.Description));

            return sb.ToString();
        }

        private static string GetDescription(string address)
        {
            string result = string
                .Join("-", address.Split(" ", StringSplitOptions.RemoveEmptyEntries).Take(2));
            
            return Regex.Replace(address, @"[^a-zA-Z0-9\-]", string.Empty);
        }
    }
}
