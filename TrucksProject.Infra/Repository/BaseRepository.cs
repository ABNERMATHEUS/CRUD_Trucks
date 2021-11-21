using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TrucksProject.Domain.Repository;
using TrucksProject.Infra.DataContext;

namespace TrucksProject.Infra.Repository
{
    public abstract class BaseRepository<T> : IRepository<T> where T : class
    {
        protected readonly Context _context;

        protected BaseRepository(Context context)
        {
            _context = context;
        }

        public async Task<T> DeleteAsync(T obj)
        {
           _context.Set<T>().Remove(obj);
           await _context.SaveChangesAsync();
           return obj;
        }

        public async Task<IReadOnlyCollection<T>> GetAllAsync()
        {
           return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<T> SaveAsync(T obj)
        {
            await _context.Set<T>().AddAsync(obj);
            await _context.SaveChangesAsync();
            return obj;
        }

        public async Task<T> UpdateAsync(T obj)
        {
             _context.Set<T>().Update(obj);          
            await _context.SaveChangesAsync();
            return obj;
        }
    }
}
