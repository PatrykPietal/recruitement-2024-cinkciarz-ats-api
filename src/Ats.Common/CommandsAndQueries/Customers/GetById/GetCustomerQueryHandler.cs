using Ats.Core.CommandsAndQueries.Customers.Reponse;
using Ats.Core.Interfaces.Data;
using Ats.Core.Models.Customers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Ats.Core.CommandsAndQueries.Customers.GetById
{

	public sealed class GetCustomerQueryHandler(IAppDbContext context) : IRequestHandler<GetCustomerQuery, CustomerResponse>
	{
		public async Task<CustomerResponse> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
		{
			var customer = await context
				.Customers
				.Where(c => c.Id == request.CustomerId)
				.Select(c => new CustomerResponse(
					c.Id.Value,
					c.FirstName,
					c.LastName,
					c.BirthDate,
					c.Address,
					c.GlobalId))
				.SingleOrDefaultAsync(cancellationToken);

			if (customer is null)
			{
				throw new CustomerNotFoundException(request.CustomerId);
			}

			return customer;
		}
	}
}