using Microsoft.AspNetCore.Mvc;
using Sevices.Implementations;
using Sevices.Interfaces;
using ViewModels;

namespace MVC_Video_Rental_Store.Controllers
{
    public class MovieController : Controller
    {
        public MovieService _movieService;
        public MovieController() { 
            _movieService = new MovieService();
        }
        public IActionResult Index()
        {
            var movies = _movieService.GetAll();
            return View(movies);
        }

        public IActionResult CreateMovie()
        {
            var movie = new MovieViewModel();
            return View(movie);
        }

        [HttpPost]
        public IActionResult CreateMovie([FromForm] MovieViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            _movieService.CreateMovie(model);

            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var result = _movieService.GetDetails(id);
            return View(result);
        }
    }
}
