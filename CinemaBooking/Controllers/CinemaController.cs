
using CinemaBooking.Repositories.CinemaRepository;

namespace CinemaBooking.Controllers
{
    public class CinemaController : Controller
    {
        private readonly ICinemaRepository _cinemaRepository;
        public CinemaController(ICinemaRepository cinemaRepository)
        {
            _cinemaRepository = cinemaRepository;
        }

        public async Task<IActionResult> Index()
        {
            var cinemas= await _cinemaRepository.GetAllAsync();
            return View(cinemas);
        }
    }
}
