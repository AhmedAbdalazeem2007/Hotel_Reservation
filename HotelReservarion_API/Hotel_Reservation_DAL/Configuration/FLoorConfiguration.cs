


namespace Hotel_Reservation_DAL.Configuration
{
	public class FLoorConfiguration : IEntityTypeConfiguration<Floor>
	{
		public void Configure(EntityTypeBuilder<Floor> builder)
		{
			builder.ToTable("Floors");
			builder.HasKey(p => p.Id);
			builder.Property(p => p.Id)
			 .ValueGeneratedOnAdd()
			 .IsRequired()
			 .UseIdentityColumn(1, 1);

			builder.Property(p => p.Description)
				.HasColumnType("varchar")
				.HasMaxLength(255)
				.HasDefaultValue("")
				.IsRequired();

			builder.Property(p => p.NumberOfRooms)
				.HasColumnType("int")
				.HasDefaultValue(0)
				.IsRequired();
			builder.HasOne(p => p.Hotel)
				.WithMany(p=>p.Floors)
				.HasForeignKey(p => p.HotelId)
	.OnDelete(DeleteBehavior.Cascade);

		}
	}
}
