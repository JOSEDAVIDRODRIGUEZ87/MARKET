public interface IAsyncRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync(int page, int pageSize);
    Task<int> CountAsync();
    Task AddRangeAsync(IEnumerable<T> entities);
}