





namespace HotelReservarion_PL
{
	public class Program
	{
		public static async Task Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);
			builder.Services.AddControllers();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            builder.Services.AddAutoMapper(typeof(MappingProfile));
            builder.Services.AddDbContext<ReservationDB>(
				options =>
				{
					options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
				}, ServiceLifetime.Scoped
				);

            builder.Services.AddDbContext<ApplicationDBContext>(
                options =>
                {
                    options.UseSqlServer(builder.Configuration.GetConnectionString("IdentitytConnection"));
                }, ServiceLifetime.Scoped
                );
            builder.Services.AddSwaggerServices();
            builder.Services.AddApplicationServices();
            builder.Services.AddIdentityServices(builder.Configuration);
            builder.Services.AddControllers().AddNewtonsoftJson(options =>
options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            //builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
            //         .AddEntityFrameworkStores<ApplicationDBContext>();
            builder.Services.Configure<Email>(builder.Configuration.GetSection("MailSettings"));

            var app = builder.Build();
            var scop = app.Services.CreateScope();
            var services = scop.ServiceProvider;
            var loggerfactory = services.GetRequiredService<ILoggerFactory>();
            try
            {
                var dbcontext = services.GetRequiredService<ReservationDB>();
                await dbcontext.Database.MigrateAsync();
                var identitycontext = services.GetRequiredService<ApplicationDBContext>();
                await identitycontext.Database.MigrateAsync();
                var user = services.GetRequiredService<UserManager<ApplicationUser>>();
            }
            catch (Exception ex)
            {
                var logger = loggerfactory.CreateLogger<Program>();
                logger.LogError(ex, ex.Message);
            }


            app.UseMiddleware<ExceptionMiddleWare>();
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger_1();
			}
			app.UseStatusCodePagesWithReExecute("/errors/{0}");
			app.UseStaticFiles();
			app.UseHttpsRedirection();
			app.UseAuthentication();
			app.UseAuthorization();  
			app.MapControllers();
			app.UseRouting();
			app.Run();
		}
	}
}
