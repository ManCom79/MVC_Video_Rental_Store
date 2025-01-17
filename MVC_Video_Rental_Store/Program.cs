using DataAccess;
using DataAccess.Implementations;
using DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using Sevices.Implementations;
using Sevices.Interfaces;

namespace MVC_Video_Rental_Store
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<VideoRentalDbContext>(option => option.UseSqlServer(
                builder.Configuration.GetConnectionString("DefaultConnectionString")
                ));
            builder.Services.AddTransient<IUserDataTableRepository, UserDataTableRepository>();
            builder.Services.AddTransient<IMovieDataTableRepository, MovieDataTableRepository>();
            builder.Services.AddTransient<IRentDataTableRepository, RentDataTableRepository>();
            builder.Services.AddTransient<IUserService, UserService>();
            builder.Services.AddTransient<IMovieService, MovieService>();
            builder.Services.AddTransient<IRentService, RentService>();

            var app = builder.Build();

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
