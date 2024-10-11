using Microsoft.EntityFrameworkCore;

namespace TaskManagerApi.Data
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;
        public Repository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<int> AddAsync(T entity)
        {
            _dbSet.Add(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            
            _context.Entry(entity).State = EntityState.Deleted;
            return await _context.SaveChangesAsync();
        }

        public async Task<bool> Exists(int id)
        {
            return await _dbSet.FindAsync(id) != null;
        }
    }
}