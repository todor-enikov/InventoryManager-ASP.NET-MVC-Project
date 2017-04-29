using System;
using NUnit.Framework;
using InventoryManager.Data.Models;

namespace InventoryManager.UnitTests.InventoryManager.Data.Models
{
    [TestFixture]
    public class ClothesModel_Should
    {
        [Test]
        public void CreateInstanceOfClothes()
        {
            // Arrange
            var clothes = new Clothes();

            // Act & Assert
            Assert.IsInstanceOf<Clothes>(clothes);
        }

        [Test]
        public void CreateInstanceOfClothes_WithNullProperties()
        {
            // Arrange
            var clothes = new Clothes();

            // Act & Assert
            Assert.IsNull(clothes.Name);
            Assert.IsNull(clothes.Description);
            Assert.IsNull(clothes.ImagePath);
        }

        [Test]
        public void CreateInstanceOfClothes_WithTypeTshirt()
        {
            // Arrange
            var clothes = new Clothes();

            // Act
            var expectedClothesType = ClothesType.Tshirt;

            // Assert
            Assert.AreEqual(expectedClothesType, clothes.Type);

        }

        [Test]
        public void CreateInstanceOfClothes_WithSizeXS()
        {
            // Arrange
            var clothes = new Clothes();

            // Act
            var expectedClothesSize = SizeType.XS;

            // Assert
            Assert.AreEqual(expectedClothesSize, clothes.Size);

        }

        [Test]
        public void CreateInstanceOfClothes_WithPriceEqualToZero()
        {
            // Arrange
            var clothes = new Clothes();

            // Act
            var expectedClothesSize = 0;

            // Assert
            Assert.AreEqual(expectedClothesSize, clothes.Price);

        }

        [Test]
        public void CreateInstanceOfClothes_WithQuantityEqualToZero()
        {
            // Arrange
            var clothes = new Clothes();

            // Act
            var expectedClothesSize = 0;

            // Assert
            Assert.AreEqual(expectedClothesSize, clothes.Quantity);

        }

        [Test]
        public void SetCorrectlyProperties()
        {
            // Arrange
            var clothes = new Clothes();

            // Act
            clothes.Name = "Cool";
            clothes.Description = "Boots for the winter";
            clothes.ImagePath = "empty";
            clothes.Price = 5;
            clothes.Quantity = 5;
            clothes.Size = SizeType.S;
            clothes.Type = ClothesType.Boots;

            var expectedName = "Cool";
            var expectedDescription = "Boots for the winter";
            var expectedImagePath = "empty";
            var expectedPrice = 5;
            var expectedQuantity = 5;
            var expectedSize = SizeType.S;
            var expectedType = ClothesType.Boots;


            // Assert
            Assert.AreEqual(expectedName, clothes.Name);
            Assert.AreEqual(expectedDescription, clothes.Description);
            Assert.AreEqual(expectedImagePath, clothes.ImagePath);
            Assert.AreEqual(expectedPrice, clothes.Price);
            Assert.AreEqual(expectedQuantity, clothes.Quantity);
            Assert.AreEqual(expectedSize, clothes.Size);
            Assert.AreEqual(expectedType, clothes.Type);
        }
    }
}
