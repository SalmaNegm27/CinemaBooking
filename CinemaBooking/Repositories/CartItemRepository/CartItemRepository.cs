namespace CinemaBooking.Repositories.CartItemRepository
{
    public class CartItemRepository : BaseRepository<CartItem>, ICartItemRepository
    {
        private readonly ApplicationDbContext _context;
        public CartItemRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }

        public decimal CalculateTotal(int Amount, decimal Price)
        {
            return Amount * Price;
        }

        public async Task<bool> IsMovieInCart(int movieId)
        {
            return await _tables.AnyAsync(c => c.MovieId == movieId);
        }

        public async Task DeleteAllAsync(IEnumerable<CartItem> cartItems)
        {
            _context.CartItems.RemoveRange(cartItems);
            await _context.SaveChangesAsync();
        }
    }
}
