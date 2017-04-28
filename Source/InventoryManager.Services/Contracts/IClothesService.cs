﻿using InventoryManager.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.Services.Contracts
{
    public interface IClothesService
    {
        void AddNewClothes(Clothes clothes);

        IQueryable<Clothes> GetAllClothes();

        IQueryable<Clothes> GetClothesByName(string name);
    }
}
