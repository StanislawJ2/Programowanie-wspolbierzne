using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dane.Test
{
    [TestClass]
    public class BallTests
    {
        [TestMethod]
        public void BallTest()
        {
            Ball ball = new Ball(5, 2, 2,1);
            Assert.AreEqual(2, ball.X_pozycja);
            Assert.AreEqual(2, ball.Y_pozycja);
            Assert.AreEqual(5, ball.Size);
            ball.X_pozycja = 1;
            ball.Y_pozycja = 1;
            ball.Size = 1;
            Assert.AreEqual(1, ball.X_pozycja);
            Assert.AreEqual(1, ball.Y_pozycja);
            Assert.AreEqual(1, ball.Size);
        }
    }
}