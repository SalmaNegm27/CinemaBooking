

namespace CinemaBooking.Repositories
{
    public class CinemaRepository : IBaseRepository<Cinema>
    {
        public DbContext DbContext { get; }
        protected readonly DbSet<Cinema> _cinemas;

        public CinemaRepository(DbContext dbContext)
        {
            DbContext = dbContext;
            _cinemas = dbContext.Set<Cinema>();
        }

        public async Task AddAsync(Cinema cinema)
        {

            await _cinemas.AddAsync(cinema);
            await DbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var result = await _cinemas.FindAsync(id);
            if (result == null)
            {
                throw new Exception("There is no actor with this name");
            }
            else
            {
                _cinemas.Remove(result);
                await DbContext.SaveChangesAsync();
            }

        }

        public async Task EditAsync(Cinema cinema, int id)
        {
            var result = await GetByIdAsync(id);
            if (result == null)

                throw new Exception("There is no actor with this name");

            else

                _cinemas.Entry(result).State = EntityState.Modified;
        }

        public async Task<IEnumerable<Cinema>> GetAllAsync()
        {
            return await _cinemas.ToListAsync();
        }

        public async Task<List<Cinema>> GetByExprissionAsync(Expression<Func<Cinema, bool>> expression)
        {
            return await _cinemas.ToListAsync();

        }

        public async Task<Cinema> GetByIdAsync(int id)
        {
            return await _cinemas.FirstOrDefaultAsync(c => c.ID == id);
        }
    }
}
