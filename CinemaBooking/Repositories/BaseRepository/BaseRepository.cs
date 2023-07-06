namespace CinemaBooking.Repositories.BaseRepository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        public DbContext _dbContext { get; }
        protected readonly DbSet<T> _tables;

        public BaseRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _tables = dbContext.Set<T>();
        }
        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _tables.ToListAsync();
        }
        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await _tables.FindAsync(id);
        }

        public virtual Task AddAsync(T entity)
        {

            _tables.Add(entity);
            _dbContext.SaveChangesAsync();
            return Task.CompletedTask;
        }

        public virtual async Task<T> DeleteAsync(int id)
        {
            var result = await GetByIdAsync(id);
            if (result == null)
                throw new Exception("The Entity doesnt exist");
            _tables.Remove(result);
            return result;
        }

        public virtual async Task<T> EditAsync(int id, T entity)
        {
            var result = await GetByIdAsync(id);
            if (result != null)
            {
                var updatedEntity = _tables.Update(entity).Entity;
                await _dbContext.SaveChangesAsync();
                return updatedEntity;
            }
            else
            {
                throw new Exception();
            }
        }


        public virtual async Task<List<T>> GetByExprissionAsync(Expression<Func<T, bool>> expression , params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _tables;

            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return await query.Where(expression).ToListAsync();
        }

        //public async Task<List<T>> IncludePropertiesAsync(params Expression<Func<T, object>>[] includeProperties)
        //{
        //    IQueryable<T> query = _tables;

        //    foreach (var includeProperty in includeProperties)
        //    {
        //        query = query.Include(includeProperty);
        //    }

        //    return await query.ToListAsync();
        //}
    }
}
