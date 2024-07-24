using Ats.Infrastructure;
using Ats.Infrastructure.Behaviors;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
namespace Ats.Core
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddCore(this IServiceCollection services)
		{

			//fluentValidation
			services.AddValidatorsFromAssembly(ApplicationAssemblyReference.Assembly);
			//automapper 

			services.AddAutoMapper(ApplicationAssemblyReference.Assembly);
			// MediatR
			services.AddMediatR(config =>
			{
				config.RegisterServicesFromAssemblyContaining<ApplicationAssemblyReference>();

				config.AddOpenBehavior(typeof(UnitOfWorkBehavior<,>));
			});

			services.AddValidatorsFromAssembly(ApplicationAssemblyReference.Assembly);

			return services;
		}
	}
}
