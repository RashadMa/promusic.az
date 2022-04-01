using System;
using ProMusic.Core.Entities;
using ProMusic.Core.Repositories;

namespace ProMusic.Data.Repositories
{
    public class SliderRepository : Repository<Slider>, ISliderRepository
    {
        private readonly DataContext _context;

        public SliderRepository(DataContext context) : base(context)
        {
            _context = context;
        }
    }
}
