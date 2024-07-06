using Microsoft.AspNetCore.Mvc;
using Sevices.Implementations;
using Sevices.Interfaces;

namespace MVC_Video_Rental_Store.Controllers
{
    public class RentController : Controller
    {
        public IRentService _rentService;
        public RentController(IRentService rentService)
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
