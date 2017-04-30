using System;
using NUnit.Framework;
using InventoryManager.Services;
using Moq;
using InventoryManager.Data.Repositories;
using InventoryManager.Services.Contracts;
using System.Collections.Generic;
using InventoryManager.Data.Models;
using System.Linq;

namespace InventoryManager.UnitTests.InventoryManager.Services
{
    [TestFixture]
    public class UserService_Should
    {
        [Test]
        public void CreateInstanceOfUserService()
        {
            // Arrange
            var mockedRepository = new Mock<IUserRepository>();
            var userService = new UserService(mockedRepository.Object);

            // Act & Assert
            Assert.IsInstanceOf<UserService>(userService);
        }

        [Test]
        public void CreateInstanceOfIUserService()
        {
            // Arrange
            var mockedRepository = new Mock<IUserRepository>();
            var userService = new UserService(mockedRepository.Object);

            // Act & Assert
            Assert.IsInstanceOf<IUserService>(userService);
        }

        [Test]
        public void ThrowNullReferenceException_IfRepositoryIsNull()
        {
            // Arrange, Act & Assert
            Assert.Throws<NullReferenceException>(() => new UserService(null));
        }

        [Test]
        public void MethodGetAllUsers_ReturnAllUsers()
        {
            // Arrange
            var users = new List<User>()
            {
                new User() { FirstName = "Johny", LastName = "Bravo"},
                new User() { FirstName = "John", LastName = "Atanasov"},
            };

            var mockedRepository = new Mock<IUserRepository>();
            mockedRepository.Setup(m => m.All()).Returns(users.AsQueryable());
            var userService = new UserService(mockedRepository.Object);

            // Act 
            var result = userService.GetAllUsers().ToList();

            // Assert
            Assert.AreEqual(2, result.Count);
        }

        [Test]
        public void MethodAll_IsCalledExactlyOneTime()
        {
            // Arrange
            var users = new List<User>()
            {
                new User() { FirstName = "Johny", LastName = "Bravo"},
                new User() { FirstName = "John", LastName = "Atanasov"},
            };

            var mockedRepository = new Mock<IUserRepository>();
            mockedRepository.Setup(m => m.All()).Returns(users.AsQueryable());
            var userService = new UserService(mockedRepository.Object);

            // Act 
            userService.GetAllUsers();

            // Assert
            mockedRepository.Verify(m => m.All(), Times.Exactly(1));
        }

        [Test]
        public void MethodGetUserById_ReturnSpecificUser()
        {
            // Arrange
            var user = new User() { Id = "test", FirstName = "Johny", LastName = "Bravo" };

            var mockedRepository = new Mock<IUserRepository>();
            mockedRepository.Setup(m => m.GetById("test")).Returns(user);
            var userService = new UserService(mockedRepository.Object);

            // Act 
            var result = userService.GetUserById("test");
            var expectedFirstName = "Johny";

            // Assert
            Assert.AreEqual(expectedFirstName, result.FirstName);
        }

        [Test]
        public void MethodGetById_IsCalledExactlyOneTime()
        {
            // Arrange
            var user = new User() { Id = "test", FirstName = "Johny", LastName = "Bravo" };

            var mockedRepository = new Mock<IUserRepository>();
            mockedRepository.Setup(m => m.GetById("test")).Returns(user);
            var userService = new UserService(mockedRepository.Object);

            // Act 
            userService.GetUserById("test");

            // Assert
            mockedRepository.Verify(m => m.GetById("test"), Times.Exactly(1));
        }

        [Test]
        public void MethodGetUserByUsername_ReturnFoundedUsers()
        {
            // Arrange
            var users = new List<User>()
            {
                new User() { FirstName = "Johny", LastName = "Bravo", UserName = "JohnyBravo"},
                new User() { FirstName = "John", LastName = "Atanasov", UserName = "JohnAtanasov"},
            };

            var mockedRepository = new Mock<IUserRepository>();
            mockedRepository.Setup(m => m.GetUsersByUserName("John")).Returns(users.AsQueryable());
            var userService = new UserService(mockedRepository.Object);

            // Act 
            var result = userService.GetUsersByUserName("John").ToList().Count;
            var expectedCount = 2;

            // Assert
            Assert.AreEqual(expectedCount, result);
        }

        [Test]
        public void MethodGetUsersByUserName_IsCalledExactlyOneTime()
        {
            // Arrange
            var users = new List<User>()
            {
                new User() { FirstName = "Johny", LastName = "Bravo", UserName = "JohnyBravo"},
                new User() { FirstName = "John", LastName = "Atanasov", UserName = "JohnAtanasov"},
            };

            var mockedRepository = new Mock<IUserRepository>();
            mockedRepository.Setup(m => m.GetUsersByUserName("John")).Returns(users.AsQueryable());
            var userService = new UserService(mockedRepository.Object);

            // Act 
            userService.GetUsersByUserName("John");

            // Assert
            mockedRepository.Verify(m => m.GetUsersByUserName("John"), Times.Exactly(1));
        }

        [Test]
        public void MethodUpdateUserInformation_UpdateUserInfo()
        {
            // Arrange
            var user = new User() { Id = "test", FirstName = "Johny", LastName = "Bravo" };

            var mockedRepository = new Mock<IUserRepository>();
            mockedRepository.Setup(m => m.Update(user)).Verifiable();
            var userService = new UserService(mockedRepository.Object);

            // Act 
            user.FirstName = "Test";
            userService.UpdateUserInformation(user);
            var expectedFirstName = "Test";

            // Assert
            Assert.AreEqual(expectedFirstName, user.FirstName);
        }

        [Test]
        public void MethodUpdate_IsCalledExactlyOneTime()
        {
            // Arrange
            var user = new User() { Id = "test", FirstName = "Johny", LastName = "Bravo" };

            var mockedRepository = new Mock<IUserRepository>();
            mockedRepository.Setup(m => m.Update(user)).Verifiable();
            var userService = new UserService(mockedRepository.Object);

            // Act 
            userService.UpdateUserInformation(user);

            // Assert
            mockedRepository.Verify(m => m.Update(user), Times.Exactly(1));
        }
    }
}
