
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Logika.Test
{   [TestClass]
    public class BallLogicTests
    {

        [TestMethod]
        public void BallLogicTest()
        {
            Dane.Ball b = new Dane.Ball(1, 1, 2);
            BallLogic ballLogic = new BallLogic(b);

            Assert.IsNotNull(ballLogic);
            Assert.AreEqual(ballLogic.Size, 1);
            Assert.AreEqual(ballLogic.X_pozycja, 1);
            Assert.AreEqual(ballLogic.Y_pozycja, 2);
            ballLogic.Speed_X = 1;
            ballLogic.Speed_Y = 2;
            Assert.AreEqual(ballLogic.X_pozycja, 1);
            Assert.AreEqual(ballLogic.Y_pozycja, 2);

        }
    }
}
