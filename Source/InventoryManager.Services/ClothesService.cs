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

        public IQueryable<Clothes> GetAllClothes()
        {
            return this.clothesRepository.All();
        }

        public Clothes GetClothesById(Guid id)
        {
            return this.clothesRepository.GetById(id);
        }

        public IQueryable<Clothes> GetClothesByName(string name)
        {
            return this.clothesRepository.GetClothesByName(name);
        }

        public void UpdateClothesInformation(Clothes clothesToUpdate)
        {
            this.clothesRepository.Update(clothesToUpdate);
            this.clothesRepository.SaveChanges();
        }

        public void DeleteClothes(Guid id)
        {
            this.clothesRepository.Delete(id);
            this.clothesRepository.SaveChanges();
        }
    }
}
