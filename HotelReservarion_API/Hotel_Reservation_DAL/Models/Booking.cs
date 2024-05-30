

namespace Hotel_Reservation_DAL.Models
{
    public class Booking:BaseEntity
    {
        public string CustomerName { get; set; } = string.Empty;
        public string NationalId { get; set; }
        public int CountRooms { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public HotelBranch HotelBranch { get; set; }
        public decimal TotalCost { get; set; }
        public List<Room> Rooms { get; set; } = new List<Room>();

    }
}
