using Ats.Core.Models.Transactions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ats.Core.Models.Customers
{
	[Table("Customer")]
	public class Customer : SoftDeletable
	{
		[Key]
		public CustomerId Id { get; private set; }

		[Required]
		public string FirstName { get; private set; }

		[Required]
		public string LastName { get; private set; }

		[Required]
		public DateTime BirthDate { get; private set; }

		[Required]
		public string? Address { get; private set; }

		public string GlobalId { get; private set; }

		public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();

		public Customer(CustomerId id, string firstName, string lastName, DateTime birthDate, string globalId, string? address = null)
		{
			Id = id;
			FirstName = firstName;
			LastName = lastName;
			BirthDate = birthDate;
			Address = address;
			GlobalId = globalId;
		}

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
		private Customer()// only for entity framework
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
		{

		}

		public void Update(string firstName, string lastName, DateTime birthDate, string? address, string globalId)
		{
			FirstName = firstName;
			LastName = lastName;
			BirthDate = birthDate;
			Address = address;
			GlobalId = globalId;
		}
	}
}
