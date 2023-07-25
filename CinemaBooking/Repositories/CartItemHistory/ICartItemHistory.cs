namespace CinemaBooking.Repositories.CartItemHistory
{
    public interface ICartItemHistory :IBaseRepository<CartItemsHistory>
    {
     Task AddAllAsync(List<CartItemsHistory> entity);
    }
}
