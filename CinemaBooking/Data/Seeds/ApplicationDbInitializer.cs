

using CinemaBooking.Contexts;
using CinemaBooking.Data.Const;
using CinemaBooking.Models;
using Microsoft.AspNetCore.Identity;

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
                            ImagePath = "1.jpg"
                        },
                         new Actor()
                         {
                             FullName = "Robert De Niro",
                             Bio = "Action and Drama Italian Actor",
                            ImagePath = "2.jpg"

                         },
                         new Actor()
                         {
                             FullName = "joe pesci",
                             Bio = "Action and Drama Italian Actor",
                            ImagePath = "3.jpg"

                         },
                    });
                    context.SaveChanges();

                }

                if (!context.Cinemas.Any())
                {
                    context.Cinemas.AddRange(new List<Cinema>()
                    {
                        new Cinema()
                        {
                            Name = "Vox",
                            Descripition = " Vox Cinema is The biggest blockbusters in Cairo,  times and book tickets at VOX Cinemas",

                            Logo= "4.jpg"
                        },

                        new Cinema()
                        {
                            Name = "Amir",
                            Descripition = "The biggest and oldest cinema in Alexandria, Egypt are just one click away. Discover the perfect",

                            Logo= "5.jpg"
                        },

                        new Cinema()
                        {
                            Name = "Metro",
                            Descripition = "Metro Cinema is an independent cinema that is also a community-based not-for-profit",

                            Logo= "6.jpg"
                        }

                    });
                    context.SaveChanges();

                }
                if (!context.producers.Any())
                {
                    context.producers.AddRange(new List<Producer>()
                    {
                        new Producer()
                        {
                            FullName = "Martin Scorsese",
                            Bio = "This is the Bio of the first actor",
                            ImagePath = "10.jpg"

                        },
                        new Producer()
                        {
                            FullName = "Noaln",
                            Bio = "This is the Bio of the first actor",
                            ImagePath = "11.jpg"

                        },
                    });
                    context.SaveChanges();

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
                            ImagePath = "6.jpg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(10),
                            CinemaId = 1,
                            ProducerId = 1,
                            MovieCategory = Enums.MovieCategory.Action

                        },
                        new Movie()
                        {
                            Name = "Cazino",
                            Description = "Italian Action Movie",
                            Price = 48,
                            ImagePath = "8.jpg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(10),
                            CinemaId = 2,
                            ProducerId = 2,
                            MovieCategory = Enums.MovieCategory.Adventure

                        },
                        new Movie()
                        {
                            Name = "Good Fellas",
                            Description = "Italian Action Movie",
                            Price = 13,
                            ImagePath = "9.jpg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(10),
                            CinemaId = 3,
                            ProducerId = 2,
                            MovieCategory = Enums.MovieCategory.Adventure

                        },


                    });
                    context.SaveChanges();

                }


                if (!context.Actor_Movies.Any())
                {
                    context.Actor_Movies.AddRange(new List<Actor_Movie>()
                    {
                        new Actor_Movie()
                        {
                            MovieId= 2,
                            ActorId = 1,
                        },
                           new Actor_Movie()
                        {
                            MovieId= 2,
                            ActorId = 2,
                        },
                           new Actor_Movie()
                        {
                            MovieId= 3,
                            ActorId = 3,
                        },
                              new Actor_Movie()
                        {
                            MovieId= 3,
                            ActorId = 1,
                        },
                                 new Actor_Movie()
                        {
                            MovieId= 1,
                            ActorId = 2,
                        },
                                    new Actor_Movie()
                        {
                            MovieId= 1,
                            ActorId = 1,
                        },
                    });
                    context.SaveChanges();

                }
            }
        }

        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {

                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRole.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRole.Admin));
                if (!await roleManager.RoleExistsAsync(UserRole.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRole.User));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                string adminUserEmail = "admin@etickets.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        FullName = "Admin User",
                        UserName = "admin-user",
                        Email = adminUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdminUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAdminUser, UserRole.Admin);
                }


                string appUserEmail = "user@etickets.com";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new ApplicationUser()
                    {
                        FullName = "Application User",
                        UserName = "app-user",
                        Email = appUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAppUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAppUser, UserRole.User);
                }
            }
        }
    }
}
