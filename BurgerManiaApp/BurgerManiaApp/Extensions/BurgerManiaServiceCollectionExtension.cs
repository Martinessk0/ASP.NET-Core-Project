using BurgerManiaApp.Core.Contracts;
using BurgerManiaApp.Core.Services;
using BurgerManiaApp.Infractructure.Data.Common;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class BurgerManiaServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IRepository, Repository>();
            services.AddScoped<IProductService, ProductService>();

            return services;
        }
    }
}
