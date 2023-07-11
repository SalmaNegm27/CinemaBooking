using CinemaBooking.Repositories.CartItemRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CinemaBooking.Controllers
{
    public class CartItemController : Controller
    {
        protected readonly ICartItemRepository _cartRepository;
        public CartItemController(ICartItemRepository cartItemRepository)
        {
            _cartRepository = cartItemRepository;   
        }
        public IActionResult Index()
        {
            var items = _cartRepository.GetAllAsync();
            return View(items);
        }
        public IActionResult Detail(int id)
        {
            var item = _cartRepository.GetByIdAsync(id);
            return View(item);
        }
    }
}
