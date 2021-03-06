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
            List<BallLogic> Balls = API.getBalls();
            Assert.AreEqual(2, Balls.Count);
            foreach(BallLogic ball in Balls)
            {
                Assert.IsTrue((ball.X_pozycja - 10) >= 0 && (ball.X_pozycja + 10) <= 100);
                Assert.IsTrue((ball.Y_pozycja - 10) >= 0 && (ball.Y_pozycja + 10) <= 100);
            }
            API.stop();
            Dane.Ball b = new Dane.Ball(3,3,4,1);
            BallLogic logicBall = new BallLogic(b);
  
        }
    }
}