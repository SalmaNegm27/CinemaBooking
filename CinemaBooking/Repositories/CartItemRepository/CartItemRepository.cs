namespace CinemaBooking.Repositories.CartItemRepository
{
    public class CartItemRepository : BaseRepository<CartItem>, ICartItemRepository
    {
        public CartItemRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
        public override async Task<IEnumerable<CartItem>> GetAllAsync()
        {
            return await _tables.Include(m => m.Movie).ToListAsync();

        }
        public override Task<CartItem> GetByIdAsync(int id)
        {
            return _tables.Include(m => m.Movie).FirstOrDefaultAsync(c => c.ID == id);
        }
    }
}
