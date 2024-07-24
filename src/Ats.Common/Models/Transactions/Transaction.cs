using Ats.Core.Models.Customers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ats.Core.Models.Transactions
{
	[Table("Transaction")]
	public class Transaction : SoftDeletable
	{
		[Key]
		public TransactionId Id { get; private set; }

		[Required]
		public Money Amount { get; private set; }

		[Required]
		public DateTime Date { get; private set; }

		[Required]
		public TransactionType Type { get; private set; }
		public TransactionStatus Status { get; private set; }

		[Required]
		public string? Description { get; private set; }

		[Required]
		public CustomerId CustomerId { get; private set; }

		[ForeignKey("CustomerId")]
		public Customer? CustomerNavigation { get; private set; }


		public Transaction(TransactionId id, Money amount, DateTime date, TransactionType type, CustomerId customerId, string? description = null)
		{
			Id = id;
			Amount = amount;
			Date = date;
			Type = type;
			Status = TransactionStatus.Pending;
			Description = description;
			CustomerId = customerId;
		}

		public Transaction(TransactionId id, Money amount, DateTime date, TransactionType type, Customer customerNavigation, string? description = null) : this(id, amount, date, type, customerNavigation.Id, description)
		{
			CustomerNavigation = customerNavigation;
		}

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
		private Transaction()// only for entity framework
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
		{

		}

		public void Update(Money amount, DateTime date, TransactionType type, string? description, CustomerId customerId, Customer? customerNavigation)
		{
			Amount = amount;
			Date = date;
			Type = type;
			Status = TransactionStatus.Pending;
			Description = description;
			CustomerId = customerId;
			CustomerNavigation = customerNavigation;
		}

		public void UpdateStatus(TransactionStatus status)
		{
			Status = status;
		}

	}
}
