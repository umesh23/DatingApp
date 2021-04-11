using API.Data;
using API.Interfaces;
using API.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
                 services.AddScoped<ITokenService,TokenService>();
            //register datacontext in startup
            services.AddDbContext<DataContext>(options =>
            {
                //add this connection in json file and read it
                options.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            });

            return services;
        }
        
    }
}