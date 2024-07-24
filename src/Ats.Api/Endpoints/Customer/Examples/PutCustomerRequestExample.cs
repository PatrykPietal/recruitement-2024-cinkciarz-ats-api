using Ats.Core.CommandsAndQueries.Customers.Update;
using Swashbuckle.AspNetCore.Filters;

namespace Ats.Api.Endpoints.Customer.Examples
{
	public class PutCustomerRequestExample : IExamplesProvider<UpdateCustomerRequest>
	{
		public UpdateCustomerRequest GetExamples()
		{

			return new UpdateCustomerRequest("UpdatedFirstName", "UpdatedLastName", new DateTime(2001, 2, 3), "UpdatedAddress", "UpdatedGlobalId");
		}
	}

}
