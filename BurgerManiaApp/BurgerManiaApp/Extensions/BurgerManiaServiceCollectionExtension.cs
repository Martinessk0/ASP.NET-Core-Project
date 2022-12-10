using BurgerManiaApp.Core.Contracts;
using BurgerManiaApp.Core.Contracts.Admin;
using BurgerManiaApp.Core.Services;
using BurgerManiaApp.Core.Services.Admin;
using BurgerManiaApp.Core.Services.Deliverer;
using BurgerManiaApp.Core.Contracts.Deliverer;
using BurgerManiaApp.Infractructure.Data.Common;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class BurgerManiaServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IRepository, Repository>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICartService, CartService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IDelivererOrderService, DelivererOrderService>();

            return services;
        }
    }
}
