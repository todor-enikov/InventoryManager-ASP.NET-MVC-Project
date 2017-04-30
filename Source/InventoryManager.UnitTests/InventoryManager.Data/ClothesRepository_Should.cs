using System;
using NUnit.Framework;
using InventoryManager.Data;
using Moq;
using InventoryManager.Data.Repositories;
using InventoryManager.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace InventoryManager.UnitTests.InventoryManager.Data
{
    [TestFixture]
    public class ClothesRepository_Should
    {
        [Test]
        public void CreateInstanceOfEfGenericRepository()
        {
            // Arrange
            var mockedDatabase = new Mock<IInventoryManagerDbContext>();
            var repository = new ClothesRepository(mockedDatabase.Object);

            // Act & Assert
            Assert.IsInstanceOf<EfGenericRepository<Clothes>>(repository);
        }

        [Test]
        public void CreateInstanceOfIEfGenericRepository()
        {
            // Arrange
            var mockedDatabase = new Mock<IInventoryManagerDbContext>();
            var repository = new ClothesRepository(mockedDatabase.Object);

            // Act & Assert
            Assert.IsInstanceOf<IEfGenericRepository<Clothes>>(repository);
        }

        [Test]
        public void CreateInstanceOfClothesRepository()
        {
            // Arrange
            var mockedDatabase = new Mock<IInventoryManagerDbContext>();
            var repository = new ClothesRepository(mockedDatabase.Object);

            // Act & Assert
            Assert.IsInstanceOf<ClothesRepository>(repository);
        }

        [Test]
        public void CreateInstanceOfIClothesRepository()
        {
            // Arrange
            var mockedDatabase = new Mock<IInventoryManagerDbContext>();
            var repository = new ClothesRepository(mockedDatabase.Object);

            // Act & Assert
            Assert.IsInstanceOf<IClothesRepository>(repository);
        }

        [Test]
        public void VerifyThatMethodGetUsersByUserName_IsCalledExactlyOneTime()
        {
            // Arrange
            var clothes = new List<Clothes>()
            {
                new Clothes() { Name = "Tshirt" },
                new Clothes() { Name = "Skirt" },
            };
            string name = "Tshirt";
            var mockedRepository = new Mock<IClothesRepository>();
            mockedRepository.Setup(m => m.GetClothesByName(name)).Returns(clothes.AsQueryable());

            // Act
            mockedRepository.Object.GetClothesByName(name);

            // Assert
            mockedRepository.Verify(m => m.GetClothesByName(name), Times.Exactly(1));
        }
    }
}
