using Ats.Core.Models.Transactions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ats.Infrastructure.Configurations
{
	internal sealed class CurrencyConfiguration : IEntityTypeConfiguration<Currency>
	{
		public void Configure(EntityTypeBuilder<Currency> builder)
		{

			builder.HasKey(c => c.Id);

			builder.Property(c => c.Id).HasConversion(
				currencyId => currencyId.Value,
				value => new CurrencyId(value));


		}
	}
}
