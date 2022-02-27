using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProMusic.Data.Repositories
{
    public interface IRepository<TEntity>
    {
        Task AddAsync(TEntity entity);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression);
        IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> expression);
        Task<bool> IsExist(Expression<Func<TEntity, bool>> expression);
        void Delete(TEntity entity);
        Task<int> SaveAsync();
        int Save();
    }
}
