


namespace Repository_Hotel.Data.Configuration
{
	public class RoomConfiguration:IEntityTypeConfiguration<Room>
	{
		public void Configure(EntityTypeBuilder<Room> builder)
		{
			builder.ToTable("Rooms");
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
			builder.Property(p => p.TypeRoom)
				.HasColumnType("int")
				.IsRequired(false);
			builder.Property(p => p.PricePerDay)
				.HasColumnType("decimal(18,2)")
				.IsRequired();
			builder.Property(p => p.PictureUrl)
				.HasColumnType("varchar")
				.HasMaxLength(255)
				.HasDefaultValue("")
				.IsRequired();
			builder.Property(p => p.HavePathroom)
				.HasColumnType("bit")
				.HasDefaultValue(true)
				.IsRequired();
			builder.Property(p => p.Status)
				  .HasColumnType("bit")
	.HasDefaultValue(false)
	.IsRequired();

			builder.HasOne(p => p.Floor)
				.WithMany(p=>p.Rooms)
				.HasForeignKey(p => p.FloorId)
	.OnDelete(DeleteBehavior.Cascade);

		}
	}
}
