namespace CinemaBooking.Repositories.CartItemRepository
{
    public interface ICartItemRepository : IBaseRepository<CartItem>
    {
        decimal CalculateTotal(int Amount, decimal Price);
        Task<bool> IsMovieInCart(int movieId);
        Task DeleteAllAsync(IEnumerable<CartItem> cartItems);


    }
}
