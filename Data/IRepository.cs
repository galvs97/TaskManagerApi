namespace TaskManagerApi.Data 
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<int> AddAsync(T entity);
        Task<int> Update(T entity);
        Task<int> Delete(int id);
        Task<bool> Exists(int id);
    }
}