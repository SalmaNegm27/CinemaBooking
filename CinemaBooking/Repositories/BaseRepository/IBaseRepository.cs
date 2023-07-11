namespace CinemaBooking.Repositories.BaseRepository
{
    public interface IBaseRepository<T>
    {
        DbContext _dbContext { get; }
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T entity);
        Task EditAsync(int id,T entity);
        Task DeleteAsync(int id);
        Task<List<T>> GetByExprissionAsync(Expression<Func<T, bool>> expression , params Expression<Func<T, object>>[] includeProperties);
        //Task<List<T>> IncludePropertiesAsync(params Expression<Func<T, object>>[] includeProperties);
    }

}

