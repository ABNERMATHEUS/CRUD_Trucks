using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TrucksProject.Domain.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<T> SaveAsync(T obj);

        Task<T> UpdateAsync(T obj);

        Task<T> GetByIdAsync(Guid id);

        Task<IReadOnlyCollection<T>> GetAllAsync();

        Task<T> DeleteAsync(T obj);

    }
}
