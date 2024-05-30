



namespace Hotel_Reservation_BLL.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        public Task<IReadOnlyList<T>> GetAllAsync();
        public Task<T> GetByIdAsync(int id);
        public Task Add(T item);
        public void Update(T item);
        public void Delete(T item);

    }
}
