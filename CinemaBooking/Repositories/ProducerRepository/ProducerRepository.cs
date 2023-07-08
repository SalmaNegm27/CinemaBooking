namespace CinemaBooking.Repositories.ProducerRepository
{
    public class ProducerRepository : BaseRepository<Producer>, IProducerRepository
    {
        public ProducerRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
