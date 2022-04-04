using System;
using ProMusic.Core.Entities;
using ProMusic.Core.Repositories;

namespace ProMusic.Data.Repositories
{
    public class SubCategoryRepository : Repository<SubCategory>, ISubCategoryRepository
    {
        private readonly DataContext _context;

        public SubCategoryRepository(DataContext context) : base(context)
        {
            _context = context;
        }
    }
}
