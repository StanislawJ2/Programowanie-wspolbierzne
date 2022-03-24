using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Projekt.Program program = new Projekt.Program();
            int x = program.add(1, 2);
            Assert.AreEqual(x, 3);
        }
    }
}