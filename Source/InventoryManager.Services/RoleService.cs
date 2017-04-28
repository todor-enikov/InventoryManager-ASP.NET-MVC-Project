using InventoryManager.Data;
using InventoryManager.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.Services
{
    public class RoleService : IRoleService
    {
        private readonly InventoryManagerDbContext dbContext;

        public RoleService()
        {
            this.dbContext = new InventoryManagerDbContext();
        }

        public string GetCurrentRoleOfUser(string id)
        {
            return dbContext.Roles
                                  .Where(x => x.Id == id)
                                  .FirstOrDefault()
                                  .Name;
        }
    }
}
