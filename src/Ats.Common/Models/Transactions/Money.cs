namespace Ats.Core.Models.Transactions
{
	public class Money
	{
		public decimal Amount { get; private set; }
		public Currency Currency { get; private set; }

		public Money(decimal amount, Currency currency)
		{
			Amount = amount;
			Currency = currency;
		}
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
		private Money()// only for entity framework
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
		{

		}
	}
}
