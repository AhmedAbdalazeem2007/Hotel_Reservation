


namespace Hotel_Reservation_BLL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly HotelReservationDB hotelReservationDB;

        public GenericRepository(HotelReservationDB hotelReservationDB)
        {
            this.hotelReservationDB = hotelReservationDB;
        }
        public async Task Add(T item)
        {
            await hotelReservationDB.Set<T>().AddAsync(item);
        }

        public void Delete(T item)
        {
            hotelReservationDB.Set<T>().Remove(item);
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return (IReadOnlyList<T>)  await hotelReservationDB.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await hotelReservationDB.Set<T>().FindAsync(id);
        }
        public void Update(T item)
        {
            hotelReservationDB.Set<T>().Update(item);
        }
    }
}
