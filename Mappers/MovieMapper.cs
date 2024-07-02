using ViewModels;
using DomainModels;
using DomainModels.Enums;

namespace Mappers
{
    public static class MovieMapper
    {
        public static MovieViewModel ToViewModel(this Movie movie)
        {
            var model = new MovieViewModel
            {
                Id = movie.Id,
                Title = movie.Title,
                Genre = movie.Genre,
                Language = movie.Language,
                IsAvailable = movie.IsAvailable,
                ReleaseDate = movie.ReleaseDate.Date,
                Length = movie.Length,
                AgeRestriction = movie.AgeRestriction,
                Quantity = movie.Quantity,
            };
            return model;
        }

        public static Movie ToDomainModel(this MovieViewModel movie)
        {
            var model = new Movie
            {
                Id = movie.Id,
                Title = movie.Title,
                Genre = movie.Genre,
                Language = movie.Language,
                IsAvailable = movie.IsAvailable,
                ReleaseDate = movie.ReleaseDate,
                Length = movie.Length,
                AgeRestriction = movie.AgeRestriction,
                Quantity = movie.Quantity,
            };
            return model;
        }
    }
}
