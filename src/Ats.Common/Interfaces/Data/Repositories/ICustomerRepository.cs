using Ats.Core.Models.Customers;

namespace Ats.Core.Interfaces.Data.Repositories
{
	public interface ICustomerRepository
	{
		Task<Customer?> GetByIdAsync(CustomerId id);
		Task<bool> ExistsGlobalId(string globalId);

		void Add(Customer customer);

		void Update(Customer customer);

		void Remove(Customer customer);
	}
}
