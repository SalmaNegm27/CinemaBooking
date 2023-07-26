using CinemaBooking.Repositories.CartItemHistoryRepository;
using Microsoft.AspNetCore.Mvc;

namespace CinemaBooking.Controllers
{
    public class CartItemHistoryController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ICartItemHistoryRepository _cartItemHistory;
        private readonly ICartRepository _cartRepository;
        public CartItemHistoryController(UserManager<ApplicationUser> userManager, ICartItemHistoryRepository cartItemHistory,ICartRepository cartRepository)
        {
            _userManager = userManager;
            _cartItemHistory = cartItemHistory;
            _cartRepository = cartRepository;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {

                return RedirectToAction("Login", "Account");
            }

            var cart = await _cartRepository.GetByUserForHisoryIdAsync(user.Id);
            if (cart == null || cart.CartItemsHistories == null || cart.CartItemsHistories.Count == 0)
            {

                return View("CartIsEmpty");
            }

            return View(cart.CartItemsHistories);
        }
    }
}
