using System;
using ProMusic.Core.Entities;
using ProMusic.Core.Repositories;

namespace ProMusic.Data.Repositories
{
    public class AccountRepository : Repository<AppUser>, IAccountRepository
    {
        private readonly DataContext _context;

        public AccountRepository(DataContext context) : base(context)
        {
            _context = context;
        }
    }
}