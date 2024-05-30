using Hotel_Reservation_DAL.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel_Reservation_PL.ViewModels
{
    public class RoomViewModel
    {
        public int CountOfAdults { get; set; }
        public int CountOfChilds { get; set; }
        public string PictureUrl { get; set; }
        public string Status { get; set; } = string.Empty;
        public string? TypeRoom { get; set; }
        public string Description { get; set; }
        public double PricePerDay { get; set; }
        public string HavePathroom { get; set; }
        public Floor Floor { get; set; }
        [ForeignKey("Floor")]
        public int FloorId { get; set; }
    }
}
