using Microsoft.EntityFrameworkCore;
using Service_Product.Data.Repository;
using Service_Product.Data.Repository.Interface;
using Service_Product.Service.Interface;
using Service_Product.Service;
using Service_Product.Data;

namespace Service_Product.IoC
{
    public static class IoCApplicationTest
    {
        public static IServiceCollection ConfigureInjectionDependencyRepositoryTest(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();

            return services;
        }

        public static IServiceCollection ConfigureInjectionDependencyServiceTest(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();

            return services;
        }

        public static IServiceCollection ConfigureDBContextTest(this IServiceCollection services)
        {
            services.AddDbContext<ProductDbContext>(options =>
                options.UseInMemoryDatabase(databaseName: "TestApplication")
            );

            return services;
        }
    }
}
