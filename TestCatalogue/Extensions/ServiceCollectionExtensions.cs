using Microsoft.EntityFrameworkCore;
using TestCatalogue.DAL.EF;
using TestCatalogue.DAL.Interfaces;
using TestCatalogue.DAL.Repositories;
using TestCatalogue.BLL.Interfaces;
using TestCatalogue.BLL.Services;

namespace TestCatalogue.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddPGDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            // Configure DbContext with Scoped lifetime  
            services.AddDbContext<CatalogueContext>(options =>
            {
                options.UseNpgsql(configuration["ConnectionStrings:PGConnection"]);
            }
            );
            services.AddScoped<IUnitOfWork, CatalogueUnitOfWork>();
            return services;
        }
        ///
        /// Add instances of in-use services
        /// 
        ///
        /// 
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            return services.AddScoped<ICatalogueService, CatalogueService>();
        }
    }
}
