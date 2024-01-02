using Microsoft.EntityFrameworkCore;
using Service_Product.Data.Repository;
using Service_Product.Data.Repository.Interface;
using Service_Product.Service.Interface;
using Service_Product.Service;
using Service_Product.Data;

namespace Service_Product.IoC
{
    public static class IoCApplication
    {
        public static IServiceCollection ConfigureInjectionDependencyRepository(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();

            return services;
        }

        public static IServiceCollection ConfigureInjectionDependencyService(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();

            return services;
        }

        public static IServiceCollection ConfigureDBContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ProductDbContext>(options =>
                options.UseSqlServer(connectionString));


            return services;
        }
    }
}
