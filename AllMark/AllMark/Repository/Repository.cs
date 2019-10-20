using AllMark.Core.Models.Base;
using NHibernate;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AllMark.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseModel
    {
        private readonly ISession _session;

        public Repository(ISession session)
        {
            _session = session;
        }

        public async Task<T> GetByIdAsync(int? id)
        {
            return id.HasValue && id > 0 ? await _session.GetAsync<T>(id) : null;
        }

        public IQueryable<T> Query()
        {
            return _session.Query<T>();
        }

        public async Task<T> SaveAsync(T entity)
        {
            await _session.SaveAsync(entity);
            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            await _session.UpdateAsync(entity);
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            await _session.DeleteAsync(entity);
        }

        public async Task DeleteByIdAsync(int? id)
        {
            var entity = await _session.LoadAsync<T>(id);
            await _session.DeleteAsync(entity);
        }

        public async Task<T> SaveOrUpdateAsync(T entity)
        {
            await _session.SaveOrUpdateAsync(entity);
            return entity;
        }

        public async Task FlushAsync()
        {
            try
            {
                if (_session.Transaction?.IsActive ?? false)
                    await _session.Transaction.CommitAsync();
            }
            catch
            {
                if (_session.Transaction?.IsActive ?? false)
                    await _session.Transaction.RollbackAsync();

                throw;
            }
        }

    }
}
