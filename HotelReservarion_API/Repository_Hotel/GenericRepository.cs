


namespace Repository_Hotel
{
	public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
	{
		private readonly ReservationDB _reservationDB;

		public GenericRepository(ReservationDB reservationDB)
		{
			_reservationDB = reservationDB;
		}
		public async Task Add(T item) 
		{
			await _reservationDB.Set<T>().AddAsync(item);
			_reservationDB.SaveChanges();
		}

		public void Delete(T item)
		{
			_reservationDB.Set<T>().Remove(item);
			_reservationDB.SaveChanges();
		}

		public async Task<IReadOnlyList<T>> GetAllAsync()
		{
			return await _reservationDB.Set<T>().ToListAsync();
		}

		public async Task<T> GetByIdAsync(int id)
		{
			return await _reservationDB.Set<T>().FindAsync(id);
		}
		public void Update(T item)
		{
			_reservationDB.Set<T>().Update(item);
			_reservationDB.SaveChanges();
		}
		public async Task<IReadOnlyList<T>> GetAllWithApecAsync(ISpecification<T> specification)
		{
			return await ApplySpecification(specification).ToListAsync();
		}
		public async Task<T> GetbyIdSpecAsync(ISpecification<T> specification)
		{
			return await ApplySpecification(specification).FirstOrDefaultAsync();
		}
		public async Task<int> GetCountAsyncWithSpec(ISpecification<T> specification)
		{
			return await ApplySpecification(specification).CountAsync();
		}
		private IQueryable<T> ApplySpecification(ISpecification<T> specification)
		{
			return SpecificationEvalutor<T>.GetQuery(_reservationDB.Set<T>(), specification);
		}

	}
}
