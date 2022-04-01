using System;
using System.Linq;
using System.Linq.Expressions;
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
