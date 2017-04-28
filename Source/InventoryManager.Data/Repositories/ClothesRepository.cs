using InventoryManager.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.Data.Repositories
{
    public class ClothesRepository : EfGenericRepository<Clothes>, IClothesRepository
    {
        public ClothesRepository(IInventoryManagerDbContext context)
            : base(context)
        {
        }

        public IQueryable<Clothes> GetClothesByName(string name)
        {
            return this.All().Where(c => c.Name.Contains(name));
        }
    }
}
