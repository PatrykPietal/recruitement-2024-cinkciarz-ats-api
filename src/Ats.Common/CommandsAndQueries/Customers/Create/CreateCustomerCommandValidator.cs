using Ats.Core.Interfaces.Data.Repositories;
using FluentValidation;

namespace Ats.Core.CommandsAndQueries.Customers.Create
{

	public sealed class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
	{
		public CreateCustomerCommandValidator(ICustomerRepository customerRepository)
		{

			RuleFor(customer => customer.FirstName)
				.NotEmpty().WithMessage("First name is required.")
				.Length(2, 100).WithMessage("First name must be between 2 and 100 characters.");

			RuleFor(customer => customer.LastName)
				.NotEmpty().WithMessage("Last name is required.")
				.Length(2, 100).WithMessage("Last name must be between 2 and 100 characters.");

			RuleFor(customer => customer.Address)
				.Must(address => address == null || address.Trim().Length > 0)
				.WithMessage("Address must not be empty if provided.")
				.When(customer => customer.Address != null)
				.Length(2, 500).WithMessage("Address must be between 2 and 500 characters.")
				.When(customer => customer.Address != null);

			RuleFor(x => x.BirthDate).LessThan(DateTime.Now).WithMessage("Birth date must be in the past.");

			RuleFor(c => c.GlobalId).MustAsync(async (globalId, _) =>
			{
				return !await customerRepository.ExistsGlobalId(globalId);
			}).WithMessage("Global id must be unique");
		}

	}
}