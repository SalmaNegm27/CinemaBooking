namespace CinemaBooking.Repositories.MovieRepository
{
    public class MovieRepository : BaseRepository<Movie>, IMovieRepository
    {
        public MovieRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
        public async override Task<IEnumerable<Movie>> GetAllAsync()
        {
            return await  _tables.Include(c => c.Cinema).Include(a=>a.Actor_Movies).ThenInclude(a=>a.Actor).ToListAsync();
        }
          public async override Task<Movie> GetByIdAsync(int id)
        {
            return await  _tables.Include(c => c.Cinema).FirstOrDefaultAsync(c=>c.Id == id);
        }

        
    }
}
