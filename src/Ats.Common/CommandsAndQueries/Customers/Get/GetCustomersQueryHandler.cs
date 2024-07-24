using Ats.Core.CommandsAndQueries.Customers.Reponse;
using Ats.Core.Interfaces.Data;
using Ats.Core.Models.Customers;
using MediatR;
using System.Linq.Expressions;

namespace Ats.Core.CommandsAndQueries.Customers.Get
{

	internal sealed class GetCustomersQueryHandler(IAppDbContext context) : IRequestHandler<GetCustomersQuery, PagedList<CustomerResponse>>
	{
		public async Task<PagedList<CustomerResponse>> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
		{
			IQueryable<Customer> customersQuery = context.Customers.AsQueryable();

			if (!string.IsNullOrWhiteSpace(request.SearchName))
			{
				customersQuery = customersQuery.Where(c => c.FirstName.Contains(request.SearchName, StringComparison.OrdinalIgnoreCase));
			}
			if (!string.IsNullOrWhiteSpace(request.SearchLastName))
			{
				customersQuery = customersQuery.Where(c => c.LastName.Contains(request.SearchLastName, StringComparison.OrdinalIgnoreCase));
			}
			if (!string.IsNullOrWhiteSpace(request.SearchAddress))
			{
				customersQuery = customersQuery.Where(c => c.Address != null && c.Address.Contains(request.SearchAddress, StringComparison.OrdinalIgnoreCase));
			}

			if (request.SortOrder is not null && string.Equals(request.SortOrder, "desc", StringComparison.OrdinalIgnoreCase))
			{
				customersQuery = customersQuery.OrderByDescending(GetSortProperty(request));
			}
			else
			{
				customersQuery = customersQuery.OrderBy(GetSortProperty(request));
			}

			var customerResponsesQuery = customersQuery
				.Select(c => new CustomerResponse(
					c.Id.Value,
					c.FirstName,
					c.LastName,
					c.BirthDate,
					c.Address,
					c.GlobalId));

			var customers = await PagedList<CustomerResponse>.CreateAsync(
				customerResponsesQuery,
				request.Page,
				request.PageSize);

			return customers;
		}

#pragma warning disable CS8603 // Possible null reference return. 
		private static Expression<Func<Customer, object>> GetSortProperty(GetCustomersQuery request) =>
			request.SortColumn?.ToLower() switch
			{
				"firstname" => customer => customer.FirstName,
				"lastname" => customer => customer.LastName,
				"birthdate" => customer => customer.BirthDate,
				"address" => customer => customer.Address,
				"globalid" => customer => customer.GlobalId,
				_ => customer => customer.Id.Value
			};
#pragma warning restore CS8603 // Possible null reference return.
	}
}