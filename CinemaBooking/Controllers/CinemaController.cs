
namespace CinemaBooking.Controllers
{
    public class CinemaController : Controller
    {
        private readonly CinemaRepository _cinemaRepository;
        public CinemaController(CinemaRepository cinemaRepository)
        {
            _cinemaRepository = cinemaRepository;
        }

        public async Task<IActionResult> Index()
        {
            await _cinemaRepository.GetAllAsync();
            return View();
        }
    }
}
