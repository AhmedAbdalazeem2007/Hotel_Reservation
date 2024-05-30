using Microsoft.AspNetCore.Mvc.Rendering;

namespace HotelReservarion_PL.Dtos
{
    public class ReservationBookDto
    {
        public string CustomerName { get; set; } = string.Empty;
        public string NationalId { get; set; }
        public int CountRooms { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public TypeRoom TypeRoom { get; set; }
        public List<SelectListItem> selectListItems { get; set; }
        public decimal TotalCost { get; private set; }
        public List<Room> Rooms { get; set; } = new List<Room>();
    }
}
