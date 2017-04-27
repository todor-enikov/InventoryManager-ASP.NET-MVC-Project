using InventoryManager.Data.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.Data
{
    public class InventoryManagerDbContext : IdentityDbContext<User>, IInventoryManagerDbContext
    {
        public InventoryManagerDbContext()
            : base("InventoryDbContext")
        {

        }

        public virtual IDbSet<Clothes> Clothes { get; set; }

        public static InventoryManagerDbContext Create()
        {
            return new InventoryManagerDbContext();
        }
    }
}
