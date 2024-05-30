

namespace Hotel_Core_Layer.Models
{
	public  class Room:BaseEntity
	{
		public string NumberId {  get; set; }
		public int CountOfAdults {  get; set; }
		public int CountOfChilds {  get; set; }
		public string PictureUrl {  get; set; }
		public bool Status { get; set; } = false;
		public TypeRoom? TypeRoom { get; set; }
		public string Description { get; set; }
		public double PricePerDay {  get; set; }
		public bool HavePathroom {  get; set; }
		public Floor Floor { get; set; }
		public int FloorId { get; set; }
		public HotelBranch? HotelBranch {  get; set; }

	}
	public enum HotelBranch:byte
	{
		Alex,
		Cairo,
		Giza,
		Aswan,
		Sharm,
		Redsea
	}
}
