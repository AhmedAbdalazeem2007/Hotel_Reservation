

namespace Repository_Hotel.Data
{
	public class ReservationDB:DbContext
	{
        public ReservationDB(DbContextOptions<ReservationDB> dbContextOptions):base(dbContextOptions)
        {
            
        }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
			base.OnModelCreating(modelBuilder);
		}

		public DbSet<Room> Rooms { get; set; }
		public DbSet<Floor> Floors { get; set; }
		public DbSet<Hotel> Hotels { get; set; }
		public DbSet<Booking> Bookings { get; set; }
		public DbSet<Hotel_Core_Layer.Models.Address> Addresses { get; set; }
	}
}
