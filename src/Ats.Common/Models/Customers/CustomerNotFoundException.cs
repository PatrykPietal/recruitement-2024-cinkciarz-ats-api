namespace Ats.Core.Models.Customers
{
	//prefere reult pattern but this work as well in fase api building
	public sealed class CustomerNotFoundException(CustomerId id) : Exception($"The customer with the ID = {id.Value} not found")
	{
	}
}
