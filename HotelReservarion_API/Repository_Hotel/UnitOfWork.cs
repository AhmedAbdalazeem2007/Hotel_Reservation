


namespace Repository_Hotel
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly ReservationDB _reservationDB;
        private Dictionary<string, GenericRepository<BaseEntity>> _repositories;
        public UnitOfWork(ReservationDB reservationDB)
        {
            this._reservationDB = reservationDB;
            _repositories = new Dictionary<string, GenericRepository<BaseEntity>>();
        }
        public async Task<int> Complete() => await _reservationDB.SaveChangesAsync();
        public async ValueTask DisposeAsync() => await _reservationDB.DisposeAsync();
        public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity
        {
            var type = typeof(TEntity).Name;
            if (!_repositories.ContainsKey(type))
            {
                var repo = new GenericRepository<TEntity>(_reservationDB) as GenericRepository<BaseEntity>;
                _repositories.Add(type, repo);
            }
            return _repositories[type] as IGenericRepository<TEntity>;
        }
    }
}
