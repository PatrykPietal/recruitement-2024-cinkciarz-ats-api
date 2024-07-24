using Ats.Core.Interfaces.Data;
using Ats.Core.Interfaces.Data.Repositories;
using Ats.Infrastructure.Data;
using Ats.Infrastructure.Interceptors;
using Ats.Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace Ats.Infrastructure
{
	public static class DependencyInjection
	{

		public static IServiceCollection AddInfrastructure(this IServiceCollection services, bool isProd, IConfiguration configuration)
		{
			services.AddSingleton<SoftDeleteInterceptor>();
			// DB
			if (isProd)
			{
				Console.WriteLine("--> Using SqlServer DB");
				services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("SqlAts")));
			}
			else
			{ //inital stage: testing inmem then testing on sql server (then todo add migration)
				Console.WriteLine("--> Using InMem DB");
				services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("InMemAts"));
			}

			services.AddScoped<IAppDbContext>(sp =>
				sp.GetRequiredService<AppDbContext>());

			services.AddScoped<IUnitOfWork>(sp =>
				sp.GetRequiredService<AppDbContext>());

			services.AddScoped<ICustomerRepository, CustomerRepository>();


			return services;
		}

		public static IApplicationBuilder AddInfrastructure(this IApplicationBuilder app, bool isProd)
		{
			using var serviceScope = app.ApplicationServices.CreateScope();
			{
				PrepDb.SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>()!, isProd);
			}
			return app;
		}
	}
}
