using Ats.Core.CommandsAndQueries.Customers.Create;
using Ats.Core.Models.Customers;
using AutoMapper;

namespace Ats.Core.Profiles
{
	internal class CustomerProfiles : Profile
	{
		public CustomerProfiles()
		{
			CreateMap<Customer, CreateCustomerCommand>();
		}
	}
}
