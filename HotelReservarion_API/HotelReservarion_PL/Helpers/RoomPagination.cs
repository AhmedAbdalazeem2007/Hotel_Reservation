namespace HotelReservarion_PL.Helpers
{
	public class RoomPagination
	{
		private int pageSize;
		public int PageSize
		{
			get { return pageSize; }
			set { pageSize = value > 10 ? 10 : value; }
		}
		public int PageIndex { get; set; } = 1;

	}
}
