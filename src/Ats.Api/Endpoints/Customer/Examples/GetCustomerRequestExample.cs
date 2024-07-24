using Ats.Core.TestModels;
using Swashbuckle.AspNetCore.Filters;

namespace Ats.Api.Endpoints.Customer.Examples
{
	public class GetCustomerRequestExample : IExamplesProvider<Guid>
	{
		Guid IExamplesProvider<Guid>.GetExamples()
		{
			return TestCustomers.JohnNoaddress.Id.Value;
		}
	}

}
