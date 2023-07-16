

using CinemaBooking.Repositories.CartItemRepository;
using CinemaBooking.Repositories.MovieRepository;

namespace CinemaBooking.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieRepository _movieRepository;
        private readonly ICartItemRepository _cartItemRepository;


        public MovieController(IMovieRepository movieRepository,ICartItemRepository cartItemRepository)
        {
            _movieRepository = movieRepository;
            _cartItemRepository = cartItemRepository;

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

        public async Task<IActionResult> Details(int id)
        {
            var movie = await _movieRepository.GetByIdAsync(id);
            return View(movie);
        }
        [HttpPost]
        public async Task<ActionResult> Delete(int movieId)
        {
            var isMovieInCart = await _cartItemRepository.IsMovieInCart(movieId);
            var movies = await _movieRepository.GetByIdAsync(movieId);
            #region MyRegion
            //foreach(var cart in carts)
            // {
            //     if(cart.MovieId == movieId)
            //         return View("DeleteError");
            // }

            // if(movies== null)
            //     return RedirectToAction("NotFound"); 
            #endregion
            if (isMovieInCart)
            {
                return View("DeleteError");
            }
            await _movieRepository.DeleteAsync(movieId);
            return RedirectToAction("Index");
        }
    }
}
