using BookingProject.Application.Interfaces;
using BookingProject.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace BookingProject.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly BookingProjectContext _context;

        public Repository(BookingProjectContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(T entity)
        {
            _context.Set<T>().ToList().Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task RemoveAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
