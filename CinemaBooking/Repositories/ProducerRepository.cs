
namespace CinemaBooking.Repositories
{
    public class ProducerRepository
    {
        public DbContext DbContext { get; }
        protected readonly DbSet<Producer> _producer;

        public ProducerRepository(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
            _producer = dbContext.Set<Producer>();
        }

        public async Task AddAsync(Producer  producer )
        {

            await _producer.AddAsync(producer);
            await DbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var result = await _producer.FindAsync(id);
            if (result == null)
            {
                throw new Exception("There is no actor with this name");
            }
            else
            {
                _producer.Remove(result);
                await DbContext.SaveChangesAsync();
            }

        }

        public async Task EditAsync(Producer producer, int id)
        {
            var result = await GetByIdAsync(id);
            if (result == null)

                throw new Exception("There is no actor with this name");

            else

                _producer.Entry(producer).State = EntityState.Modified;
        }

        public async Task<IEnumerable<Producer>> GetAllAsync()
        {
            return await _producer.ToListAsync();
        }

        public async Task<List<Producer>> GetByExprissionAsync(Expression<Func<Producer, bool>> expression)
        {
            return await _producer.ToListAsync();

        }

        public async Task<Producer> GetByIdAsync(int id)
        {
            return await _producer.FirstOrDefaultAsync(c => c.ID == id);
        }
    }
}
