using Ats.Api.Interfaces;
using Ats.Core.CommandsAndQueries.Customers.GetById;
using Ats.Core.CommandsAndQueries.Customers.Reponse;
using Ats.Core.Models.Customers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ats.Api.Endpoints.Customer
{
	public class GetCustomer : IEndpoint
	{
		public void MapEndpoint(IEndpointRouteBuilder app)
		{
			app.MapGet(Tags.Customers.Url + "/{customerId}",
			async (
					[FromRoute] Guid customerId,

					[FromServices] ISender sender) =>
			{

				var query = new GetCustomerQuery(new CustomerId(customerId));
				try //if would have more time i would use result pattern
				{
					return Results.Ok(await sender.Send(query));
				}
				catch (CustomerNotFoundException e)
				{
					return Results.NotFound(e.Message);
				}
			})
			.Produces<CustomerResponse>(StatusCodes.Status200OK)
			.Produces(StatusCodes.Status404NotFound)
			.WithTags(Tags.Customers.Name)
			//.WithApiVersionSet(apiVersionSet) todo simple inject?
			.MapToApiVersion(1);
		}

	}
}
