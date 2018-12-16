using Microsoft.VisualStudio.TestTools.UnitTesting;
using RosTorv.Line.Model;

namespace UnitTestingProject.Line
{
    [TestClass]
    public class TestHøjOgLav
    {
        private SpilSingelton _spil;

        //Tjekker om Høj
        [TestMethod]
        public void TestHøj()
        {
            _spil = SpilSingelton.InstansSpil;
            _spil.SpillereCollection[0].PointFelter[12].Point = 0;
            _spil.SpillereCollection[0].PointFelter[12].CanChange = true;

            _spil.Bæger.Terninger[0].Eyes = 2;
            _spil.Bæger.Terninger[1].Eyes = 3;
            _spil.Bæger.Terninger[2].Eyes = 4;
            _spil.Bæger.Terninger[3].Eyes = 5;
            _spil.Bæger.Terninger[4].Eyes = 6;

            int exptedResult = 20;

            _spil.EvaluateTerninger.RunAllEvaluate(0);

            Assert.AreEqual(exptedResult, _spil.SpillereCollection[0].PointFelter[12].Point);
        }

        //Tjekker om ikke Høj
        [TestMethod]
        public void TestIkkeHøj()
        {
            _spil = SpilSingelton.InstansSpil;
            _spil.SpillereCollection[0].PointFelter[12].Point = 0;
            _spil.SpillereCollection[0].PointFelter[12].CanChange = true;

            _spil.Bæger.Terninger[0].Eyes = 6;
            _spil.Bæger.Terninger[1].Eyes = 5;
            _spil.Bæger.Terninger[2].Eyes = 5;
            _spil.Bæger.Terninger[3].Eyes = 5;
            _spil.Bæger.Terninger[4].Eyes = 5;

            int exptedResult = 0;

            _spil.EvaluateTerninger.RunAllEvaluate(0);

            Assert.AreEqual(exptedResult, _spil.SpillereCollection[0].PointFelter[12].Point);
        }
        //Tjekker om lav
        [TestMethod]
        public void TestLav()
        {
            _spil = SpilSingelton.InstansSpil;
            _spil.SpillereCollection[0].PointFelter[13].Point = 0;
            _spil.SpillereCollection[0].PointFelter[13].CanChange = true;

            _spil.Bæger.Terninger[0].Eyes = 1;
            _spil.Bæger.Terninger[1].Eyes = 2;
            _spil.Bæger.Terninger[2].Eyes = 3;
            _spil.Bæger.Terninger[3].Eyes = 4;
            _spil.Bæger.Terninger[4].Eyes = 5;

            int exptedResult = 15;

            _spil.EvaluateTerninger.RunAllEvaluate(0);

            Assert.AreEqual(exptedResult, _spil.SpillereCollection[0].PointFelter[13].Point);
        }

        //Tjekker om ikke lav
        [TestMethod]
        public void TestIkkeLav()
        {
            _spil = SpilSingelton.InstansSpil;
            _spil.SpillereCollection[0].PointFelter[13].Point = 0;
            _spil.SpillereCollection[0].PointFelter[13].CanChange = true;

            _spil.Bæger.Terninger[0].Eyes = 1;
            _spil.Bæger.Terninger[1].Eyes = 2;
            _spil.Bæger.Terninger[2].Eyes = 4;
            _spil.Bæger.Terninger[3].Eyes = 4;
            _spil.Bæger.Terninger[4].Eyes = 5;

            int exptedResult = 0;

            _spil.EvaluateTerninger.RunAllEvaluate(0);

            Assert.AreEqual(exptedResult, _spil.SpillereCollection[0].PointFelter[13].Point);
        }
    }
}