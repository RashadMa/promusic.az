using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProMusic.Data.Repositories
{
    public interface IRepository<TEntity>
    {
        Task AddAsync(TEntity entity);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression, params string[] includes);
        IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> expression, params string[] includes);
        Task<bool> IsExist(Expression<Func<TEntity, bool>> expression, params string[] includes);
        void Delete(TEntity entity);
    }
}
