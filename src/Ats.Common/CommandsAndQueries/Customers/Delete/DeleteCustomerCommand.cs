using Ats.Core.Models.Customers;
using MediatR;

namespace Ats.Core.CommandsAndQueries.Customers.Delete
{
	public record DeleteCustomerCommand(CustomerId CustomerId) : IRequest;
}