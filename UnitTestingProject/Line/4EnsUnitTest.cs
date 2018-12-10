using Microsoft.VisualStudio.TestTools.UnitTesting;
using RosTorv.Line.Model;

namespace UnitTestingProject.Line
{
    [TestClass]
    public class Test4Ens
    {
        private SpilSingelton _spil;
        //Tjekker om Point bliver ændret hvis der er 4 ens
        [TestMethod]
        public void TestOm4Ens()
        {
            _spil = SpilSingelton.InstansSpil;
            _spil.Spiller1.PointFelter[10].Point = 0;
            _spil.Spiller1.PointFelter[10].CanChange = true;

            _spil.Bæger.Terninger[0].Eyes = 1;
            _spil.Bæger.Terninger[1].Eyes = 2;
            _spil.Bæger.Terninger[2].Eyes = 2;
            _spil.Bæger.Terninger[3].Eyes = 2;
            _spil.Bæger.Terninger[4].Eyes = 2;

            int exptedResult = 8;

            _spil.EvaluateTerninger.RunAllEvaluate();

            Assert.AreEqual(exptedResult, _spil.Spiller1.PointFelter[10].Point);
        }
        //Tjekker om Point bliver ændret hvis der ikke er 4 ens
        [TestMethod]
        public void TestOmIkke4Ens()
        {
            _spil = SpilSingelton.InstansSpil;
            _spil.Spiller1.PointFelter[10].Point = 0;
            _spil.Spiller1.PointFelter[10].CanChange = true;

            _spil.Bæger.Terninger[0].Eyes = 1;
            _spil.Bæger.Terninger[1].Eyes = 2;
            _spil.Bæger.Terninger[2].Eyes = 1;
            _spil.Bæger.Terninger[3].Eyes = 2;
            _spil.Bæger.Terninger[4].Eyes = 2;

            int exptedResult = 0;

            _spil.EvaluateTerninger.RunAllEvaluate();

            Assert.AreEqual(exptedResult, _spil.Spiller1.PointFelter[10].Point);
        }
        //I tilfælde af at der er mere end 4 ens skal den stadig kunne måle ud fra 4 ens
        [TestMethod]
        public void TestOmMereEnd4Ens()
        {
            _spil = SpilSingelton.InstansSpil;
            _spil.Spiller1.PointFelter[10].Point = 0;
            _spil.Spiller1.PointFelter[10].CanChange = true;

            _spil.Bæger.Terninger[0].Eyes = 2;
            _spil.Bæger.Terninger[1].Eyes = 2;
            _spil.Bæger.Terninger[2].Eyes = 2;
            _spil.Bæger.Terninger[3].Eyes = 2;
            _spil.Bæger.Terninger[4].Eyes = 2;

            int exptedResult = 8;

            _spil.EvaluateTerninger.RunAllEvaluate();

            Assert.AreEqual(exptedResult, _spil.Spiller1.PointFelter[10].Point);
        }
        //Tjekker om Point bliver ændret hvis de ikke kan
        [TestMethod]
        public void TestOm4EnsCanNotChange()
        {
            _spil = SpilSingelton.InstansSpil;
            _spil.Spiller1.PointFelter[10].Point = 0;
            _spil.Spiller1.PointFelter[10].CanChange = false;

            _spil.Bæger.Terninger[0].Eyes = 1;
            _spil.Bæger.Terninger[1].Eyes = 2;
            _spil.Bæger.Terninger[2].Eyes = 2;
            _spil.Bæger.Terninger[3].Eyes = 2;
            _spil.Bæger.Terninger[4].Eyes = 2;

            int exptedResult = 0;

            _spil.EvaluateTerninger.RunAllEvaluate();

            Assert.AreEqual(exptedResult, _spil.Spiller1.PointFelter[10].Point);
        }
    }
}