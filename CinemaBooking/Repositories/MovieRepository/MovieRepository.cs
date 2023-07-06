namespace CinemaBooking.Repositories.MovieRepository
{
    public class MovieRepository : BaseRepository<Movie>, IMovieRepository
    {
        public MovieRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
        //public async Task<List<Movie>> GetByExprissionAsync()
        //{
        //    return await GetByExprissionAsync(m => m.Cinema);
        //}
    }
}
