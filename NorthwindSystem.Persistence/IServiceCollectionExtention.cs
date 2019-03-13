using Microsoft.Extensions.DependencyInjection;
using NorthwindSystem.Persistence.Implementation;
using NorthwindSystem.Persistence.Interface;


namespace NorthwindSystem.Persistence
{
    public static class IServiceCollectionExtention
    {
        public static void RegisterPersistenceServices(this IServiceCollection services)
        {
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
        }
    }
}
