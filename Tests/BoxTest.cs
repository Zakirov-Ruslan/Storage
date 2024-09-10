using Storage.Entities;

namespace Tests
{
    [TestClass]
    public class BoxTest
    {
        [TestMethod]
        public void ConstructorValidParametrs()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => { Box box = new Box(0, -1, -1, -1, -1, DateTime.Now); },
            "An exception was expected but it didn't happen.");
        }

        [TestMethod]
        public void ConstructorNullParametrs()
        {
            Assert.ThrowsException<ArgumentNullException>(() => { Box box = new Box(0, 1, 1, 1, 1, null, null); },
            "An exception was expected but it didn't happen.");
        }

        [TestMethod]
        public void PropertyExpirationDateCalculation()
        {
            DateTime productionDate = DateTime.Now;
            Box box = new Box(0, 1, 1, 1, 1, productionDate);

            DateTime expectedExpirationDate = (productionDate + TimeSpan.FromDays(100)).Date;

            Assert.AreEqual(expectedExpirationDate, box.ExpirationDate);
        }

        [TestMethod]
        public void PropertySizeCalculation()
        {
            int width = 3;
            int height = 4;
            int depth = 5;
            int size = width * height * depth;

            Box box = new Box(0, width, height, depth, 1, DateTime.Now);

            Assert.AreEqual(size, box.Size);
        }
    }
}