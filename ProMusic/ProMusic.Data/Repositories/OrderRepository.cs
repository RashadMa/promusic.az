using System;
using ProMusic.Core.Entities;
using ProMusic.Core.Repositories;

namespace ProMusic.Data.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        private readonly DataContext _context;

        public OrderRepository(DataContext context) : base(context)
        {
            _context = context;
        }
    }
}
