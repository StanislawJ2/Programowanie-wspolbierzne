using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logika;
using System.Collections.ObjectModel;

namespace Model.Test
{
    [TestClass]
    public class ModelAbstractAPITestds
    {
        [TestMethod]
        public void ModelAbstractAPITest()
        {
            LogicAbstractAPI API1 = LogicAbstractAPI.createAPI();
            ModelAbstractAPI API2 = ModelAbstractAPI.createAPI(API1);
            API2.createZone(2);
            ObservableCollection<Ball_Presentation> test = API2.GetBall_Presentations();
            Assert.AreEqual(2, test.Count);
            API2.stop();   
        }
    }
}