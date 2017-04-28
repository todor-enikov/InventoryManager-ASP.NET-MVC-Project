﻿using InventoryManager.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.Data.Repositories
{
    public interface IClothesRepository : IEfGenericRepository<Clothes>
    {
        IQueryable<Clothes> GetClothesByName(string name);
    }
}
