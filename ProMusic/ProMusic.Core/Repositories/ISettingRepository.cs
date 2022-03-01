using System;
using System.Threading.Tasks;
using ProMusic.Core.Entities;
using ProMusic.Data.Repositories;

namespace ProMusic.Core.Repositories
{
    public interface ISettingRepository:IRepository<Setting>
    {
        Task<string> GetValueAsync(string key);
    }
}
