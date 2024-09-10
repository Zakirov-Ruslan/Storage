using Storage.Entities;

namespace Tests
{
    [TestClass]
    public class PalletTest
    {
        [TestMethod]
        public void ConstructorValidParametrs()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {

                Box box = new Box(0, 10, 10, 10, 1, DateTime.Now);

                Pallet pallet = new Pallet(0, 9, 9, 9, new List<Box> { box });
            },
            "An exception was expected but it didn't happen.");
        }

        [TestMethod]
        public void PropertyExpirationDateCalculation()
        {
            Box boxMinExpirationDate = new Box(0, 1, 1, 1, 1, expirationDate: DateTime.MinValue);
            Box boxMaxExpirationDate = new Box(1, 1, 1, 1, 1, expirationDate: DateTime.MaxValue);
            List<Box> boxes = new List<Box>() { boxMinExpirationDate, boxMaxExpirationDate };

            Pallet pallet = new Pallet(0, 1, 1, 1, boxes);

            Assert.AreEqual(boxMinExpirationDate.ExpirationDate, pallet.ExpirationDate);
        }

        [TestMethod]
        public void PropertySizeCalculation()
        {
            Box box = new Box(0, 10, 15, 20, 1, expirationDate: DateTime.MinValue);
            Box secondBox = new Box(1, 10, 12, 14, 1, expirationDate: DateTime.MinValue);
            List<Box> boxes = new List<Box>() { box, secondBox };

            Pallet pallet = new Pallet(0, 20, 20, 20, boxes);

            int expectedSize = boxes.Sum(box => box.Size) + pallet.Height * pallet.Width * pallet.Depth;

            Assert.AreEqual(expectedSize, pallet.Size);
        }

        [TestMethod]
        public void PropertyWeightCalculation()
        {
            Box box = new Box(0, 1, 1, 1, 5, expirationDate: DateTime.MinValue);
            Box secondBox = new Box(1, 1, 1, 1, 7, expirationDate: DateTime.MinValue);
            List<Box> boxes = new List<Box>() { box, secondBox };

            Pallet pallet = new Pallet(0, 20, 20, 20, boxes);

            int expectedWeight = boxes.Sum(box => box.Weight) + 30;

            Assert.AreEqual(expectedWeight, pallet.Weight);
        }
    }
}
