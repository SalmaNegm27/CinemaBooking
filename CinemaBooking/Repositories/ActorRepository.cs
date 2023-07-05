

using CinemaBooking.Contexts;

namespace CinemaBooking.Repositories
{
    public class ActorRepository 
    {
        public DbContext DbContext { get; }
        protected readonly DbSet<Actor> _actors;

        public ActorRepository(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
            _actors= dbContext.Set<Actor>();
        }

        public async Task AddAsync(Actor actor)
        {
            
             await _actors.AddAsync(actor);
             await DbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id )
        {
            var result = await _actors.FindAsync(id);
            if(result == null)
            {
                throw new Exception("There is no actor with this name");
            }
            else
            {
                 _actors.Remove(result);
                await DbContext.SaveChangesAsync();
            }

        }

        public async Task EditAsync(Actor actor , int id )
        {
            var result = await GetByIdAsync(id);
            if (result == null)
            
                throw new Exception("There is no actor with this name");
            
            else

              _actors.Entry(result).State = EntityState.Modified;
        }

        public async Task<IEnumerable<Actor>> GetAllAsync()
        {
          return await _actors.ToListAsync();
        }

        public async Task<List<Actor>> GetByExprissionAsync(Expression<Func<Actor, bool>> expression)
        {
           return await _actors.ToListAsync();

        }

        public async Task<Actor> GetByIdAsync(int id)
        {
            return await _actors.FirstOrDefaultAsync(a => a.ID == id);
        }
    }
}
