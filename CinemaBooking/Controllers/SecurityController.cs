using Microsoft.AspNetCore.Mvc;

namespace CinemaBooking.Controllers
{
    public class SecurityController : Controller
    {
        public IActionResult Create()
        {
            return View();
        }
    }
}
