
namespace Microsoft.Extensions.DependencyInjection
{
    public static class BurgerManiaServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            //services.AddScoped<IRepository, Repository>();

            return services;
        }
    }
}
