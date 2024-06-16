using Microsoft.AspNetCore.Mvc;
using Sevices.Implementations;

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
            _userService.CreateUser();
            return View();
        }
    }
}
