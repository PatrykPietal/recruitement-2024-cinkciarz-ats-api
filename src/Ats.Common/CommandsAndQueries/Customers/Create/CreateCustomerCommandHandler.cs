using Ats.Core.Interfaces.Data.Repositories;
using Ats.Core.Models.Customers;
using MediatR;

namespace Ats.Core.CommandsAndQueries.Customers.Create
{

	internal class CreateCustomerCommandHandler(ICustomerRepository productRepository) : IRequestHandler<CreateCustomerCommand, Customer>
	{
		private readonly ICustomerRepository _customerRepository = productRepository;

		public Task<Customer> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
		{
			var customer = new Customer(
				new CustomerId(Guid.NewGuid()),
				request.FirstName,
				request.LastName,
				request.BirthDate,
				request.GlobalId,
				request.Address);//todo fluentvalidation

			_customerRepository.Add(customer);

			return Task.FromResult(customer);
		}
	}
}
