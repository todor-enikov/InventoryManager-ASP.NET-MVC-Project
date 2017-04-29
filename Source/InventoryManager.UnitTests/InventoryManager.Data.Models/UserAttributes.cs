using System;
using NUnit.Framework;
using InventoryManager.Data.Models;
using System.Linq;
using Castle.Components.DictionaryAdapter;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManager.UnitTests.InventoryManager.Data.Models
{
    [TestFixture]
    public class UserAttributes
    {
        [Test]
        public void Email_ShouldHaveAttributeEmailAddress()
        {
            // Arrange
            var user = new User();
            string property = "Email";

            // Act
            bool hasAttribute = user.GetType()
                                    .GetProperty(property)
                                    .GetCustomAttributes(false)
                                    .Where(p => p.GetType() == typeof(EmailAddressAttribute))
                                    .Any();

            // Assert
            Assert.IsTrue(hasAttribute);
        }

        [Test]
        public void UserName_ShouldHaveAttributeIndex()
        {
            // Arrange
            var user = new User();
            string property = "UserName";

            // Act
            bool hasAttribute = user.GetType()
                                    .GetProperty(property)
                                    .GetCustomAttributes(false)
                                    .Where(p => p.GetType() == typeof(IndexAttribute))
                                    .Any();

            // Assert
            Assert.IsTrue(hasAttribute);
        }

        [Test]
        public void FirstName_ShouldHaveAttributeRequired()
        {
            // Arrange
            var user = new User();
            string property = "FirstName";

            // Act
            bool hasAttribute = user.GetType()
                                    .GetProperty(property)
                                    .GetCustomAttributes(false)
                                    .Where(p => p.GetType() == typeof(RequiredAttribute))
                                    .Any();

            // Assert
            Assert.IsTrue(hasAttribute);
        }

        [Test]
        public void FirstName_ShouldHaveAttributeMinLength()
        {
            // Arrange
            var user = new User();
            string property = "FirstName";

            // Act
            bool hasAttribute = user.GetType()
                                    .GetProperty(property)
                                    .GetCustomAttributes(false)
                                    .Where(p => p.GetType() == typeof(MinLengthAttribute))
                                    .Any();

            // Assert
            Assert.IsTrue(hasAttribute);
        }

        [Test]
        public void FirstName_ShouldHaveAttributeMaxLength()
        {
            // Arrange
            var user = new User();
            string property = "FirstName";

            // Act
            bool hasAttribute = user.GetType()
                                    .GetProperty(property)
                                    .GetCustomAttributes(false)
                                    .Where(p => p.GetType() == typeof(MaxLengthAttribute))
                                    .Any();

            // Assert
            Assert.IsTrue(hasAttribute);
        }

        [Test]
        public void LastName_ShouldHaveAttributeRequired()
        {
            // Arrange
            var user = new User();
            string property = "LastName";

            // Act
            bool hasAttribute = user.GetType()
                                    .GetProperty(property)
                                    .GetCustomAttributes(false)
                                    .Where(p => p.GetType() == typeof(RequiredAttribute))
                                    .Any();

            // Assert
            Assert.IsTrue(hasAttribute);
        }

        [Test]
        public void LastName_ShouldHaveAttributeMinLength()
        {
            // Arrange
            var user = new User();
            string property = "LastName";

            // Act
            bool hasAttribute = user.GetType()
                                    .GetProperty(property)
                                    .GetCustomAttributes(false)
                                    .Where(p => p.GetType() == typeof(MinLengthAttribute))
                                    .Any();

            // Assert
            Assert.IsTrue(hasAttribute);
        }

        [Test]
        public void LastName_ShouldHaveAttributeMaxLength()
        {
            // Arrange
            var user = new User();
            string property = "LastName";

            // Act
            bool hasAttribute = user.GetType()
                                    .GetProperty(property)
                                    .GetCustomAttributes(false)
                                    .Where(p => p.GetType() == typeof(MaxLengthAttribute))
                                    .Any();

            // Assert
            Assert.IsTrue(hasAttribute);
        }
    }
}
