namespace CinemaBooking.Repositories.CartRepository_
{
    public interface ICartRepository :IBaseRepository<Cart>
    {
        Task<Cart> GetByUserIdAsync(string userId);
    }
}
