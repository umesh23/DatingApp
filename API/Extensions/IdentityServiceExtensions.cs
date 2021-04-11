using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace API.Extensions
{
    public static class IdentityServiceExtensions
    {

        public static IServiceCollection AddIdentityServices(this IServiceCollection services, Microsoft.Extensions.Configuration.IConfiguration config)
        {
             services.AddAuthentication(Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options=>{
                   options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters{
                       ValidateIssuerSigningKey=true,
                       IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"])),
                       ValidateIssuer = false,
                       ValidateAudience = false
                   };
                });

                return services;

        }
        
    }
}