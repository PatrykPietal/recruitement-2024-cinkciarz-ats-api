namespace Ats.Core.CommandsAndQueries.Customers.Reponse
{
	public record CustomerResponse(Guid Id, string FirstName, string LastName, DateTime BirthDate, string? Address, string GlobalId);
}