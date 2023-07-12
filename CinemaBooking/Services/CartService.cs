using CinemaBooking.Repositories.CartRepository;

namespace CinemaBooking.Services
{


    public class CartService
    {
        private readonly ICartRepository _cartRepository;

        public CartService(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task<Cart> GetCartAsync()
        {
            var cartItems = await _cartRepository.GetCartItemsAsync();

            var cart = new Cart
            {
                Items = cartItems
            };

            return cart;
        }

        public async Task AddToCartAsync(CartItem cartItem)
        {
            await _cartRepository.AddToCartAsync(cartItem);
        }

        public async Task RemoveFromCartAsync(int cartItemId)
        {
            await _cartRepository.RemoveFromCartAsync(cartItemId);
        }

      
    }
}
