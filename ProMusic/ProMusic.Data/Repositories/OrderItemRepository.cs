using System;
using ProMusic.Core.Entities;
using ProMusic.Core.Repositories;

namespace ProMusic.Data.Repositories
{
    public class OrderItemRepository : Repository<OrderItem>, IOrderItemRepository
    {
        private readonly DataContext _context;

        public OrderItemRepository(DataContext context) : base(context)
        {
            _context = context;
        }
    }
}
