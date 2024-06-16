using DataAccess.Implementations;
using DataAccess.Interfaces;
using DomainModels;
using Sevices.Interfaces;

namespace Sevices.Implementations
{
	public class UserService : IUserService
	{
		public DataTableRepository<User> _dataTableRepository;

		public UserService()
		{
			_dataTableRepository = new DataTableRepository<User>();
		}

		public void CreateUser()
		{
			Console.WriteLine("Function called!");
			var user = new User() { Id = 1, FullName = "Test User", Age = 35, CardNumber = "1234", CreatedOn = DateTime.Now, SubscriptionType = DomainModels.Enums.SubscriptionTypeEnum.Quarterly, IsSubscriptionExpired = false };
			List<User> users = new List<User>();
			users.Add(user);

			_dataTableRepository.WriteRecords(users);
		}
	}
}
