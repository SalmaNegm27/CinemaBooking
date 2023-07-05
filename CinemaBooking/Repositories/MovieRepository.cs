
namespace CinemaBooking.Repositories
{
    public class MovieRepository : IBaseRepository<Movie>
    {
        public DbContext DbContext { get; }
        protected readonly DbSet<Movie> _movies;

        public MovieRepository(DbContext dbContext)
        {
            DbContext = dbContext;
            _movies = dbContext.Set<Movie>();
        }

        public async Task AddAsync(Movie movie)
        {

            await _movies.AddAsync(movie);
            await DbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var result = await _movies.FindAsync(id);
            if (result == null)
            {
                throw new Exception("There is no actor with this name");
            }
            else
            {
                _movies.Remove(result);
                await DbContext.SaveChangesAsync();
            }

        }

        public async Task EditAsync(Movie movie, int id)
        {
            var result = await GetByIdAsync(id);
            if (result == null)

                throw new Exception("There is no actor with this name");

            else

                _movies.Entry(movie).State = EntityState.Modified;
        }

        public async Task<IEnumerable<Movie>> GetAllAsync()
        {
            return await _movies.ToListAsync();
        }

        public async Task<List<Movie>> GetByExprissionAsync(Expression<Func<Movie, bool>> expression)
        {
            return await _movies.ToListAsync();

        }

        public async Task<Movie> GetByIdAsync(int id)
        {
            return await _movies.FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
