using Ats.Api.Interfaces;

namespace Ats.Api.Extensions
{
	internal static class BuilderExtensions
	{

		internal static IApplicationBuilder MapEndpoints(this WebApplication app, RouteGroupBuilder? routeGroupBuilder = null)
		{
			IEnumerable<IEndpoint> endpoints = app.Services.GetRequiredService<IEnumerable<IEndpoint>>();

			IEndpointRouteBuilder builder = routeGroupBuilder is null ? app : routeGroupBuilder;

			foreach (IEndpoint endpoint in endpoints)
			{
				endpoint.MapEndpoint(builder);
			}

			return app;
		}

	}
}
