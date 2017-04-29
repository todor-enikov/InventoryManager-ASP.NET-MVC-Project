using System;
using NUnit.Framework;
using InventoryManager.Data.Models;
using System.Collections.Generic;
using Microsoft.AspNet.Identity;

namespace InventoryManager.UnitTests.InventoryManager.Data.Models
{
    [TestFixture]
    public class UserModel_Should
    {
        [Test]
        public void CreateInstanceOfUser()
        {
            // Arrange
            var user = new User();

            // Act & Assert
            Assert.IsInstanceOf<User>(user);
        }

        [Test]
        public void CreateInstanceOfUser_WithNullProperties()
        {
            // Arrange
            var user = new User();

            // Act & Assert
            Assert.IsNull(user.Email);
            Assert.IsNull(user.FirstName);
            Assert.IsNull(user.LastName);
            Assert.IsNull(user.UserName);
        }

        [Test]
        public void CreateInstanceOfUser_WithCountOfClothes_EqualToZero()
        {
            // Arrange
            var user = new User();

            // Act & Assert
            Assert.AreEqual(0, user.Clothes.Count);
        }

        [Test]
        public void SetCorrectlyProperties()
        {
            // Arrange
            var user = new User();

            // Act
            user.FirstName = "John";
            user.LastName = "Travolta";
            user.UserName = "JohnTravolta";
            user.Email = "John@Travolta.net";
            user.Clothes = new List<Clothes>() { new Clothes() { Name = "T-shirt" } };

            var expectedFirstName = "John";
            var expectedLastName = "Travolta";
            var expectedUserName = "JohnTravolta";
            var expectedEmail = "John@Travolta.net";
            var expectedClothesCount = 1;

            // Assert
            Assert.AreEqual(expectedFirstName, user.FirstName);
            Assert.AreEqual(expectedLastName, user.LastName);
            Assert.AreEqual(expectedUserName, user.UserName);
            Assert.AreEqual(expectedEmail, user.Email);
            Assert.AreEqual(expectedClothesCount, user.Clothes.Count);
        }
    }
}
