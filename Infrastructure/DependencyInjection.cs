using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PlainDotNetApi.Data;
using PlainDotNetApi.Data.Repositories.Cart;
using PlainDotNetApi.Data.Repositories.Cart.Interfaces;
using PlainDotNetApi.Data.Repositories.Product;
using PlainDotNetApi.Data.Repositories.Product.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlainDotNetApi.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<PGDatabaseContext>(options =>
                options.UseNpgsql(
                    Configuration.GetConnectionString("DefaultConnection"),
                    x => x.MigrationsAssembly(typeof(PGDatabaseContext).Assembly.FullName)
                ));

            return services;
        }

        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerDocument(configure =>
            {
                configure.PostProcess = (document) =>
                {
                    document.Info.Version = "v1";
                    document.Info.Title = "Plain DotNet Api";
                    document.Info.Description = ".NET Core Web API";
                };
            });

            return services; 
        }

        public static IServiceCollection RegisterDI(this IServiceCollection services)
        {
            services.AddScoped<ICartRepository, CartRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();

            return services;
        }
    }
}
