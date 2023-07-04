

using CinemaBooking.Contexts;
using CinemaBooking.Models;

namespace CinemaBooking.Data.Seeds
{
    public class ApplicationDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
                context.Database.EnsureCreated();
                if (!context.Actors.Any())
                {
                    context.Actors.AddRange(new List<Actor>()
                        {
                        new Actor()
                        {
                            FullName="Albacino",
                            Bio ="Action and Drama Italian Actor",
                            ImagePath = "wwwroot\\Images\\1.jpg"
                        },
                         new Actor()
                         {
                             FullName = "Robert De Niro",
                             Bio = "Action and Drama Italian Actor",
                            ImagePath = "wwwroot\\Images\\2.jpg"

                         },
                         new Actor()
                         {
                             FullName = "joe pesci",
                             Bio = "Action and Drama Italian Actor",
                            ImagePath = "wwwroot\\Images\\3.jpg"

                         },
                    });

                }

                if (!context.Cinemas.Any())
                {
                    context.Cinemas.AddRange(new List<Cinema>()
                    {
                        new Cinema()
                        {
                            Name = "Vox",
                            Descripition = "The biggest blockbusters in Cairo, Egypt are just one click away. Discover the perfect movie for you, find session times and book tickets at VOX Cinemas",

                            Logo= "wwwroot\\Images\\4.jpg"
                        },

                        new Cinema()
                        {
                            Name = "Amir",
                            Descripition = "The biggest and oldest cinema in Alexandria, Egypt are just one click away. Discover the perfect movie for you",

                            Logo= "wwwroot\\Images\\5.jpg"
                        },

                        new Cinema()
                        {
                            Name = "Metro",
                            Descripition = "Metro Cinema is an independent cinema that is also a community-based not-for-profit society devoted to creating and fostering opportunities for the exhibition of diverse",

                            Logo= "wwwroot\\Images\\6.jpg"
                        }

                    });

                }

                if (!context.Movies.Any())
                {
                    context.Movies.AddRange(new List<Movie>()
                    {
                        new Movie()
                        {
                            Name = "ScareFace",
                            Description = "Italian Action Movie",
                            Price = 39.50,
                            ImagePath = "wwwroot\\Images\\6.jpg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(10),
                            CinemaId = 3,
                            ProducerId = 3,
                            MovieCategory = Enums.MovieCategory.Action

                        },
                        new Movie()
                        {
                            Name = "Cazino",
                            Description = "Italian Action Movie",
                            Price = 39.50,
                            ImagePath = "wwwroot\\Images\\8.jpg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(10),
                            CinemaId = 3,
                            ProducerId = 3,
                            MovieCategory = Enums.MovieCategory.Adventure

                        },
                        new Movie()
                        {
                            Name = "Good Fellas",
                            Description = "Italian Action Movie",
                            Price = 39.50,
                            ImagePath = "wwwroot\\Images\\9.jpg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(10),
                            CinemaId = 3,
                            ProducerId = 3,
                            MovieCategory = Enums.MovieCategory.Adventure

                        },


                    }); 

                }
                if (!context.producers.Any())
                {
                    context.producers.AddRange(new List<Producer>()
                    {
                        new Producer()
                        {
                            FullName = "Producer 1",
                            Bio = "This is the Bio of the first actor",
                            ImagePath = "http://dotnethow.net/images/producers/producer-1.jpeg"

                        },
                    });
                }
            }
        }
    }
}
