


namespace Repository_Hotel.Identity
{
	public class ApplicationDBContext : IdentityDbContext<ApplicationUser>
	{
		public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
		{

		}
		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
			base.OnModelCreating(builder);
		}
		//public DbSet<Hotel_Core_Layer.Models.Identity.Address> Address { get; set; }

	}
}
