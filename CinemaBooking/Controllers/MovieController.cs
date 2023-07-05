

namespace CinemaBooking.Controllers
{
    public class MovieController : Controller
    {
        private readonly MovieRepository _movieRepository ;
        public MovieController(MovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<IActionResult> Index()
        {
           await _movieRepository.GetAllAsync();
            return View();
        }
    }
}
