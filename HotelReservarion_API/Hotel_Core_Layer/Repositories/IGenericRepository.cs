





namespace Hotel_Core_Layer.Repositories
{
	public interface IGenericRepository<T> where T : BaseEntity
	{
		public Task<IReadOnlyList<T>> GetAllAsync();
		public Task<T> GetByIdAsync(int id);
		public Task Add(T item);
		public void Update(T item);
		public void Delete(T item);
		Task<IReadOnlyList<T>> GetAllWithApecAsync(ISpecification<T> specification);
		Task<T> GetbyIdSpecAsync(ISpecification<T> specification);
	}
}
