using DataAccess.Implementations;
using DataAccess.Interfaces;
using DomainModels;
using Sevices.Interfaces;
using ViewModels;
using Mappers;
namespace Sevices.Implementations
{
	public class UserService : IUserService
	{
		public IUserDataTableRepository _userDataTableRepository;
		public UserService(IUserDataTableRepository userDataTableRepository)
		{
			_userDataTableRepository = userDataTableRepository;
		}
		public List<UserViewModel> GetAll()
		{
			var users = _userDataTableRepository.GetAll();
			return users.Select(x => x.ToViewModel()).ToList();
		}

		public void CreateUser(UserViewModel userModel)
		{
			if (_userDataTableRepository.GetAll().Any(x => x.FullName == userModel.FullName))
			{
				throw new Exception("A user with that name already exist!");
			}

			var user = new User
			{
				Email = userModel.Email,
				Password = userModel.Password,
				FullName = userModel.FullName,
				Age = userModel.Age,
				CardNumber = userModel.CardNumber,
				CreatedOn = DateTime.Now,
				IsSubscriptionExpired = false,
				SubscriptionType = userModel.SubscriptionType
			};

			_userDataTableRepository.Add(user);
		}

        public bool LogIn(UserViewModel model)
        {
            if (!_userDataTableRepository.GetAll().Any(x => x.Email == model.Email && x.Password == model.Password))
            {
                return false;
            }

			var user = _userDataTableRepository.GetAll().FirstOrDefault(x => x.Email == model.Email);
            _userDataTableRepository.LogUser(user);
			return true;
        }
    }
}
