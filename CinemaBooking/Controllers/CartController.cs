using CinemaBooking.Repositories.CartRepository;
using CinemaBooking.Repositories.MovieRepository;
using CinemaBooking.Services;

public class CartController : Controller
{
    private readonly CartService _cartService;
    private readonly IMovieRepository _movieRepository;
    public CartController(CartService cartService, IMovieRepository movieRepository)
    {
        _cartService = cartService;
        _movieRepository = movieRepository;
    }

    public async Task<IActionResult> Index()
    {
        var cart = await _cartService.GetCartAsync();
        return View(cart);
    }

    [HttpPost]
    public async Task<IActionResult> AddToCart(int movieId)
    {
        // Retrieve the selected movie by its ID and create a new cart item
        var movie = await _movieRepository.GetByIdAsync(movieId);
        var cartItem = new CartItem
        {
           
            MovieId = movie.Id,
            Price = movie.Price,
            Amount = 1,
            Total = movie.Price,
           
        };

        await _cartService.AddToCartAsync(cartItem);

        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> RemoveFromCart(int cartItemId)
    {
        await _cartService.RemoveFromCartAsync(cartItemId);
        return RedirectToAction("Index");
    }

    // Add any additional actions for cart management
}



