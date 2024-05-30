

using Hotel_Reservation_DAL.Models;

namespace Hotel_Reservation_PL.ViewModels
{
    public class BookViewModel
    {
        public int Id { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string NationalId { get; set; }
        public int CountRooms { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public string PhoneNumber { get; set; }
        public int TotalDays {  get; set; }
        public string Email { get; set; }
     public   Hotel Hotel { get; set; }
        private decimal totalCost = 0;
        public decimal TotalCost
        {
            get { return totalCost; }
            set { totalCost = value; }
        }
        public List<Room> Rooms { get; set; } = new List<Room>();
    }
}
