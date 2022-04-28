using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logika.Test
{
    [TestClass]
    public class BallTests
    {
        [TestMethod]
        public void BallTest()
        {
            Ball ball = new Ball(2, 2);
            Assert.AreEqual(2, ball.X_pozycja);
            Assert.AreEqual(2, ball.Y_pozycja);
            ball.X_pozycja = 1;
            ball.Y_pozycja = 1;
            Assert.AreEqual(1, ball.X_pozycja);
            Assert.AreEqual(1, ball.Y_pozycja);
        }
    }
}