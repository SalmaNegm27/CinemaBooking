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
        public async Task<IActionResult> Index(string stringSearch)
        {
            IEnumerable<Movie>? movies = await _movieRepository.GetAllAsync();
            ViewData["CurrentFilter"] = stringSearch;
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
                //return PartialView("_DeleteErrorPertialView");
                return Json(new {isInCart=true});
            }
            await _movieRepository.DeleteAsync(movieId);
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Create(Movie movie)
        {
            return View();
        }
    }
}
