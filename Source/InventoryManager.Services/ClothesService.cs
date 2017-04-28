using InventoryManager.Data.Models;
using InventoryManager.Data.Repositories;
using InventoryManager.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.Services
{
    public class ClothesService : IClothesService
    {
        private readonly IClothesRepository clothesRepository;

        public ClothesService(IClothesRepository clothesRepository)
        {
            this.clothesRepository = clothesRepository;
        }

        public void AddNewClothes(Clothes clothes)
        {
            this.clothesRepository.Add(clothes);
            this.clothesRepository.SaveChanges();
        }
    }
}
