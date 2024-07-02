using Microsoft.AspNetCore.Mvc;
using Sevices.Implementations;
using ViewModels;

namespace MVC_Video_Rental_Store.Controllers
{
    public class UserController : Controller
    {
        public UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }
        public IActionResult Index()
        {
            var users = _userService.GetAll();
            return View(users);
        }

        public IActionResult Create()
        {
            var user = new UserViewModel();
            return View(user);
        }

        [HttpPost]
        public IActionResult Create([FromForm] UserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            _userService.CreateUser(model);

            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public IActionResult LogIn([FromForm] UserViewModel model)
        {
            if(!_userService.LogIn(model))
            {
                return RedirectToAction("Index", "Home");
            } else
            {
                return RedirectToAction("Index", "Movie");
            }

        }
    }
}
