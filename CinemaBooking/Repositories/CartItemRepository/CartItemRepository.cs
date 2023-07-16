namespace CinemaBooking.Repositories.CartItemRepository
{
    public class CartItemRepository : BaseRepository<CartItem>, ICartItemRepository
    {
        public CartItemRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public decimal CalculateTotal(int Amount, decimal Price)
        {
            return Amount * Price;
        }

        public async Task<bool> IsMovieInCart(int movieId)
        {
            return await _tables.AnyAsync(c => c.MovieId == movieId);
        }
    }
}
