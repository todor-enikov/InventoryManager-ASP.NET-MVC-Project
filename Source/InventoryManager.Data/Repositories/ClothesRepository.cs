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
    }
}
