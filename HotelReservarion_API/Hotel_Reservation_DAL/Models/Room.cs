

namespace Hotel_Reservation_DAL.Models
{
	public  class Room:BaseEntity
	{
		public int CountOfAdults {  get; set; }
		public int CountOfChilds {  get; set; }
		public string PictureUrl {  get; set; }
		public bool Status { get; set; } = false;
		public TypeRoom? TypeRoom { get; set; }
		public string Description { get; set; }
		public double PricePerDay {  get; set; }
		public bool HavePathroom {  get; set; }
		public Floor Floor { get; set; }
		[ForeignKey("Floor")]
		public int FloorId { get; set; }

		//[ForeignKey("Hotel")]
		//public int HotelId { get; set; }
		//public Hotel Hotel { get; set; }
		//[ForeignKey("Booking")]
		//public int BookingId {  get; set; }
		//public Booking Booking {  get; set; }


	}
}
