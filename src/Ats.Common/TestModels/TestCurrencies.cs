using Ats.Core.Models.Transactions;

namespace Ats.Core.TestModels
{
	public static class TestCurrencies
	{
		public static Currency Usd { get; } = new Currency(new CurrencyId(Guid.Parse("c4580000-1111-4562-b3fc-2c963f66afa6")), "USD");
		public static Currency Pln { get; } = new Currency(new CurrencyId(Guid.Parse("c4580000-2222-4562-b3fc-2c963f66afa6")), "PLN");
		public static Currency Eur { get; } = new Currency(new CurrencyId(Guid.Parse("c4580000-3333-4562-b3fc-2c963f66afa6")), "EUR");

		public static IList<Currency> GetAllTestCurrencies() => [Usd, Pln, Eur];
	}
}
