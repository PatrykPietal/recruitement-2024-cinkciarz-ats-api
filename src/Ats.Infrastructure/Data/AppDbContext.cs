using Ats.Core.Interfaces.Data;
using Ats.Core.Models.Customers;
using Ats.Core.Models.Transactions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Ats.Infrastructure.Data
{
	public class AppDbContext : DbContext, IAppDbContext, IUnitOfWork
	{
		private readonly IPublisher _publisher;

		public AppDbContext(DbContextOptions options, IPublisher publisher)
			: base(options)
		{
			_publisher = publisher;
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
		}

		public DbSet<Transaction> Transactions { get; set; }
		public DbSet<Customer> Customers { get; set; }
		public DbSet<Currency> Currency { get; set; }

	}
}
