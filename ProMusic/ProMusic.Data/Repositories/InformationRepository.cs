using System;
using ProMusic.Core.Entities;
using ProMusic.Core.Repositories;

namespace ProMusic.Data.Repositories
{
    public class InformationRepository : Repository<Information>, IInformationRepository
    {
        private readonly DataContext _context;

        public InformationRepository(DataContext context) : base(context)
        {
            _context = context;
        }
    }
}
