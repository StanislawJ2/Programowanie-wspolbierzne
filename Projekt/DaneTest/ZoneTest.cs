using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dane.Test
{
    [TestClass]
    public class ZoneTests
    {
        [TestMethod]
        public void ZoneTest()
        {
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => new Zone(-1,200,2));
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => new Zone(200, -200, 2));
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => new Zone(200, 200, -1));

            Zone zone = new Zone(100, 100, 2);
            Assert.AreEqual(100, zone.Zone_Y);
            Assert.AreEqual(100, zone.Zone_X);
            Assert.AreEqual(2, zone.Ball_list.Count);
            Assert.AreNotEqual(2, zone.Zone_Y);
        }
    }
}