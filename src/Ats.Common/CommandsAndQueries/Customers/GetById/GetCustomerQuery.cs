using Ats.Core.CommandsAndQueries.Customers.Reponse;
using Ats.Core.Models.Customers;
using MediatR;


namespace Ats.Core.CommandsAndQueries.Customers.GetById
{
	public record GetCustomerQuery(CustomerId CustomerId) : IRequest<CustomerResponse>;

}