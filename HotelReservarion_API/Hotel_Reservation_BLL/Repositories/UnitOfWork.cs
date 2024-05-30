



namespace Hotel_Reservation_BLL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HotelReservationDB _hotelReservationDB;
        private Dictionary<string, GenericRepository<BaseEntity>> _repositories;
        public UnitOfWork(HotelReservationDB hotelReservationDB)
        {
            _hotelReservationDB = hotelReservationDB;
        }
        public async Task<int> Complete() => await _hotelReservationDB.SaveChangesAsync();
        public async ValueTask DisposeAsync() => await _hotelReservationDB.DisposeAsync();
        public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity
        {
            var type = typeof(TEntity).Name;
            if (!_repositories.ContainsKey(type))
            {
                var repo = new GenericRepository<TEntity>(_hotelReservationDB) as GenericRepository<BaseEntity>;
                _repositories.Add(type, repo);
            }
            return _repositories[type] as IGenericRepository<TEntity>;
        }
    }
}
