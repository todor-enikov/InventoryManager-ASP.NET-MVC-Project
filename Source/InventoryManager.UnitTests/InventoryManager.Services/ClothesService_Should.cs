using System;
using NUnit.Framework;
using InventoryManager.Data.Repositories;
using Moq;
using InventoryManager.Services;
using InventoryManager.Services.Contracts;
using System.Collections.Generic;
using InventoryManager.Data.Models;
using System.Linq;

namespace InventoryManager.UnitTests.InventoryManager.Services
{
    [TestFixture]
    public class ClothesService_Should
    {
        [Test]
        public void CreateInstanceOfClothesService()
        {
            // Arrange
            var mockedRepository = new Mock<IClothesRepository>();
            var clothesService = new ClothesService(mockedRepository.Object);

            // Act & Assert
            Assert.IsInstanceOf<ClothesService>(clothesService);
        }

        [Test]
        public void CreateInstanceOfIClothesService()
        {
            // Arrange
            var mockedRepository = new Mock<IClothesRepository>();
            var clothesService = new ClothesService(mockedRepository.Object);

            // Act & Assert
            Assert.IsInstanceOf<IClothesService>(clothesService);
        }

        [Test]
        public void ThrowNullReferenceException_IfRepositoryIsNull()
        {
            // Arrange, Act & Assert
            Assert.Throws<NullReferenceException>(() => new ClothesService(null));
        }

        [Test]
        public void MethodGetAllClothes_ReturnAllUsers()
        {
            // Arrange
            var clothes = new List<Clothes>()
            {
                new Clothes() { Name = "Tshirt" },
                new Clothes() { Name = "Skirt" },
            };

            var mockedRepository = new Mock<IClothesRepository>();
            mockedRepository.Setup(m => m.All()).Returns(clothes.AsQueryable());
            var clothesService = new ClothesService(mockedRepository.Object);

            // Act 
            var result = clothesService.GetAllClothes().ToList();

            // Assert
            Assert.AreEqual(2, result.Count);
        }

        [Test]
        public void MethodAll_IsCalledExactlyOneTime()
        {
            // Arrange
            var clothes = new List<Clothes>()
            {
                new Clothes() { Name = "Tshirt" },
                new Clothes() { Name = "Skirt" },
            };

            var mockedRepository = new Mock<IClothesRepository>();
            mockedRepository.Setup(m => m.All()).Returns(clothes.AsQueryable());
            var clothesService = new ClothesService(mockedRepository.Object);

            // Act 
            clothesService.GetAllClothes();

            // Assert
            mockedRepository.Verify(m => m.All(), Times.Exactly(1));
        }

        [Test]
        public void MethodGetClothesById_ReturnSpecificClothes()
        {
            // Arrange
            var clothes = new Clothes() { Id = Guid.NewGuid(), Name = "Tshirt" };

            var mockedRepository = new Mock<IClothesRepository>();
            mockedRepository.Setup(m => m.GetById(clothes.Id)).Returns(clothes);
            var clothesService = new ClothesService(mockedRepository.Object);

            // Act 
            var result = clothesService.GetClothesById(clothes.Id);
            var expectedId = clothes.Id;

            // Assert
            Assert.AreEqual(expectedId, result.Id);
        }

        [Test]
        public void MethodGetById_IsCalledExactlyOneTime()
        {
            // Arrange
            var clothes = new Clothes() { Id = Guid.NewGuid(), Name = "Tshirt" };

            var mockedRepository = new Mock<IClothesRepository>();
            mockedRepository.Setup(m => m.GetById(clothes.Id)).Returns(clothes);
            var clothesService = new ClothesService(mockedRepository.Object);

            // Act 
            clothesService.GetClothesById(clothes.Id);

            // Assert
            mockedRepository.Verify(m => m.GetById(clothes.Id), Times.Exactly(1));
        }

        [Test]
        public void MethodGetClothesByName_ReturnFoundedClothes()
        {
            // Arrange
            var clothes = new List<Clothes>()
            {
                new Clothes() { Name = "Tshirt" },
                new Clothes() { Name = "Skirt" },
            };

            var mockedRepository = new Mock<IClothesRepository>();
            mockedRepository.Setup(m => m.GetClothesByName("t")).Returns(clothes.AsQueryable());
            var clothesService = new ClothesService(mockedRepository.Object);

            // Act 
            var result = clothesService.GetClothesByName("t").ToList().Count;
            var expectedCount = 2;

            // Assert
            Assert.AreEqual(expectedCount, result);
        }

        [Test]
        public void MethodGetClothesByName_IsCalledExactlyOneTime()
        {
            // Arrange
            var clothes = new List<Clothes>()
            {
                new Clothes() { Name = "Tshirt" },
                new Clothes() { Name = "Skirt" },
            };

            var mockedRepository = new Mock<IClothesRepository>();
            mockedRepository.Setup(m => m.GetClothesByName("t")).Returns(clothes.AsQueryable());
            var clothesService = new ClothesService(mockedRepository.Object);

            // Act 
            clothesService.GetClothesByName("t");

            // Assert
            mockedRepository.Verify(m => m.GetClothesByName("t"), Times.Exactly(1));
        }

        [Test]
        public void MethodUpdateClothesInformation_UpdateClothesInfo()
        {
            // Arrange
            var clothes = new Clothes() { Id = Guid.NewGuid(), Name = "Tshirt" };

            var mockedRepository = new Mock<IClothesRepository>();
            mockedRepository.Setup(m => m.Update(clothes)).Verifiable();
            var clothesService = new ClothesService(mockedRepository.Object);

            // Act 
            clothes.Name = "Test";
            clothesService.UpdateClothesInformation(clothes);
            var expectedClothesName = "Test";

            // Assert
            Assert.AreEqual(expectedClothesName, clothes.Name);
        }

        [Test]
        public void MethodUpdate_IsCalledExactlyOneTime()
        {
            // Arrange
            var clothes = new Clothes() { Id = Guid.NewGuid(), Name = "Tshirt" };

            var mockedRepository = new Mock<IClothesRepository>();
            mockedRepository.Setup(m => m.Update(clothes)).Verifiable();
            var clothesService = new ClothesService(mockedRepository.Object);

            // Act 
            clothesService.UpdateClothesInformation(clothes);

            // Assert
            mockedRepository.Verify(m => m.Update(clothes), Times.Exactly(1));
        }

        [Test]
        public void MethodDelete_IsCalledExactlyOneTime()
        {
            // Arrange
            var clothes = new Clothes() { Id = Guid.NewGuid(), Name = "Tshirt" };

            var mockedRepository = new Mock<IClothesRepository>();
            mockedRepository.Setup(m => m.Delete(clothes.Id)).Verifiable();
            var clothesService = new ClothesService(mockedRepository.Object);

            // Act 
            clothesService.DeleteClothes(clothes.Id);

            // Assert
            mockedRepository.Verify(m => m.Delete(clothes.Id), Times.Exactly(1));
        }

        [Test]
        public void MethodAdd_IsCalledExactlyOneTime()
        {
            // Arrange
            var clothes = new Clothes() { Id = Guid.NewGuid(), Name = "Tshirt" };

            var mockedRepository = new Mock<IClothesRepository>();
            mockedRepository.Setup(m => m.Add(clothes)).Verifiable();
            var clothesService = new ClothesService(mockedRepository.Object);

            // Act 
            clothesService.AddNewClothes(clothes);

            // Assert
            mockedRepository.Verify(m => m.Add(clothes), Times.Exactly(1));
        }
    }
}
