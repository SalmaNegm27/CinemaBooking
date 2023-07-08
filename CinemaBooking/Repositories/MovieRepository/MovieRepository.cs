namespace CinemaBooking.Repositories.MovieRepository
{
    public class MovieRepository : BaseRepository<Movie>, IMovieRepository
    {
        public MovieRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
        public async override Task<IEnumerable<Movie>> GetAllAsync()
        {
            return await  _tables.Include(c => c.Cinema).ToListAsync();
        }
    }
}
