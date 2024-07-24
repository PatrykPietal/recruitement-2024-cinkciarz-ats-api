using Ats.Core.CommandsAndQueries.Customers.Create;
using Ats.Core.TestModels;
using AutoMapper;
using Swashbuckle.AspNetCore.Filters;

namespace Ats.Api.Endpoints.Customer.Examples
{

	public class PostCustomerRequestExamples(IMapper mapper) : IMultipleExamplesProvider<CreateCustomerCommand>
	{
		public IEnumerable<SwaggerExample<CreateCustomerCommand>> GetExamples()
		{
			yield return SwaggerExample.Create("No Optionals", mapper.Map<CreateCustomerCommand>(TestCustomers.EmilyNoaddress));

			yield return SwaggerExample.Create("With Optionals", mapper.Map<CreateCustomerCommand>(TestCustomers.DavidWithaddress));
		}
	}

}
