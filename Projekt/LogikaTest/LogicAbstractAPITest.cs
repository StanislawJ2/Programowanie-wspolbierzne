using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Logika.Test
{
    [TestClass]
    public class LogicAbstractAPITests
    {
        [TestMethod]
        public void LogicAbstractAPITest()
        {
            LogicAbstractAPI API = LogicAbstractAPI.createAPI();
            API.createZone(100, 100, 2);
            List<Ball> Balls = API.getBalls();
            Assert.AreEqual(2, Balls.Count);
            foreach(Ball ball in Balls)
            {
                Assert.IsTrue((ball.X_pozycja - 10) >= 0 && (ball.X_pozycja + 10) <= 100);
                Assert.IsTrue((ball.Y_pozycja - 10) >= 0 && (ball.Y_pozycja + 10) <= 100);
            }
            API.stop();
  
        }
    }
}