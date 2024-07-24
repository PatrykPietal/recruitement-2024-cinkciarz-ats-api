using Ats.Core.Models.Customers;
using MediatR;

namespace Ats.Core.CommandsAndQueries.Customers.Create
{
	public record CreateCustomerCommand(string FirstName, string LastName, DateTime BirthDate, string? Address, string GlobalId) : IRequest<Customer>;
}