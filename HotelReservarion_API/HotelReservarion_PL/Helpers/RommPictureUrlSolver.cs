namespace HotelReservarion_PL.Helpers
{
	public class RommPictureUrlSolver : IValueResolver<Room, RoomDto, string>
	{
		private readonly IConfiguration _configuration;

		public RommPictureUrlSolver(IConfiguration configuration)
		{
			_configuration = configuration;
		}
		public string Resolve(Room source, RoomDto destination, string destMember, ResolutionContext context)
		{
			if (!string.IsNullOrEmpty(source.PictureUrl))
			{
				return $"{_configuration["ApiBaseUrl"]}{source.PictureUrl}";
			}
			return string.Empty;
		}
	}
}
