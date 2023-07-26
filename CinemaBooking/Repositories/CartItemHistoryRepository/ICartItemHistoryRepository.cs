namespace CinemaBooking.Repositories.CartItemHistoryRepository
{
    public interface ICartItemHistoryRepository : IBaseRepository<CartItemsHistory>
    {
        Task AddAllAsync(List<CartItemsHistory> entity);


    }
}
