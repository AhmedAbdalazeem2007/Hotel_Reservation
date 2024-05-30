
using Hotel_Reservation_BLL.Interfaces;
using Hotel_Reservation_BLL.Repositories;
using Hotel_Reservation_DAL.Models.Identity;
using Hotel_Reservation_PL.MappingProfile;
using Microsoft.AspNetCore.Identity;

namespace Hotel_Reservation_PL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();
            builder.Services.AddAutoMapper(typeof(MappingProfile_));
            builder.Services.AddDbContext<HotelReservationDB>(
            options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            }, ServiceLifetime.Scoped
            );
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
          

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(
                options =>
                {
                }
                    ).AddEntityFrameworkStores<HotelReservationDB>()
                    .AddDefaultTokenProviders();
         

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseStaticFiles();
            app.UseHttpsRedirection();;
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
