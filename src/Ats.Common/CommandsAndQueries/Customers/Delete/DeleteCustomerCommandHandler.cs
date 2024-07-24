using Ats.Core.Interfaces.Data.Repositories;
using Ats.Core.Models.Customers;
using MediatR;

namespace Ats.Core.CommandsAndQueries.Customers.Delete
{
	internal sealed class DeleteCustomerCommandHandler(ICustomerRepository productRepository) : IRequestHandler<DeleteCustomerCommand>
	{
		public async Task Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
		{
			var customer = await productRepository.GetByIdAsync(request.CustomerId);

			if (customer is null)
			{
				throw new CustomerNotFoundException(request.CustomerId);
			}

			productRepository.Remove(customer);
		}
	}
}