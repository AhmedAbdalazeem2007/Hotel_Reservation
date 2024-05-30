
namespace HotelReservarion_PL.Dtos
{
	public class RoomDto
	{
		public int CountOfAdults {  get; set; }
		public int CountOfChilds {  get; set; }
		public bool Status { get; set; } = false;
		public string TypeRoom { get; set; }
		public string Description { get; set; }
		public decimal Price { get; set; }
		public string PictureUrl { get; set; }
		public bool HavePathroom { get; set; } = false;
		public int FloorId { get; set; }
		public string Floor { get; set; }
		public int HotelId { get; set; }
		public string Hotel { get; set; }
	}
}
