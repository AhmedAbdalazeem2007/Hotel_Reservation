





namespace Hotel_Reservation_DAL.Context
{
    public class HotelReservationDB:IdentityDbContext<ApplicationUser>
    {
        public HotelReservationDB(DbContextOptions<HotelReservationDB> dbContextOptions):base(dbContextOptions)
        {   
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server = Ahmed; Database = APIHotelDBsysten ; Trusted_Connection = True ; TrustServerCertificate = true ; MultipleActiveResultSets = true ;");
            }
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }
        public DbSet<Hotel_Reservation_DAL.Models.Address> Addresses { get; set; }
        public DbSet<Floor> Floors { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Room> Rooms { get; set; }

    }
}
