using Ats.Core.Models.Customers;
using MediatR;


namespace Ats.Core.CommandsAndQueries.Customers.Update
{
	public record UpdateCustomerCommand(CustomerId CustomerId, string FirstName, string LastName, DateTime BirthDate, string? Address, string GlobalId) : IRequest;

	public record UpdateCustomerRequest(string FirstName, string LastName, DateTime BirthDate, string? Address, string GlobalId);
}