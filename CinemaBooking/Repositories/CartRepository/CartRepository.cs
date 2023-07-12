namespace CinemaBooking.Repositories.CartRepository
{
    public class CartRepository : BaseRepository<CartItem>, ICartRepository
    {
        public CartRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
        public async Task<IEnumerable<CartItem>> GetCartItemsAsync()
        {
            return await GetAllAsync();
        }

        public async Task AddToCartAsync(CartItem cartItem)
        {
            await AddAsync(cartItem);
        }

        public async Task RemoveFromCartAsync(int cartItemId)
        {
            await DeleteAsync(cartItemId);
        }
    }
}
