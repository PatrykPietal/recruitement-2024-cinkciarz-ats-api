using FluentValidation;

namespace Ats.Core.CommandsAndQueries.Customers.Get
{
	public sealed class GetCustomersQueryValidator : AbstractValidator<GetCustomersQuery>
	{
		public GetCustomersQueryValidator()
		{
			RuleFor(x => x.Page)
				.GreaterThanOrEqualTo(1)
				.WithMessage("Page must be greater than or equal to 1.");

			RuleFor(x => x.PageSize)
				.InclusiveBetween(1, 1000)
				.WithMessage("Page size must be between 1 and 1000.");

			RuleFor(x => x.SearchName)
				.Must(x => x == null || !string.IsNullOrEmpty(x))
				.WithMessage("SearchName must not be empty if provided.");
			RuleFor(x => x.SearchLastName)
				.Must(x => x == null || !string.IsNullOrEmpty(x))
				.WithMessage("SearchLastName must not be empty if provided.");
			RuleFor(x => x.SearchAddress)
				.Must(x => x == null || !string.IsNullOrEmpty(x))
				.WithMessage("SearchAddress must not be empty if provided.");
			RuleFor(x => x.SortColumn)
				.Must(x => x == null || !string.IsNullOrEmpty(x))
				.WithMessage("SortColumn must not be empty if provided."); // we could limit this only to current columns
			RuleFor(x => x.SortOrder)
				.Must(x => x == null || string.Equals(x, "asc", StringComparison.OrdinalIgnoreCase) || string.Equals(x, "desc", StringComparison.OrdinalIgnoreCase))
				.WithMessage("Sort order must be 'asc' or 'desc' (case insensitive) when provided.");
		}
	}
}
