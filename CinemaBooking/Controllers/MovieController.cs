

using CinemaBooking.Repositories.MovieRepository;

namespace CinemaBooking.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieRepository _movieRepository ;
        public MovieController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<IActionResult> Index()
        {
          var movies = await _movieRepository.IncludePropertiesAsync();
            return View(movies);
        }
    }
}
