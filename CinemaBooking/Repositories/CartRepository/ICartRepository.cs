namespace CinemaBooking.Repositories.CartRepository
{
    public interface ICartRepository :IBaseRepository<CartItem>
    {
        Task<IEnumerable<CartItem>> GetCartItemsAsync();
        Task AddToCartAsync(CartItem cartItem);
        Task RemoveFromCartAsync(int cartItemId);
    }
}
