using Microsoft.VisualStudio.TestTools.UnitTesting;
using RosTorv.Line.Model;

namespace UnitTestingProject.Line
{
    [TestClass]
    public class TestFuldtHus
    {
        private SpilSingelton _spil;
        //Test Hvis der er flest af det høje tal
        [TestMethod]
        public void TestFuldtHusFlestHøjttal()
        {
            _spil = SpilSingelton.InstansSpil;
            _spil.Spiller1.PointFelter[13].Point = 0;
            _spil.Spiller1.PointFelter[13].CanChange = true;

            _spil.Bæger.Terninger[0].Eyes = 1;
            _spil.Bæger.Terninger[1].Eyes = 2;
            _spil.Bæger.Terninger[2].Eyes = 2;
            _spil.Bæger.Terninger[3].Eyes = 1;
            _spil.Bæger.Terninger[4].Eyes = 2;

            int exptedResult = 8;

            _spil.EvaluateTerninger.RunAllEvaluate();

            Assert.AreEqual(exptedResult, _spil.Spiller1.PointFelter[13].Point);
        }
        //Test Hvis der er flest af de lave tal
        [TestMethod]
        public void TestFuldtHusFlestLavtTal()
        {
            _spil = SpilSingelton.InstansSpil;
            _spil.Spiller1.PointFelter[13].Point = 0;
            _spil.Spiller1.PointFelter[13].CanChange = true;

            _spil.Bæger.Terninger[0].Eyes = 1;
            _spil.Bæger.Terninger[1].Eyes = 2;
            _spil.Bæger.Terninger[2].Eyes = 1;
            _spil.Bæger.Terninger[3].Eyes = 1;
            _spil.Bæger.Terninger[4].Eyes = 2;

            int exptedResult = 7;

            _spil.EvaluateTerninger.RunAllEvaluate();

            Assert.AreEqual(exptedResult, _spil.Spiller1.PointFelter[13].Point);
        }

        //Test hvis der ikke er fuldt hus
        [TestMethod]
        public void TestFuldtHusHvisDerIkkeEr()
        {
            _spil = SpilSingelton.InstansSpil;
            _spil.Spiller1.PointFelter[13].Point = 0;
            _spil.Spiller1.PointFelter[13].CanChange = true;

            _spil.Bæger.Terninger[0].Eyes = 1;
            _spil.Bæger.Terninger[1].Eyes = 2;
            _spil.Bæger.Terninger[2].Eyes = 3;
            _spil.Bæger.Terninger[3].Eyes = 1;
            _spil.Bæger.Terninger[4].Eyes = 2;

            int exptedResult = 0;

            _spil.EvaluateTerninger.RunAllEvaluate();

            Assert.AreEqual(exptedResult, _spil.Spiller1.PointFelter[13].Point);
        }

        //Test hvis ikke den kan ændres 
        [TestMethod]
        public void TestFuldtHusCanNotChange()
        {
            _spil = SpilSingelton.InstansSpil;
            _spil.Spiller1.PointFelter[13].Point = 0;
            _spil.Spiller1.PointFelter[13].CanChange = false;

            _spil.Bæger.Terninger[0].Eyes = 1;
            _spil.Bæger.Terninger[1].Eyes = 2;
            _spil.Bæger.Terninger[2].Eyes = 1;
            _spil.Bæger.Terninger[3].Eyes = 1;
            _spil.Bæger.Terninger[4].Eyes = 2;

            int exptedResult = 0;

            _spil.EvaluateTerninger.RunAllEvaluate();

            Assert.AreEqual(exptedResult, _spil.Spiller1.PointFelter[13].Point);
        }
    }
}