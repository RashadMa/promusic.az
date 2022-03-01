using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProMusic.Core.Entities;
using ProMusic.Core.Repositories;

namespace ProMusic.Data.Repositories
{
    public class SettingRepository:Repository<Setting>, ISettingRepository
    {
        private readonly DataContext _context;

        public SettingRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<string> GetValueAsync(string key)
        {
            Setting setting = await _context.Settings.FirstOrDefaultAsync(x => x.Key == key);
            return setting.Value;
        }
    }
}
