using Ats.Api.Interfaces;
using Ats.Core.CommandsAndQueries.Customers.Get;
using Ats.Core.CommandsAndQueries.Customers.Reponse;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ats.Api.Endpoints.Customer
{
	public class GetCustomers : IEndpoint
	{
		public void MapEndpoint(IEndpointRouteBuilder app)
		{

			app.MapGet(Tags.Customers.Url,
			async (
					[FromQuery] string? SearchName,
					[FromQuery] string? SearchLastName,
					[FromQuery] string? SearchAddress,
					[FromQuery] string? SortColumn,
					[FromQuery] string? SortOrder,

					[FromServices] IValidator<GetCustomersQuery> validator,
					[FromServices] ISender sender,

					[FromQuery] int Page = 1,
					[FromQuery] int PageSize = 100
					) =>
			{
				var query = new GetCustomersQuery(SearchName, SearchLastName, SearchAddress, SortColumn, SortOrder, Page, PageSize);

				var validationResult = await validator.ValidateAsync(query);

				if (!validationResult.IsValid)
				{
					return Results.ValidationProblem(validationResult.ToDictionary());
				}
				return Results.Ok(await sender.Send(query));
			})
			.Produces<CustomerResponse>(StatusCodes.Status200OK)
			.WithTags(Tags.Customers.Name)
			//.WithApiVersionSet(apiVersionSet) todo simple inject?
			.MapToApiVersion(1);
		}

	}
}
