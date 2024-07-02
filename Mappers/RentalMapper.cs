using ViewModels;
using DomainModels;

namespace Mappers
{
    public static class RentalMapper
    {
        public static RentalViewModel ToViewModel(this Rental rental)
        {
            var model = new RentalViewModel
            {
                Id = rental.Id,
                MovieId = rental.MovieId,
                UserId = rental.UserId,
                RentedOn = rental.RentedOn,
                ReturnedOn = rental.ReturnedOn
            };
            return model;
        }

        public static Rental ToDomainModel(this RentalViewModel rental)
        {
            var model = new Rental
            {
                Id = rental.Id,
                MovieId = rental.MovieId,
                UserId = rental.UserId,
                RentedOn = rental.ReturnedOn,
                ReturnedOn = rental.ReturnedOn
            };
            return model;
        }
    }
}
