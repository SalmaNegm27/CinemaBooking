using Microsoft.EntityFrameworkCore;

namespace CinemaBooking.Repositories.CartItemHistory
{
    public class CartItemHistory : BaseRepository<CartItemsHistory>, ICartItemHistory
    {
        public CartItemHistory(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
        public  async Task AddAllAsync(List<CartItemsHistory> entity)
        {
             await _tables.AddRangeAsync(entity);
        }
    }
}
