using Ats.Core.Models.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ats.Infrastructure.Configurations
{

	internal sealed class CustomerConfiguration : IEntityTypeConfiguration<Customer>
	{
		public void Configure(EntityTypeBuilder<Customer> builder)
		{
			builder.HasKey(c => c.Id);

			builder.Property(c => c.Id).HasConversion(
				customerId => customerId.Value,
				value => new CustomerId(value));

			builder.HasIndex(r => r.IsDeleted)
				.HasFilter("IsDeleted = 0");
			builder.HasIndex(c => c.GlobalId).IsUnique(true);

			builder.Property(c => c.Address).IsRequired(false);

			builder.Property(c => c.FirstName).HasMaxLength(100);
			builder.Property(c => c.LastName).HasMaxLength(100);
			builder.Property(c => c.Address).HasMaxLength(500);

			builder
				.HasMany(p => p.Transactions)
				.WithOne(c => c.CustomerNavigation)
				.HasForeignKey(c => c.CustomerId)
				.IsRequired(false);
		}
	}
}
