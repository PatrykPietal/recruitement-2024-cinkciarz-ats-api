using Ats.Core.Interfaces.Data.Repositories;
using Ats.Core.Models.Customers;
using Ats.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Ats.Infrastructure.Repositories
{
	internal sealed class CustomerRepository : ICustomerRepository
	{
		private readonly AppDbContext _context;

		public CustomerRepository(AppDbContext context)
		{
			_context = context;
		}
		public Task<Customer?> GetByIdAsync(CustomerId id)
		{
			return _context.Customers
				.SingleOrDefaultAsync(c => c.Id == id);
		}
		public async Task<bool> ExistsGlobalId(string globalId)
		{
			return await _context.Customers.AnyAsync(c => c.GlobalId == globalId);
		}
		public void Add(Customer customer)
		{
			_context.Add(customer);

		}

		public void Remove(Customer customer)
		{
			_context.Remove(customer);
		}

		public void Update(Customer customer)
		{
			_context.Update(customer);
		}
	}
}
