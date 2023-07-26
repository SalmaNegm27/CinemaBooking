using CinemaBooking.Models;

namespace CinemaBooking.Repositories.CartRepository_
{
    public class CartRepository : BaseRepository<Cart>, ICartRepository
    {
        private readonly ApplicationDbContext _dbContext;


        public CartRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Cart> GetByUserIdAsync(string userId) => await _dbContext.Carts
                             .Include(c => c.CartItems).FirstOrDefaultAsync(c => c.UserId == userId);

        public async Task<Cart> GetByUserForHisoryIdAsync(string userId) => await _dbContext.Carts
                             .Include(c => c.CartItemsHistories).FirstOrDefaultAsync(c => c.UserId == userId);

        public int CountCart(int CartId)
        {
            return _dbContext.CartItems.Where(c => c.CartId == CartId).Count();
        }
    }
}