using DataAccess.Implementations;
using DomainModels;
using Sevices.Interfaces;
using ViewModels;
using Mappers;
using DataAccess.Interfaces;

namespace Sevices.Implementations
{
    public class MovieService : IMovieService
    {
        public IMovieDataTableRepository _movieDataTableRepository;

        public MovieService(IMovieDataTableRepository movieDataTableRepository) {
            _movieDataTableRepository = movieDataTableRepository;
        }

        public List<MovieViewModel> GetAll() { 
            var movies = _movieDataTableRepository.GetAll();
            return movies.Select(x => x.ToViewModel()).ToList();
        }

        public MovieViewModel GetDetails(int id)
        {
            if(_movieDataTableRepository.GetById(id) == null)
            {
                throw new Exception($"Movie with the id {id} does not exist.");
            }

            var movie = _movieDataTableRepository.GetById(id);
            return movie.ToViewModel();
        }
        public void CreateMovie(MovieViewModel movieModel)
        {
            if (_movieDataTableRepository.GetAll().Any(x => x.Title == movieModel.Title))
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

            _movieDataTableRepository.Add(movie);
        }
    }
}
