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
    }
}
