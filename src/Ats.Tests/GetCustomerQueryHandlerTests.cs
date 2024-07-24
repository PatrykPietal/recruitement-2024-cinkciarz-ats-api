using Ats.Core.CommandsAndQueries.Customers.GetById;
using Ats.Core.Interfaces.Data;
using Ats.Core.Models.Customers;
using Moq;
using Moq.EntityFrameworkCore;

namespace Ats.Common.Tests.CommandsAndQueries.Customers.GetById
{
	public class GetCustomerQueryHandlerTests
	{
		[Fact]
		public async Task Handle_WithExistingCustomerId_ReturnsCustomerResponse()
		{
			// Arrange
			var customerId = new CustomerId(Guid.NewGuid());
			var customer = new Customer(customerId, "John", "Doe", new DateTime(1990, 1, 1), "ABC123", "123 Main St");
			var customers = new List<Customer> { customer }.AsQueryable();

			var dbMock = new Mock<IAppDbContext>();
			dbMock.Setup(x => x.Customers).ReturnsDbSet(customers);

			var query = new GetCustomerQuery(customerId);
			var handler = new GetCustomerQueryHandler(dbMock.Object);

			// Act
			var result = await handler.Handle(query, CancellationToken.None);


			// Assert
			Assert.NotNull(result);
			Assert.Equivalent(customerId.Value, result.Id);
			Assert.Equivalent("John", result.FirstName);
			Assert.Equivalent("Doe", result.LastName);
			Assert.Equivalent(new DateTime(1990, 1, 1), result.BirthDate);
			Assert.Equivalent("123 Main St", result.Address);
			Assert.Equivalent("ABC123", result.GlobalId);
		}

		[Fact]
		public async Task Handle_WithNonExistingCustomerId_ThrowsCustomerNotFoundException()
		{
			// Arrange
			var customerId = new CustomerId(Guid.NewGuid());
			var customer = new Customer(customerId, "John", "Doe", new DateTime(1990, 1, 1), "ABC123", "123 Main St");
			var customers = new List<Customer> { customer }.AsQueryable();

			var dbMock = new Mock<IAppDbContext>();
			dbMock.Setup(x => x.Customers).ReturnsDbSet(customers);

			var customerIdNotInDb = new CustomerId(Guid.NewGuid());

			var query = new GetCustomerQuery(customerIdNotInDb);
			var handler = new GetCustomerQueryHandler(dbMock.Object);

			// Act
			Func<Task> act = async () => await handler.Handle(query, CancellationToken.None);

			// Assert
			await Assert.ThrowsAsync<CustomerNotFoundException>(act);
		}
	}
}
