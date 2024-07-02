using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace Sevices.Interfaces
{
    public interface IMovieService
    {
        public void CreateMovie(MovieViewModel movieModel);
        public MovieViewModel GetDetails(int id);
        public List<MovieViewModel> GetAll();

	}
}
