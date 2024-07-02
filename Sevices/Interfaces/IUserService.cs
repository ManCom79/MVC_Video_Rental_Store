using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace Sevices.Interfaces
{
	public interface IUserService
	{
		public List<UserViewModel> GetAll();
		public bool LogIn(UserViewModel model);
		public void CreateUser(UserViewModel userModel);
	}
}
