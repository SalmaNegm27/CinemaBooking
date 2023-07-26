using Microsoft.EntityFrameworkCore;

namespace CinemaBooking.Repositories.CartItemHistoryRepository
{
    public class CartItemHistoryRepository : BaseRepository<CartItemsHistory>, ICartItemHistoryRepository
    {
        public CartItemHistoryRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
        public async Task AddAllAsync(List<CartItemsHistory> entity)
        {
            await _tables.AddRangeAsync(entity);
        }
    }
}
