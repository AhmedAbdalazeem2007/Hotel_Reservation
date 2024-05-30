

namespace Hotel_Core_Layer.Models
{
	public class Floor:BaseEntity
	{
		public int NumberOfRooms { get; set; }
		public string Description {  get; set; }
		public ICollection<Room> Rooms { get; set; } = new HashSet<Room>();
		public Hotel Hotel { get; set; }
		public int HotelId {  get; set; }
	}
}
