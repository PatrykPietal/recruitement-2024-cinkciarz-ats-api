using Ats.Core.TestModels;
using Microsoft.EntityFrameworkCore;

namespace Ats.Infrastructure.Data
{
	public static class PrepDb
	{
		public static void SeedData(AppDbContext context, bool isProd)
		{
			if (isProd)
			{
				Console.WriteLine($"--> Attempting to apply Migrations...");
				try
				{
					context.Database.Migrate();
				}
				catch (Exception ex)
				{
					Console.WriteLine($"--> Could not run Migrations: {ex.Message}");
				}
			}
			else
			{
				if (!context.Customers.Any())
				{
					//al least for inital phase rapid dev testing
					// can be also used for other teams to test their services (at init phase) of project
					Console.WriteLine("--> Seeding Data...");

					context.Customers.AddRange(TestCustomers.GetAllTestCustomers());
					context.Currency.AddRange(TestCurrencies.GetAllTestCurrencies());
					context.Transactions.AddRange(TestTransactions.GetAllTestTransactions());

					context.SaveChanges();
				}
				else
				{
					Console.WriteLine("--> We already have data"); // yeah this wont happen when using inmemory db, but phase of tests will go into sql this will be used
				}
			}
		}

	}
}

