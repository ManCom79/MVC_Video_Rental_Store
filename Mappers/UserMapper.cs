using DomainModels;
using ViewModels;

namespace Mappers
{
	public static class UserMapper
	{
		public static UserViewModel ToViewModel(this User user)
		{
			var model = new UserViewModel
			{
                Id = user.Id,
                Email = user.Email,
				Password = user.Password,
				FullName = user.FullName,
				Age = user.Age,
				CardNumber = user.CardNumber,
				CreatedOn = user.CreatedOn,
				IsSubscriptionExpired = user.IsSubscriptionExpired,
				SubscriptionType = user.SubscriptionType
			};

			return model;
		}

		public static User ToDomainModel(this UserViewModel user)
		{
			var model = new User
			{
				Id = user.Id,
				Email = user.Email,
				Password = user.Password,
				FullName = user.FullName,
				Age = user.Age,
				CardNumber = user.CardNumber,
				CreatedOn = user.CreatedOn,
				IsSubscriptionExpired = user.IsSubscriptionExpired,
				SubscriptionType = user.SubscriptionType
			};

			return model;
		}
	}
}
