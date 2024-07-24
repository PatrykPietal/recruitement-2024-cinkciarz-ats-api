using Ats.Api.Interfaces;
using Ats.Core.CommandsAndQueries.Customers.Delete;
using Ats.Core.CommandsAndQueries.Customers.Reponse;
using Ats.Core.Models.Customers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ats.Api.Endpoints.Customer
{
	public class DeleteCustomer : IEndpoint
	{
		public void MapEndpoint(IEndpointRouteBuilder app)
		{
			app.MapDelete(Tags.Customers.Url + "/{customerId}",
			async (
					[FromRoute] Guid customerId,

					[FromServices] ISender sender
					) =>
			{
				DeleteCustomerCommand command = new(new CustomerId(customerId));
				await sender.Send(command);
				return Results.Ok();
			})
			.Produces<CustomerResponse>(StatusCodes.Status200OK)
			.WithTags(Tags.Customers.Name)
			//.WithApiVersionSet(apiVersionSet) todo simple inject?
			.MapToApiVersion(1);
			//todo statuses
		}

	}
}
