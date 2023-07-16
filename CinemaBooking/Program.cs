using CinemaBooking.Data.Seeds;
using CinemaBooking.Repositories.ActorRepository;
using CinemaBooking.Repositories.CinemaRepository;
using CinemaBooking.Repositories.MovieRepository;
using CinemaBooking.Repositories.ProducerRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.Cookies;
using CinemaBooking.Repositories.CartItemRepository;
using CinemaBooking.Repositories.CartRepository_;

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
            builder.Services.AddScoped<IProducerRepository,ProducerRepository>();
            builder.Services.AddScoped<ICartItemRepository, CartItemRepository>();
            builder.Services.AddScoped<ICartRepository, CartRepository>();
        
            //builder.Services.AddScoped<CartService>();
            //builder.Services.AddScoped<ApplicationDbInitializer>();


            builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();
            builder.Services.AddMemoryCache();
            builder.Services.AddSession();
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            });

            builder.Services.AddControllersWithViews();
    
        var app = builder.Build();

            ApplicationDbInitializer.SeedUsersAndRolesAsync(app).Wait();
            ApplicationDbInitializer.Seed(app);



            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseSession();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
                       

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}