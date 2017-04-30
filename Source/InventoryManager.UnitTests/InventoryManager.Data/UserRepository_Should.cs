using System;
using NUnit.Framework;
using InventoryManager.Data.Repositories;
using Moq;
using InventoryManager.Data;
using InventoryManager.Data.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace InventoryManager.UnitTests.InventoryManager.Data
{
    [TestFixture]
    public class UserRepository_Should
    {
        [Test]
        public void CreateInstanceOfEfGenericRepository()
        {
            // Arrange
            var mockedDatabase = new Mock<IInventoryManagerDbContext>();
            var repository = new UserRepository(mockedDatabase.Object);

            // Act & Assert
            Assert.IsInstanceOf<EfGenericRepository<User>>(repository);
        }

        [Test]
        public void CreateInstanceOfIEfGenericRepository()
        {
            // Arrange
            var mockedDatabase = new Mock<IInventoryManagerDbContext>();
            var repository = new UserRepository(mockedDatabase.Object);

            // Act & Assert
            Assert.IsInstanceOf<IEfGenericRepository<User>>(repository);
        }

        [Test]
        public void CreateInstanceOfUserRepository()
        {
            // Arrange
            var mockedDatabase = new Mock<IInventoryManagerDbContext>();
            var repository = new UserRepository(mockedDatabase.Object);

            // Act & Assert
            Assert.IsInstanceOf<UserRepository>(repository);
        }

        [Test]
        public void CreateInstanceOfIUserRepository()
        {
            // Arrange
            var mockedDatabase = new Mock<IInventoryManagerDbContext>();
            var repository = new UserRepository(mockedDatabase.Object);

            // Act & Assert
            Assert.IsInstanceOf<IUserRepository>(repository);
        }

        [Test]
        public void VerifyThatMethodGetUsersByUserName_IsCalledExactlyOneTime()
        {
            // Arrange
            var users = new List<User>()
            {
                new User() { FirstName = "Johny", LastName = "Bravo", UserName = "JohnyBravo"},
                new User() { FirstName = "John", LastName = "Atanasov", UserName = "JohnAtanasov"},
            };
            string username = "JohnyBravo";
            var mockedRepository = new Mock<IUserRepository>();
            mockedRepository.Setup(m => m.GetUsersByUserName(username)).Returns(users.AsQueryable());

            // Act
            mockedRepository.Object.GetUsersByUserName(username);

            // Assert
            mockedRepository.Verify(m => m.GetUsersByUserName(username), Times.Exactly(1));
        }
    }
}
