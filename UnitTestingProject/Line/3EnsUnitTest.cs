using Microsoft.VisualStudio.TestTools.UnitTesting;
using RosTorv.Line.Model;

namespace UnitTestingProject.Line
{
    [TestClass]
    public class Test3Ens
    {
        private SpilSingelton _spil;

        //Tjekker om Point bliver ændret hvis der er 3 ens
        [TestMethod]
        public void TestOm3Ens()
        {
            _spil = SpilSingelton.InstansSpil;
            _spil.SpillereCollection[1].PointFelter[9].Point = 0;
            _spil.SpillereCollection[1].PointFelter[9].CanChange = true;

            _spil.Bæger.Terninger[0].Eyes = 1;
            _spil.Bæger.Terninger[1].Eyes = 1;
            _spil.Bæger.Terninger[2].Eyes = 2;
            _spil.Bæger.Terninger[3].Eyes = 2;
            _spil.Bæger.Terninger[4].Eyes = 2;

            int exptedResult = 6;

            _spil.EvaluateTerninger.RunAllEvaluate(1);

            Assert.AreEqual(exptedResult, _spil.SpillereCollection[1].PointFelter[9].Point);
        }
        //Tjekker om Point bliver ændret hvis der ikke er 3 ens
        [TestMethod]
        public void TestOmIkke3Ens()
        {
            _spil = SpilSingelton.InstansSpil;
            _spil.SpillereCollection[1].PointFelter[9].Point = 0;
            _spil.SpillereCollection[1].PointFelter[9].CanChange = true;

            _spil.Bæger.Terninger[0].Eyes = 1;
            _spil.Bæger.Terninger[1].Eyes = 1;
            _spil.Bæger.Terninger[2].Eyes = 3;
            _spil.Bæger.Terninger[3].Eyes = 2;
            _spil.Bæger.Terninger[4].Eyes = 2;

            int exptedResult = 0;

            _spil.EvaluateTerninger.RunAllEvaluate(1);

            Assert.AreEqual(exptedResult, _spil.SpillereCollection[1].PointFelter[9].Point);
        }
        //I tilfælde af at der er mere end 3 ens skal den stadig kunne måle ud fra 3 ens
        [TestMethod]
        public void TestOmMereEnd3Ens()
        {
            _spil = SpilSingelton.InstansSpil;
            _spil.SpillereCollection[1].PointFelter[9].Point = 0;
            _spil.SpillereCollection[1].PointFelter[9].CanChange = true;

            _spil.Bæger.Terninger[0].Eyes = 1;
            _spil.Bæger.Terninger[1].Eyes = 2;
            _spil.Bæger.Terninger[2].Eyes = 2;
            _spil.Bæger.Terninger[3].Eyes = 2;
            _spil.Bæger.Terninger[4].Eyes = 2;

            int exptedResult = 6;

            _spil.EvaluateTerninger.RunAllEvaluate(1);

            Assert.AreEqual(exptedResult, _spil.SpillereCollection[1].PointFelter[9].Point);
        }
        //Tjekker om Point bliver ændret hvis de ikke kan
        [TestMethod]
        public void TestOm4EnsCanNotChange()
        {
            _spil = SpilSingelton.InstansSpil;
            _spil.SpillereCollection[1].PointFelter[9].Point = 0;
            _spil.SpillereCollection[1].PointFelter[9].CanChange = false;

            _spil.Bæger.Terninger[0].Eyes = 1;
            _spil.Bæger.Terninger[1].Eyes = 2;
            _spil.Bæger.Terninger[2].Eyes = 2;
            _spil.Bæger.Terninger[3].Eyes = 2;
            _spil.Bæger.Terninger[4].Eyes = 2;

            int exptedResult = 0;

            _spil.EvaluateTerninger.RunAllEvaluate(1);

            Assert.AreEqual(exptedResult, _spil.SpillereCollection[1].PointFelter[9].Point);
        }
    }
}