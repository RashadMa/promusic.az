using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProMusic.Core.Entities;

namespace ProMusic.Data.Repositories
{
    public class BrandRepository
    {
        private readonly DataContext _context;

        public BrandRepository(DataContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Brand brand)
        {
            await _context.Brands.AddAsync(brand);
        }

        public async Task<bool> IsExist(Expression<Func<Brand, bool>> expression)
        {
            return await _context.Brands.AnyAsync(expression);
        }

        public async Task<Brand> GetAsync(Expression<Func<Brand, bool>> expression)
        {
            return await _context.Brands.FirstOrDefaultAsync(expression);
        }

        public IQueryable<Brand> GetAll(Expression<Func<Brand, bool>> expression)
        {
            return _context.Brands.Where(expression).AsQueryable();
        }

        public void Delete(Brand brand)
        {
            _context.Brands.Remove(brand);
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public int Save()
        {
            return _context.SaveChanges();
        }
    }
}
