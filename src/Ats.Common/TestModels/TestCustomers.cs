using Ats.Core.Models.Customers;

namespace Ats.Core.TestModels
{
	public static class TestCustomers
	{
		public static readonly Customer JohnNoaddress = new(new CustomerId(Guid.Parse("cccccccc-1111-4562-b3fc-2c963f66afa6")), "John", "Pig", new DateTime(1990, 1, 1), "HPD23412356");
		public static readonly Customer JaneNoaddress = new(new CustomerId(Guid.Parse("cccccccc-2222-4562-b3fc-2c963f66afa6")), "Jane", "Doe", new DateTime(1985, 5, 10), "ABC12345678");
		public static readonly Customer MichaelNoaddres = new(new CustomerId(Guid.Parse("cccccccc-3333-4562-b3fc-2c963f66afa6")), "Michael", "Smith", new DateTime(1978, 9, 15), "XYZ98765432");
		public static readonly Customer EmilyNoaddress = new(new CustomerId(Guid.Parse("cccccccc-4444-4562-b3fc-2c963f66afa6")), "Emily", "Johnson", new DateTime(1995, 3, 25), "DEF56789123");
		public static readonly Customer DavidWithaddress = new(new CustomerId(Guid.Parse("cccccccc-5555-4562-b3fc-2c963f66afa6")), "David", "Brown", new DateTime(1982, 7, 8), "MNO45678901", "Apt. 785 42577 Dallas Flats, Millsview, NY 87282-1737");

		public static IList<Customer> GetAllTestCustomers() => [JohnNoaddress, JaneNoaddress, MichaelNoaddres, EmilyNoaddress, DavidWithaddress];
	};

}
