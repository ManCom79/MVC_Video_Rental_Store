using DataAccess.Interfaces;
using DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Implementations
{
    public class MovieDataTableRepository : DataTableRepository<Movie>, IMovieDataTableRepository
    {
        public MovieDataTableRepository(VideoRentalDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
