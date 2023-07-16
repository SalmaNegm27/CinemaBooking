using CinemaBooking.Repositories.CartItemRepository;
using CinemaBooking.Repositories.CartRepository_;
using CinemaBooking.Repositories.MovieRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CinemaBooking.Controllers
{
    public class CartItemController : Controller
    {
        protected readonly ICartItemRepository _cartItemRepository;
        protected readonly IMovieRepository _movieRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ICartRepository _cartRepository;
        public CartItemController(ICartItemRepository cartItemRepository, IMovieRepository movieRepository,UserManager<ApplicationUser> userManager, ICartRepository cartRepository)
        {
            _cartItemRepository = cartItemRepository;
            _movieRepository = movieRepository;
            _userManager = userManager;
            _cartRepository = cartRepository;   
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                
                return RedirectToAction("Login", "Account");
            }

            var cart = await _cartRepository.GetByUserIdAsync(user.Id);
            if (cart == null || cart.CartItems == null || cart.CartItems.Count == 0)
            {
                
                return RedirectToAction("CartIsEmpty");
            }

            return View(cart.CartItems);
        }
        public async Task<IActionResult> AddItem()
        {
            return View();
        }
        #region AddItemv1
        //[HttpPost]
        //public async Task<ActionResult> AddItem(int movieId)
        //{
        //    var movie = await _movieRepository.GetByIdAsync(movieId);
        //    var cartitems = new CartItem
        //    {
        //        MovieId = movie.Id,
        //        MovieName = movie.Name,
        //        Price = movie.Price,
        //        Amount = 1,


        //    };
        //    cartitems.Total = _cartItemRepository.CalculateTotal(cartitems.Amount, cartitems.Price);

        //    await _cartItemRepository.AddAsync(cartitems);
        //    return RedirectToAction("Index");
        //} 
        #endregion
        private async Task<Cart> GetOrCreateCart(string userId)
        {
            var cart = await _cartRepository.GetByUserIdAsync(userId);
            if (cart == null)
            {
                cart = new Cart
                {
                    UserId = userId,
                    CartDate = DateTime.Now,
                    CartItems = new List<CartItem>()
                };
                await _cartRepository.AddAsync(cart);
            }
            return cart;
        }
        [HttpPost]
        public async Task<ActionResult> AddItem(int movieId)
        {
            var movie = await _movieRepository.GetByIdAsync(movieId);
            var user = await _userManager.GetUserAsync(User);
           
            if ( user == null || !await _userManager.IsInRoleAsync(user, "User"))
            {
               
                return RedirectToAction("Login", "Account");
            }
            else
            {
            var cart = await GetOrCreateCart(user.Id);
            var cartItem = new CartItem
            {
                MovieId = movie.Id,
                MovieName = movie.Name,
                Price = movie.Price,
                Amount = 1,
                Total = _cartItemRepository.CalculateTotal(1, movie.Price),
                CartId = cart.ID
            };

            await _cartItemRepository.AddAsync(cartItem);
            return RedirectToAction("Index");

            }
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

        #region Checkoutv1
        //[Authorize]
        //[HttpPost]
        //public IActionResult Checkout()
        //{
        //    if (User.Identity.IsAuthenticated &&User.IsInRole("User"))
        //    {

        //        return View("Sucess");

        //    }
        //    else
        //    {
        //        return RedirectToAction("Login","Account");

        //    }
        //} 
        #endregion
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Checkout()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                
                return RedirectToAction("Login", "Account");
            }

            var cart = await _cartRepository.GetByUserIdAsync(user.Id);
            if (cart == null || cart.CartItems.Count == 0)
            {
               
                return RedirectToAction("CartIsEmpty");
            }

            cart.CartItems.Clear();
           // await _cartRepository.EditAsync(cart.ID, cart);

            return View("Sucess");
        }


    }
}
