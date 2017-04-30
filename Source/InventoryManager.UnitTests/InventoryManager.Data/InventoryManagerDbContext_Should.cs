using System;
using NUnit.Framework;
using InventoryManager.Data;

namespace InventoryManager.UnitTests.InventoryManager.Data
{
    [TestFixture]
    public class InventoryManagerDbContext_Should
    {
        [Test]
        public void CreateInstanceOfDatabaseContext()
        {
            // Arrange
            var context = new InventoryManagerDbContext();

            // Act & Assert
            Assert.IsInstanceOf<InventoryManagerDbContext>(context);
        }

        [Test]
        public void CreateInstanceOfIInventoryManagerDbContext()
        {
            // Arrange
            var context = new InventoryManagerDbContext();

            // Act & Assert
            Assert.IsInstanceOf<IInventoryManagerDbContext>(context);
        }

        [Test]
        public void MethodCreateInstanceOfInventoryManagerDbContext()
        {
            // Arrange
            var context = InventoryManagerDbContext.Create();

            // Act & Assert
            Assert.IsInstanceOf<InventoryManagerDbContext>(context);
        }

        [Test]
        public void MethodCreateInstanceOfIInventoryManagerDbContext()
        {
            // Arrange
            var context =  InventoryManagerDbContext.Create();

            // Act & Assert
            Assert.IsInstanceOf<IInventoryManagerDbContext>(context);
        }
    }
}
