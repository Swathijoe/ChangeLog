using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace WebApi.Extensions
{
	public static class ServiceCollectionExtensions
	{		
		public static IServiceCollection AddJwtBearerAuthentication(this IServiceCollection serviceCollection, IConfiguration configuration)
		{
			var key = Encoding.ASCII.GetBytes(configuration.GetSection("AppSettings").GetValue<string>("ApiKey"));			

			serviceCollection
				.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
				.AddJwtBearer(options =>
				{
					options.RequireHttpsMetadata = false;
					options.SaveToken = true;
					options.TokenValidationParameters = new TokenValidationParameters
					{
						ValidateIssuerSigningKey = true,
						IssuerSigningKey = new SymmetricSecurityKey(key),
						ValidateIssuer = false,
						ValidateAudience = false						
					};
				});

			return serviceCollection;
		}
	}
}
