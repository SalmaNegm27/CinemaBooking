using CinemaBooking.Contexts;
using CinemaBooking.Data.Seeds;
using CinemaBooking.Repositories.ActorRepository;
using CinemaBooking.Repositories.CinemaRepository;
using CinemaBooking.Repositories.MovieRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CinemaBooking
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("connection")));
            builder.Services.AddScoped<DbContext, ApplicationDbContext>();
            builder.Services.AddScoped<IActorRepository,ActorRepository>();
            builder.Services.AddScoped<ICinemaRepository,CinemaRepository>();
            builder.Services.AddScoped<IMovieRepository, MovieRepository>();
            builder.Services.AddScoped<ProducerRepository>();
            //builder.Services.AddScoped<ApplicationDbInitializer>();
            var app = builder.Build();

            ApplicationDbInitializer.Seed(app);


            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}