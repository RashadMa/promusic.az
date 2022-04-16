using System;
using ProMusic.Core.Entities;
using ProMusic.Core.Repositories;

namespace ProMusic.Data.Repositories
{
    public class CommentRepository : Repository<Comment>, ICommentRepository
    {
        private readonly DataContext _context;

        public CommentRepository(DataContext context) : base(context)
        {
            _context = context;
        }
    }
}
