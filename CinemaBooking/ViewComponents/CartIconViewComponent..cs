using System.Security.Claims;

namespace CinemaBooking.ViewComponents
{
    public class CartIconViewComponent :ViewComponent
    {
        private readonly ICartRepository _cartRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        public CartIconViewComponent(ICartRepository cartRepository, UserManager<ApplicationUser> userManager)
        {
            _cartRepository = cartRepository;
            _userManager = userManager;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {
            var itemCount = 0;

            if (User.Identity.IsAuthenticated)
            {
                var user = await _userManager.GetUserAsync((ClaimsPrincipal)User);
                if (user != null)
                {
                    var cart = await _cartRepository.GetByUserIdAsync(user.Id);
                    if (cart != null && cart.CartItems != null)
                    {
                        itemCount = cart.CartItems.Count;
                    }
                }
            }

            ViewData["ItemCount"] = itemCount; // Store the itemCount in ViewData

            return View();
        }
    }
}
