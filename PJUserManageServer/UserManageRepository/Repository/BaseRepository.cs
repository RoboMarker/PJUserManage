using Microsoft.EntityFrameworkCore;
using UserManageRepository.Context;
using UserManageRepository.Repository.Interface;

namespace UserManageRepository.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly dbCustomDbSampleContext _context;

        public BaseRepository(dbCustomDbSampleContext context)
        {
            _context = context;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public T Add(T entity)
        {
            var result = _context.Set<T>().Add(entity);
            _context.SaveChanges();
            return result.Entity;
        }

        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
        }
    }
}
