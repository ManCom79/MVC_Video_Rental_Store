using DataAccess;
using DataAccess.Implementations;
using DomainModels;
using Sevices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;
using Mappers;

namespace Sevices.Implementations
{
	public class RentService : IRentService
	{
		public DataTableRepository<Movie> _dataTableRepositoryMovie;
		public DataTableRepository<Rental> _dataTableRepositoryRental;
		public RentService() {
			_dataTableRepositoryMovie = new DataTableRepository<Movie>();
			_dataTableRepositoryRental = new DataTableRepository<Rental>();
		}
		public void CreateRental(int id)
		{
			if(!_dataTableRepositoryRental.GetAll().Any(x => x.MovieId == id && x.UserId == UserLogged.Id))
			{
                var movie = _dataTableRepositoryMovie.GetById(id);
                movie.Quantity = movie.Quantity - 1;

                if (movie.Quantity == 0)
                {
                    movie.IsAvailable = false;
                }

                _dataTableRepositoryMovie.Update(movie);

                var rental = new Rental
                {
                    MovieId = movie.Id,
                    UserId = UserLogged.Id,
                    RentedOn = DateTime.Now,
                };

                _dataTableRepositoryRental.Add(rental);
            };
		}

		public List<RentalViewModel> GetUserRentals()
		{
			var loggedUserId = UserLogged.Id;
			var rentals = _dataTableRepositoryRental.GetAll();
			var userRentals = rentals.Where(x => x.UserId == loggedUserId);

			var models = userRentals.Select(x => x.ToViewModel()).ToList();

            foreach (var model in models)
            {
                model.Title = _dataTableRepositoryMovie.GetById(model.MovieId).Title;
            }

			return models;
        }

		public void Delete(int id)
		{
			var rental = _dataTableRepositoryRental.GetById(id);
			var movie = _dataTableRepositoryMovie.GetById(rental.MovieId);
			movie.Quantity += 1;
			_dataTableRepositoryMovie.Update(movie);

			_dataTableRepositoryRental.DeleteById(id);
		}
    }
}
