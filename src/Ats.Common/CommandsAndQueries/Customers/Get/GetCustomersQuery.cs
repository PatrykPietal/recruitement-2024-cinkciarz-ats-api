using Ats.Core.CommandsAndQueries.Customers.Reponse;
using MediatR;

namespace Ats.Core.CommandsAndQueries.Customers.Get
{

	public record GetCustomersQuery(
	string? SearchName,
	string? SearchLastName,
	string? SearchAddress,
	string? SortColumn,
	string? SortOrder,
	int Page,
	int PageSize) : IRequest<PagedList<CustomerResponse>>;
}