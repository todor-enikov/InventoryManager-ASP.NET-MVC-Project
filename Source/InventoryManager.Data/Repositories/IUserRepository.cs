using InventoryManager.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.Data.Repositories
{
    public interface IUserRepository : IEfGenericRepository<User>
    {
        IQueryable<User> GetUsersByUserName(string username);
    }
}
