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
		public DataTableRepository<User> _dataTableRepository;

		public UserService()
		{
			_dataTableRepository = new DataTableRepository<User>();
		}

		public List<UserViewModel> GetAll()
		{
			var users = _dataTableRepository.GetAll();
			return users.Select(x => x.ToViewModel()).ToList();
		}

		public void CreateUser(UserViewModel userModel)
		{
			if (_dataTableRepository.GetAll().Any(x => x.FullName == userModel.FullName))
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

			_dataTableRepository.Add(user);
		}

        public bool LogIn(UserViewModel model)
        {
            if (!_dataTableRepository.GetAll().Any(x => x.Email == model.Email && x.Password == model.Password))
            {
                return false;
            }

			var user = _dataTableRepository.GetAll().FirstOrDefault(x => x.Email == model.Email);
			_dataTableRepository.LogUser(user);
			return true;
        }
    }
}
