using Ats.Core.Models.Transactions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ats.Infrastructure.Configurations
{
}
internal sealed class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
{
	public void Configure(EntityTypeBuilder<Transaction> builder)
	{

		builder.HasKey(c => c.Id).IsClustered(false);

		builder.HasIndex(r => r.Date).IsClustered(true);


		builder.OwnsOne(c => c.Amount);

		//it would be even better to add table with enum values for other microservices to use
		builder.Property(c => c.Type).HasConversion<byte>();
		builder.Property(c => c.Status).HasConversion<byte>();

		builder.Property(c => c.Id).HasConversion(
			transactionId => transactionId.Value,
			value => new TransactionId(value));

		builder.Property(c => c.Description).IsRequired(false);

		builder
			.HasOne(t => t.CustomerNavigation)
			.WithMany(c => c.Transactions)
			.HasForeignKey(c => c.CustomerId)
			.IsRequired();

		builder.HasQueryFilter(c => !c.IsDeleted);

		builder.HasIndex(r => r.IsDeleted)
			.HasFilter("IsDeleted = 0");
	}
}
