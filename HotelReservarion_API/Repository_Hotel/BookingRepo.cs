



namespace Repository_Hotel
{
    public class BookingRepo : GenericRepository<Booking>, IBookingRepo
    {
        private readonly ReservationDB reservationDB;

        public BookingRepo(ReservationDB reservationDB) : base(reservationDB)
        {
            this.reservationDB = reservationDB;
        }
    }
}
