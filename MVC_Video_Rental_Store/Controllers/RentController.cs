using Microsoft.AspNetCore.Mvc;
using Sevices.Implementations;

namespace MVC_Video_Rental_Store.Controllers
{
    public class RentController : Controller
    {
        public RentService _rentService { get; set; }
        public RentController(RentService rentService)
        {
            _rentService = rentService;
        }
        public IActionResult Index()
        {
            var userRentals = _rentService.GetUserRentals();
            return View(userRentals);
        }
        public IActionResult CreateRental(int id)
        {
            _rentService.CreateRental(id);
            return RedirectToAction("Index", "Movie");
        }

        public IActionResult DeleteRental(int id)
        {
            _rentService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
