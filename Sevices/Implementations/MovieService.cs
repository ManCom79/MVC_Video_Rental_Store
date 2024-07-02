using DataAccess.Implementations;
using DomainModels;
using Sevices.Interfaces;
using ViewModels;
using Mappers;

namespace Sevices.Implementations
{
    public class MovieService : IMovieService
    {
        public DataTableRepository<Movie> _dataTableRepository;

        public MovieService() {
            _dataTableRepository = new DataTableRepository<Movie>();
        }

        public List<MovieViewModel> GetAll() { 
            var movies = _dataTableRepository.GetAll();
            return movies.Select(x => x.ToViewModel()).ToList();
        }

        public MovieViewModel GetDetails(int id)
        {
            if(_dataTableRepository.GetById(id) == null)
            {
                throw new Exception($"Movie with the id {id} does not exist.");
            }

            var movie = _dataTableRepository.GetById(id);
            return movie.ToViewModel();
        }
        public void CreateMovie(MovieViewModel movieModel)
        {
            if (_dataTableRepository.GetAll().Any(x => x.Title == movieModel.Title))
            {
                throw new Exception("A movie with that name already exist!");
            }

            var movie = new Movie
            {
                Title = movieModel.Title,
                Genre = movieModel.Genre,
                Language = movieModel.Language,
                IsAvailable = movieModel.IsAvailable,
                ReleaseDate = movieModel.ReleaseDate,
                Length = movieModel.Length,
                AgeRestriction = movieModel.AgeRestriction,
                Quantity = movieModel.Quantity,
            };

            _dataTableRepository.Add(movie);
        }
    }
}
