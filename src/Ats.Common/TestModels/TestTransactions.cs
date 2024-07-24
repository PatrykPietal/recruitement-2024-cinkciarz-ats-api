using Ats.Core.Models.Transactions;

namespace Ats.Core.TestModels
{
	public static class TestTransactions
	{
		public static readonly Transaction TransactionDepositJohnUsdSmallWdescription = new(new TransactionId(Guid.NewGuid()), new Money(1000, TestCurrencies.Usd), DateTime.UtcNow, TransactionType.Deposit, TestCustomers.JohnNoaddress, "test description");
		public static readonly Transaction TransactionWithdrawEmilyEurBigNodescription = new(new TransactionId(Guid.NewGuid()), new Money(20000, TestCurrencies.Eur), DateTime.UtcNow, TransactionType.Withdrawal, TestCustomers.EmilyNoaddress.Id);
		public static readonly Transaction TransactionTransferDavidPlnBigWdescription = new(new TransactionId(Guid.NewGuid()), new Money(999999, TestCurrencies.Pln), DateTime.UtcNow, TransactionType.Transfer, TestCustomers.DavidWithaddress.Id, "dog shelter dep");
		public static readonly Transaction TransactionDepositMichaelUsdSmallWdescription1 = new(new TransactionId(Guid.NewGuid()), new Money(1900, TestCurrencies.Usd), DateTime.UtcNow, TransactionType.Deposit, TestCustomers.MichaelNoaddres, "test description1");
		public static readonly Transaction TransactionDepositMichaelUsdSmallWdescription2 = new(new TransactionId(Guid.NewGuid()), new Money(1900, TestCurrencies.Usd), DateTime.UtcNow, TransactionType.Deposit, TestCustomers.MichaelNoaddres, "test description2");
		public static readonly Transaction TransactionDepositMichaelUsdSmallWdescription3 = new(new TransactionId(Guid.NewGuid()), new Money(1900, TestCurrencies.Usd), DateTime.UtcNow, TransactionType.Deposit, TestCustomers.MichaelNoaddres, "test description3");
		public static readonly Transaction TransactionDepositMichaelUsdSmallWdescription4 = new(new TransactionId(Guid.NewGuid()), new Money(1900, TestCurrencies.Usd), DateTime.UtcNow, TransactionType.Deposit, TestCustomers.MichaelNoaddres, "test description4");
		public static readonly Transaction TransactionDepositMichaelUsdSmallWdescription5 = new(new TransactionId(Guid.NewGuid()), new Money(1900, TestCurrencies.Usd), DateTime.UtcNow, TransactionType.Deposit, TestCustomers.MichaelNoaddres, "test description5");
		public static readonly Transaction TransactionDepositMichaelUsdSmallWdescription6 = new(new TransactionId(Guid.NewGuid()), new Money(1900, TestCurrencies.Usd), DateTime.UtcNow, TransactionType.Deposit, TestCustomers.MichaelNoaddres, "test description6");
		public static readonly Transaction TransactionDepositMichaelUsdSmallWdescription7 = new(new TransactionId(Guid.NewGuid()), new Money(1900, TestCurrencies.Usd), DateTime.UtcNow, TransactionType.Deposit, TestCustomers.MichaelNoaddres, "test description7");
		public static readonly Transaction TransactionDepositMichaelUsdSmallWdescription8 = new(new TransactionId(Guid.NewGuid()), new Money(1900, TestCurrencies.Usd), DateTime.UtcNow, TransactionType.Deposit, TestCustomers.MichaelNoaddres, "test description8");
		public static readonly Transaction TransactionDepositMichaelUsdSmallWdescription9 = new(new TransactionId(Guid.NewGuid()), new Money(1900, TestCurrencies.Usd), DateTime.UtcNow, TransactionType.Deposit, TestCustomers.MichaelNoaddres, "test description9");
		public static readonly Transaction TransactionDepositMichaelUsdSmallWdescription10 = new(new TransactionId(Guid.NewGuid()), new Money(1900, TestCurrencies.Usd), DateTime.UtcNow, TransactionType.Deposit, TestCustomers.MichaelNoaddres, "test description10");

		public static IList<Transaction> GetAllTestTransactions() => [TransactionDepositJohnUsdSmallWdescription, TransactionWithdrawEmilyEurBigNodescription, TransactionTransferDavidPlnBigWdescription, TransactionDepositMichaelUsdSmallWdescription1, TransactionDepositMichaelUsdSmallWdescription2, TransactionDepositMichaelUsdSmallWdescription3, TransactionDepositMichaelUsdSmallWdescription4, TransactionDepositMichaelUsdSmallWdescription5, TransactionDepositMichaelUsdSmallWdescription6, TransactionDepositMichaelUsdSmallWdescription7, TransactionDepositMichaelUsdSmallWdescription8, TransactionDepositMichaelUsdSmallWdescription9, TransactionDepositMichaelUsdSmallWdescription10];

	}
}
