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
            var context = new InventoryManagerDbContext();

            Assert.IsInstanceOf<InventoryManagerDbContext>(context);
        }

        [Test]
        public void CreateInstanceOfIInventoryManagerDbContext()
        {
            var context = new InventoryManagerDbContext();

            Assert.IsInstanceOf<IInventoryManagerDbContext>(context);
        }

        [Test]
        public void MethodCreateInstanceOfInventoryManagerDbContext()
        {
            var context = InventoryManagerDbContext.Create();

            Assert.IsInstanceOf<InventoryManagerDbContext>(context);
        }

        [Test]
        public void MethodCreateInstanceOfIInventoryManagerDbContext()
        {
            var context =  InventoryManagerDbContext.Create();
            
            Assert.IsInstanceOf<IInventoryManagerDbContext>(context);
        }
    }
}
