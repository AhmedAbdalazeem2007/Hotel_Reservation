
namespace Hotel_Reservation_BLL.Repositories
{
    public class RoomRepository:GenericRepository<Room>,IRooms
    {
        private readonly HotelReservationDB hotelReservationDB;

        public RoomRepository(HotelReservationDB hotelReservationDB):base(hotelReservationDB)
        {
            this.hotelReservationDB = hotelReservationDB;
        }
    }
}
