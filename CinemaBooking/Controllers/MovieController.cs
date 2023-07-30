using CinemaBooking.Data.ViewModels;

namespace CinemaBooking.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieRepository _movieRepository;
        private readonly ICartItemRepository _cartItemRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ApplicationDbContext _dbContext;
        public MovieController(IMovieRepository movieRepository, ICartItemRepository cartItemRepository, IWebHostEnvironment webHostEnvironment, ApplicationDbContext dbContext)
        {
            _movieRepository = movieRepository;
            _cartItemRepository = cartItemRepository;
            _webHostEnvironment = webHostEnvironment;
            _dbContext = dbContext;
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
                return Json(new { isInCart = true });
            }
            await _movieRepository.DeleteAsync(movieId);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Create(MovieViewModel movie)
        {
            if (!ModelState.IsValid)
            {
                
                return View();
            }
            string wwwRootPath = _webHostEnvironment.WebRootPath;
            string fileName = Path.GetFileNameWithoutExtension(movie.ImageFile.FileName);
            string extension = Path.GetExtension(movie.ImageFile.FileName);
            movie.ImagePath = fileName = fileName + DateTime.Now.ToString("yymmssff") + extension;
            string path = Path.Combine(wwwRootPath + "/Images/", fileName);
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                await movie.ImageFile.CopyToAsync(fileStream);
            }


            //await _movieRepository.AddAsync(movie);


            return RedirectToAction("Index");
        }
    }
}
