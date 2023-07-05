
namespace CinemaBooking.Repositories
{
    public interface IBaseRepository<T>
    {
        DbContext DbContext { get; }
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T entity);
        Task EditAsync(T entity,int id);
        Task DeleteAsync(int id);
        Task<List<T>> GetByExprissionAsync(Expression<Func<T, bool>> expression);

    }
}
