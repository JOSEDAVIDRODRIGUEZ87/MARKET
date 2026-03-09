using Microsoft.EntityFrameworkCore;
using MarketProduction.Infrastructure.Persistence;
public class BaseRepository<T> : IAsyncRepository<T> where T : class
{
    protected readonly AppDbContext _context;
    public BaseRepository(AppDbContext context) => _context = context;

    public async Task<IEnumerable<T>> GetAllAsync(int page, int pageSize) =>
        await _context.Set<T>().Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

    public async Task<int> CountAsync() => await _context.Set<T>().CountAsync();

    public async Task AddRangeAsync(IEnumerable<T> entities) {
        await _context.AddRangeAsync(entities);
        await _context.SaveChangesAsync();
    }
}