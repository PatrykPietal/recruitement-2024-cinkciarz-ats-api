using Ats.Api.Endpoints.Customer.Examples;
using Ats.Api.Interfaces;
using Ats.Core.CommandsAndQueries.Customers.Create;
using Ats.Core.CommandsAndQueries.Customers.Reponse;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Filters;

namespace Ats.Api.Endpoints.Customer
{
	public class PostCustomer : IEndpoint
	{
		public void MapEndpoint(IEndpointRouteBuilder app)
		{
			app.MapPost(Tags.Customers.Url,
			[SwaggerRequestExample(typeof(CreateCustomerCommand), typeof(PostCustomerRequestExamples))]
			async (
					[FromBody] CreateCustomerCommand createCustomerCommand,

					[FromServices] IValidator<CreateCustomerCommand> validator,
					[FromServices] ISender sender
					) =>
			{

				var validationResult = await validator.ValidateAsync(createCustomerCommand);

				if (!validationResult.IsValid)
				{
					return Results.ValidationProblem(validationResult.ToDictionary());
				}

				var customer = await sender.Send(createCustomerCommand);
				return Results.Created($"{Tags.Customers.Url}/{customer.Id.Value}", customer);
			})
			.Produces<CustomerResponse>(StatusCodes.Status201Created)
			.WithTags(Tags.Customers.Name)
			//.WithApiVersionSet(apiVersionSet) todo simple inject?
			.MapToApiVersion(1);
		}

	}
}
