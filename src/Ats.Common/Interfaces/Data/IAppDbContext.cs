using Ats.Core.Models.Customers;
using Ats.Core.Models.Transactions;
using Microsoft.EntityFrameworkCore;

namespace Ats.Core.Interfaces.Data
{
	public interface IAppDbContext
	{
		 DbSet<Transaction> Transactions { get; set; }
		 DbSet<Customer> Customers { get; set; }
		 DbSet<Currency> Currency { get; set; }

		Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

	}
}
