using AllMark.Core.Models;
using System.Linq;
using System.Threading.Tasks;

namespace AllMark.Repository
{
    public interface IRepository<T> where T: BaseModel
    {
        Task<T> GetByIdAsync(int? id);

        IQueryable<T> Query();

        Task<T> SaveAsync(T entity);

        Task<T> UpdateAsync(T entity);

        Task DeleteAsync(T entity);

        Task DeleteByIdAsync(int? id);

        Task<T> SaveOrUpdateAsync(T entity);

        Task FlushAsync();
    }
}
