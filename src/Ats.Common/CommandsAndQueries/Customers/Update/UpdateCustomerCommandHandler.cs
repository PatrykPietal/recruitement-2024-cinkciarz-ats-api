using Ats.Core.Interfaces.Data.Repositories;
using Ats.Core.Models.Customers;
using MediatR;


namespace Ats.Core.CommandsAndQueries.Customers.Update
{
	internal sealed class UpdateCustomerCommandHandler(ICustomerRepository customerRepository) : IRequestHandler<UpdateCustomerCommand>
	{
		public async Task Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
		{
			var customer = await customerRepository.GetByIdAsync(request.CustomerId);

			if (customer is null)
			{
				throw new CustomerNotFoundException(request.CustomerId);
			}
			customer.Update(
				request.FirstName,
				request.LastName,
				request.BirthDate,
				request.Address,
				request.GlobalId);

			customerRepository.Update(customer);
		}
	}
}