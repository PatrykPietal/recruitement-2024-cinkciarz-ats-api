using System.ComponentModel.DataAnnotations.Schema;

namespace Ats.Core.Models.Transactions
{
	[Table("Currency")]
	public class Currency
	{
		public CurrencyId Id { get; private set; }
		public string Name { get; private set; }

		public Currency(CurrencyId id, string name)
		{
			Id = id;
			Name = name;
		}

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
		private Currency()// only for entity framework
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
		{

		}

	}
}
