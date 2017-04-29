using System;
using NUnit.Framework;
using InventoryManager.Data.Models;
using System.Linq;
using Castle.Components.DictionaryAdapter;
using System.ComponentModel.DataAnnotations;

namespace InventoryManager.UnitTests.InventoryManager.Data.Models
{
    [TestFixture]
    public class ClothesAttributes
    {
        [Test]
        public void Name_ShouldHaveAttributeRequired()
        {
            // Arrange
            var user = new Clothes();
            string property = "Name";

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
        public void Name_ShouldHaveAttributeMinLength()
        {
            // Arrange
            var user = new Clothes();
            string property = "Name";

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
        public void Name_ShouldHaveAttributeMaxLength()
        {
            // Arrange
            var user = new Clothes();
            string property = "Name";

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
        public void Type_ShouldHaveAttributeRequired()
        {
            // Arrange
            var user = new Clothes();
            string property = "Type";

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
        public void Quantity_ShouldHaveAttributeRequired()
        {
            // Arrange
            var user = new Clothes();
            string property = "Quantity";

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
        public void Quantity_ShouldHaveAttributeRange()
        {
            // Arrange
            var user = new Clothes();
            string property = "Quantity";

            // Act
            bool hasAttribute = user.GetType()
                                    .GetProperty(property)
                                    .GetCustomAttributes(false)
                                    .Where(p => p.GetType() == typeof(System.ComponentModel.DataAnnotations.RangeAttribute))
                                    .Any();

            // Assert
            Assert.IsTrue(hasAttribute);
        }

        [Test]
        public void Size_ShouldHaveAttributeRequired()
        {
            // Arrange
            var user = new Clothes();
            string property = "Size";

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
        public void Price_ShouldHaveAttributeRequired()
        {
            // Arrange
            var user = new Clothes();
            string property = "Price";

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
        public void Price_ShouldHaveAttributeRange()
        {
            // Arrange
            var user = new Clothes();
            string property = "Price";

            // Act
            bool hasAttribute = user.GetType()
                                    .GetProperty(property)
                                    .GetCustomAttributes(false)
                                    .Where(p => p.GetType() == typeof(System.ComponentModel.DataAnnotations.RangeAttribute))
                                    .Any();

            // Assert
            Assert.IsTrue(hasAttribute);
        }

        [Test]
        public void ImagePath_ShouldHaveAttributeRequired()
        {
            // Arrange
            var user = new Clothes();
            string property = "ImagePath";

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
        public void Description_ShouldHaveAttributeRequired()
        {
            // Arrange
            var user = new Clothes();
            string property = "Description";

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
        public void Description_ShouldHaveAttributeMinLength()
        {
            // Arrange
            var user = new Clothes();
            string property = "Description";

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
        public void Description_ShouldHaveAttributeMaxLength()
        {
            // Arrange
            var user = new Clothes();
            string property = "Description";

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
