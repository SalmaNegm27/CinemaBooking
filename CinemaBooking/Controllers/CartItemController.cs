using CinemaBooking.Repositories.CartItemRepository;
using CinemaBooking.Repositories.MovieRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CinemaBooking.Controllers
{
    public class CartItemController : Controller
    {
        protected readonly ICartItemRepository _cartItemRepository;
        protected readonly IMovieRepository _movieRepository;

        public CartItemController(ICartItemRepository cartItemRepository, IMovieRepository movieRepository)
        {
            _cartItemRepository = cartItemRepository;
            _movieRepository = movieRepository;
        }

        public async Task<IActionResult> Index()
        {
            var items = await _cartItemRepository.GetAllAsync();
            return View(items);
        }
        public async Task<IActionResult> AddItem()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> AddItem(int movieId)
        {
            var movie = await _movieRepository.GetByIdAsync(movieId);
            var cartitems = new CartItem
            {
                MovieId = movie.Id,
                MovieName = movie.Name,
                Price = movie.Price,
                Amount = 1,


            };
            cartitems.Total = _cartItemRepository.CalculateTotal(cartitems.Amount, cartitems.Price);

            await _cartItemRepository.AddAsync(cartitems);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromCart(int cartItemId)
        {
            await _cartItemRepository.DeleteAsync(cartItemId);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<ActionResult> UpdateQuantity(int itemId, int amount)
        {
            var cartItem = await _cartItemRepository.GetByIdAsync(itemId);
            if (cartItem != null)
            {
                cartItem.Amount = amount;
                cartItem.Total = _cartItemRepository.CalculateTotal(amount, cartItem.Price);
                await _cartItemRepository.EditAsync(itemId, cartItem);
            }

            return RedirectToAction("Index");
        }

        [Authorize]
        [HttpPost]
        public IActionResult Checkout()
        {
            if (User.Identity.IsAuthenticated &&User.IsInRole("User"))
            {

                return View("Sucess");

            }
            else
            {
                return RedirectToAction("Login","Account");

            }
        }
    }
}
