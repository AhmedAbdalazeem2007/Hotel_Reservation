

namespace Hotel_Reservation_DAL.Models
{
	public class Hotel:BaseEntity
	{
		public string Branch {  get; set; }
		public int ConutStars {  get; set; }
		public int AddressId {  get; set; }
		public Address Address { get; set; }
		public ICollection<Floor> Floors { get; set; } = new HashSet<Floor>();

	}
}
