using System;
using NUnit.Framework;
using InventoryManager.Data.Repositories;
using InventoryManager.Data.Models;
using Moq;
using InventoryManager.Data;
using System.Collections.Generic;
using System.Linq;

namespace InventoryManager.UnitTests.InventoryManager.Data
{
    [TestFixture]
    public class EfGenericRepository_Should
    {
        [Test]
        public void CreateInstanseOfEfGenericRepository()
        {
            // Arrange
            var mockedDatabase = new Mock<IInventoryManagerDbContext>();
            var repository = new EfGenericRepository<User>(mockedDatabase.Object);

            // Act & Assert
            Assert.IsInstanceOf<EfGenericRepository<User>>(repository);
        }

        [Test]
        public void CreateInstanseOfIEfGenericRepository()
        {
            // Arrange
            var mockedDatabase = new Mock<IInventoryManagerDbContext>();
            var repository = new EfGenericRepository<User>(mockedDatabase.Object);

            // Act & Assert
            Assert.IsInstanceOf<IEfGenericRepository<User>>(repository);
        }

        [Test]
        public void ThrowArgumentException_IfInventoryManagerDbContextisNull()
        {
            // Arrange, Act & Assert
            Assert.Throws<ArgumentException>(() => new EfGenericRepository<User>(null));
        }

        [Test]
        public void MethodAll_GetsAllAvailableUsers()
        {
            // Arrange
            var users = new List<User>()
            {
                new User() { FirstName = "Johny", LastName = "Bravo"},
                new User() { FirstName = "John", LastName = "Atanasov"},
            };

            var mockedEfGenericRepository = new Mock<IEfGenericRepository<User>>();
            mockedEfGenericRepository.Setup(m => m.All()).Returns(users.AsQueryable());

            // Act
            var result = mockedEfGenericRepository.Object.All().ToList().Count;

            // Assert
            Assert.AreEqual(2, result);
        }

        [Test]
        public void VerifyThatMethodAll_IsCalledExactlyOneTime()
        {
            // Arrange
            var users = new List<User>()
            {
                new User() { FirstName = "Johny", LastName = "Bravo"},
                new User() { FirstName = "John", LastName = "Atanasov"},
            };

            var mockedEfGenericRepository = new Mock<IEfGenericRepository<User>>();
            mockedEfGenericRepository.Setup(m => m.All()).Returns(users.AsQueryable());
            
            // Act
            mockedEfGenericRepository.Object.All();

            // Assert
            mockedEfGenericRepository.Verify(m => m.All(), Times.Exactly(1));
        }

        [Test]
        public void MethodGetById_GetUserById()
        {
            // Arrange
            var users = new List<User>()
            {
                new User() { FirstName = "Johny", LastName = "Bravo"},
                new User() { FirstName = "John", LastName = "Atanasov"},
            };

            var mockedEfGenericRepository = new Mock<IEfGenericRepository<User>>();
            mockedEfGenericRepository.Setup(m => m.GetById(1)).Returns(users[0]);

            // Act
            var result = mockedEfGenericRepository.Object.GetById(1);
            var expectedFirstName = "Johny";

            // Assert
            Assert.AreEqual(expectedFirstName, result.FirstName);
        }

        [Test]
        public void VerifyThatMethodGetById_IsCalledExactlyOneTime()
        {
            // Arrange
            var users = new List<User>()
            {
                new User() { FirstName = "Johny", LastName = "Bravo"},
                new User() { FirstName = "John", LastName = "Atanasov"},
            };

            var mockedEfGenericRepository = new Mock<IEfGenericRepository<User>>();
            mockedEfGenericRepository.Setup(m => m.GetById(1)).Returns(users[0]);

            // Act
            mockedEfGenericRepository.Object.GetById(1);

            // Assert
            mockedEfGenericRepository.Verify(m => m.GetById(1), Times.Exactly(1));
        }

        [Test]
        public void MethodAdd_IsCalledExactlyOneTime()
        {
            // Arrange
            var users = new List<User>()
            {
                new User() { FirstName = "Johny", LastName = "Bravo"}
            };

            var user = new User() { FirstName = "John", LastName = "Atanasov" };

            var mockedEfGenericRepository = new Mock<IEfGenericRepository<User>>();
            mockedEfGenericRepository.Setup(m => m.Add(user)).Verifiable();

            // Act
            mockedEfGenericRepository.Object.Add(user);

            // Assert
            mockedEfGenericRepository.Verify(m=>m.Add(user),Times.Exactly(1));
        }

        [Test]
        public void MethodUpdate_IsCalledExactlyOneTime()
        {
            // Arrange
            var user = new User() { FirstName = "John", LastName = "Atanasov" };

            var mockedEfGenericRepository = new Mock<IEfGenericRepository<User>>();
            mockedEfGenericRepository.Setup(m => m.Update(user)).Verifiable();

            // Act
            mockedEfGenericRepository.Object.Update(user);

            // Assert
            mockedEfGenericRepository.Verify(m => m.Update(user), Times.Exactly(1));
        }

        [Test]
        public void MethodDelete_IsCalledExactlyOneTime()
        {
            // Arrange
            var user = new User() { FirstName = "John", LastName = "Atanasov" };

            var mockedEfGenericRepository = new Mock<IEfGenericRepository<User>>();
            mockedEfGenericRepository.Setup(m => m.Delete(user)).Verifiable();

            // Act
            mockedEfGenericRepository.Object.Delete(user);

            // Assert
            mockedEfGenericRepository.Verify(m => m.Delete(user), Times.Exactly(1));
        }

        [Test]
        public void MethodSaveChanges_IsCalledExactlyOneTime()
        {
            // Arrange
            var user = new User() { FirstName = "John", LastName = "Atanasov" };

            var mockedEfGenericRepository = new Mock<IEfGenericRepository<User>>();
            mockedEfGenericRepository.Setup(m => m.SaveChanges()).Verifiable();

            // Act
            mockedEfGenericRepository.Object.SaveChanges();

            // Assert
            mockedEfGenericRepository.Verify(m => m.SaveChanges(), Times.Exactly(1));
        }
    }
}
