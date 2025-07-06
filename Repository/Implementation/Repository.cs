using Microsoft.EntityFrameworkCore;
using Multi_Stage_ATS.Data;
using Multi_Stage_ATS.Repository.Interface;

namespace Multi_Stage_ATS.Repository.Implementation
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _context;
        private readonly DbSet<T> _entities;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync() => await _entities.ToListAsync();
        public async Task<T?> GetByIdAsync(int id) => await _entities.FindAsync(id);
        public async Task AddAsync(T entity) => await _entities.AddAsync(entity);
        public void Remove(T entity) => _entities.Remove(entity);
    }
}
