using DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace Sevices.Interfaces
{
	public interface IRentService
	{
		public void CreateRental(int id);
		public List<RentalViewModel> GetUserRentals();
		public void Delete(int id);

    }
}
