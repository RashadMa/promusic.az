using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ProMusic.Core.Entities;

namespace ProMusic.Data.Repositories
{
    public interface IBrandRepository
    {
        Task AddAsync(Brand brand);
        Task<Brand> GetAsync(Expression<Func<Brand, bool>> expression);
        IQueryable<Brand> GetAll(Expression<Func<Brand, bool>> expression);
        Task<bool> IsExist(Expression<Func<Brand, bool>> expression);
        void Delete(Brand brand);
        Task<int> SaveAsync();
        int Save();
    }
}
