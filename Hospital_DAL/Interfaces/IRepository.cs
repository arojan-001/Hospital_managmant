using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
        IQueryable<T> Query();
    }
}
