namespace Ats.Api.Endpoints
{
	internal static class Tags
	{
		internal static TagModel Customers = new("Customers", "customers");

		internal record TagModel(string Name, string Url);
	}
}
