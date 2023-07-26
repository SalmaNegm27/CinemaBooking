namespace CinemaBooking.Repositories.CartRepository_
{
    public interface ICartRepository :IBaseRepository<Cart>
    {
        Task<Cart> GetByUserIdAsync(string userId);
        Task<Cart> GetByUserForHisoryIdAsync(string userId);

        public int CountCart(int CartId);
        
    }
}
