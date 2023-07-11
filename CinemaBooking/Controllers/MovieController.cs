

using CinemaBooking.Repositories.MovieRepository;

namespace CinemaBooking.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieRepository _movieRepository ;
        private readonly ApplicationDbContext _dbContext;

        public MovieController(IMovieRepository movieRepository, ApplicationDbContext dbContext)
        {
            _movieRepository = movieRepository;
            _dbContext = dbContext;
        }

        //public async Task<IActionResult> Index()
        //{
        //  var movies = await _movieRepository.GetAllAsync();
        //    return View(movies);
        //}

        public async Task<IActionResult> Index(string stringSearch)
        {
            ViewData["CurrentFilter"] = stringSearch;
            var movies = await _movieRepository.GetAllAsync();
            if (!string.IsNullOrEmpty(stringSearch))
            {
                movies = movies.Where(m => m.Name.IndexOf(stringSearch, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            }
            return View(movies);

        }
    }
}
