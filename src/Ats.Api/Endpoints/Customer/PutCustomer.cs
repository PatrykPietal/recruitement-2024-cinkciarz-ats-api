using Ats.Api.Endpoints.Customer.Examples;
using Ats.Api.Interfaces;
using Ats.Core.CommandsAndQueries.Customers.Reponse;
using Ats.Core.CommandsAndQueries.Customers.Update;
using Ats.Core.Models.Customers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Filters;

namespace Ats.Api.Endpoints.Customer
{
	public class PutCustomer : IEndpoint
	{
		public void MapEndpoint(IEndpointRouteBuilder app)
		{
			app.MapPut(Tags.Customers.Url + "/{customerId}",
			[SwaggerRequestExample(typeof(UpdateCustomerRequest), typeof(PutCustomerRequestExample))]
			async (
					[FromRoute] Guid customerId,

					[FromBody] UpdateCustomerRequest updateCustomerRequest,

					[FromServices] ISender sender
					) =>
			{
				var updateCustomerCommand = new UpdateCustomerCommand(
					new CustomerId(Guid.Parse(customerId.ToString()))
					, updateCustomerRequest.FirstName
					, updateCustomerRequest.LastName
					, updateCustomerRequest.BirthDate
					, updateCustomerRequest.Address
					, updateCustomerRequest.GlobalId);
				await sender.Send(updateCustomerCommand);
				return Results.Ok();
			})
			.Produces<CustomerResponse>(StatusCodes.Status200OK)
			.WithTags(Tags.Customers.Name)
			//.WithApiVersionSet(apiVersionSet) todo simple inject?
			.MapToApiVersion(1);
		}

	}
}
