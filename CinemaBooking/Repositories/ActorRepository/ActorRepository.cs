using CinemaBooking.Contexts;

namespace CinemaBooking.Repositories.ActorRepository
{
    public class ActorRepository : BaseRepository<Actor>, IActorRepository
    {
        public ActorRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}

