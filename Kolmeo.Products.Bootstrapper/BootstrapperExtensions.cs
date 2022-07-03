using Kolmeo.Products.Repositories;
using Kolmeo.Products.Repositories.Interfaces;
using Kolmeo.Products.Services;
using Kolmeo.Products.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Kolmeo.Products.Bootstrapper
{
    public static class BootstrapperExtensions
    {
        /// <summary>
        /// Adds all Kolmeo product services and repositories as scoped dependencies.
        /// </summary>
        /// <param name="services">Extension of IServiceCollection.</param>
        /// <returns>Returns altered services collection.</returns>
        public static IServiceCollection AddKolmeoProductServices(this IServiceCollection services)
        {
            // Services
            services.AddScoped<IProductService, ProductService>();

            // Repositories
            services.AddScoped<IProductRepository, ProductRepository>();

            // EF Context
            services.AddDbContext<IKolmeoDbContext, KolmeoDbContext>(options => options.UseInMemoryDatabase(databaseName: "KolmeoProducts"));

            return services;
        }
    }
}