


namespace Repository_Hotel
{
    public class RoomRepo : GenericRepository<Room>, IRoomRepo
    {
        private readonly ReservationDB reservationDB;

        public RoomRepo(ReservationDB reservationDB) : base(reservationDB)
        {
            this.reservationDB = reservationDB;
        }
    }
}
