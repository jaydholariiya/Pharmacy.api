using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmacy.Common.Database.GenericRepository
{
    public interface IRepository<T> where T : class
    {
        T GetById(int id);

        IQueryable<T> GetAll();

        T Add(T entity);

        Task<List<T>> AddRangeAsync(List<T> entities);

        void Update(T entity);

        void Delete(T entity);

        Task<T> GetByIdAsync(int id);

        Task<T> AddAsync(T entity);

        Task UpdateAsync(T entity);
        Task UpdateRangeAsync(List<T> entities);

        Task DeleteAsync(T entity);
        Task<List<T>> DeleteRangeAsync(List<T> entities);
        List<T> DeleteRange(List<T> entities);
    }
}