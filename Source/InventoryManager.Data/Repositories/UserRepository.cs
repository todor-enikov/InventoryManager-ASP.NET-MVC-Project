using InventoryManager.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.Data.Repositories
{
    public class UserRepository : EfGenericRepository<User>, IUserRepository
    {
        public UserRepository(IInventoryManagerDbContext context)
            : base(context)
        {
        }

        public IQueryable<User> GetUsersByUserName(string username)
        {
            return this.All()
                       .Where(u => u.UserName.Contains(username));
        }
    }
}
