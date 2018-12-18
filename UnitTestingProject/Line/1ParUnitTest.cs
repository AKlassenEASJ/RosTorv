using Microsoft.VisualStudio.TestTools.UnitTesting;
using RosTorv.Line.Model;

namespace UnitTestingProject.Line
{
    [TestClass]
    public class Test1Par
    {
        private SpilSingelton _spil;

        //Tjekker om Point bliver ændret hvis der er 1 Par
        [TestMethod]
        public void TestOm1Par()
        {   //Arrange
            _spil = SpilSingelton.InstansSpil;
            _spil.SpillereCollection.Add(new Spiller("name"));
            _spil.SpillereCollection[0].PointFelter[8].Point = 0;
            _spil.SpillereCollection[0].PointFelter[8].CanChange = true;

            _spil.Bæger.Terninger[0].Eyes = 1;
            _spil.Bæger.Terninger[1].Eyes = 1;
            _spil.Bæger.Terninger[2].Eyes = 3;
            _spil.Bæger.Terninger[3].Eyes = 2;
            _spil.Bæger.Terninger[4].Eyes = 4;

            int exptedResult = 2;

            //Act
            _spil.EvaluateTerninger.RunAllEvaluate(0);

            //Assert 
            Assert.AreEqual(exptedResult, _spil.SpillereCollection[0].PointFelter[8].Point);
        }

        //Tjekker om Point bliver ændret hvis der ikke er 1 par
        [TestMethod]
        public void TestOmIkke1Par()
        {
            _spil = SpilSingelton.InstansSpil;
            _spil.SpillereCollection.Add(new Spiller("name"));
            _spil.SpillereCollection[0].PointFelter[8].Point = 0;
            _spil.SpillereCollection[0].PointFelter[8].CanChange = true;

            _spil.Bæger.Terninger[0].Eyes = 1;
            _spil.Bæger.Terninger[1].Eyes = 4;
            _spil.Bæger.Terninger[2].Eyes = 3;
            _spil.Bæger.Terninger[3].Eyes = 5;
            _spil.Bæger.Terninger[4].Eyes = 2;

            int exptedResult = 0;

            _spil.EvaluateTerninger.RunAllEvaluate(0);

            Assert.AreEqual(exptedResult, _spil.SpillereCollection[0].PointFelter[8].Point);
        }
        //I tilfælde af at der er mere end 2 skal den stadig kunne måle ud fra 1 Par
        [TestMethod]
        public void TestOmMereEnd1Par()
        {
            _spil = SpilSingelton.InstansSpil;
            _spil.SpillereCollection.Add(new Spiller("name"));
            _spil.SpillereCollection[0].PointFelter[8].Point = 0;
            _spil.SpillereCollection[0].PointFelter[8].CanChange = true;

            _spil.Bæger.Terninger[0].Eyes = 1;
            _spil.Bæger.Terninger[1].Eyes = 1;
            _spil.Bæger.Terninger[2].Eyes = 2;
            _spil.Bæger.Terninger[3].Eyes = 3;
            _spil.Bæger.Terninger[4].Eyes = 1;

            int exptedResult = 2;

            _spil.EvaluateTerninger.RunAllEvaluate(0);

            Assert.AreEqual(exptedResult, _spil.SpillereCollection[0].PointFelter[8].Point);
        }
        //I tilfælde af at der er 2 1 par skal den Kunne vælge den højeste
        [TestMethod]
        public void TestOmHøjesteValgt()
        {
            _spil = SpilSingelton.InstansSpil;
            _spil.SpillereCollection.Add(new Spiller("name"));
            _spil.SpillereCollection[0].PointFelter[8].Point = 0;
            _spil.SpillereCollection[0].PointFelter[8].CanChange = true;

            _spil.Bæger.Terninger[0].Eyes = 1;
            _spil.Bæger.Terninger[1].Eyes = 1;
            _spil.Bæger.Terninger[2].Eyes = 2;
            _spil.Bæger.Terninger[3].Eyes = 3;
            _spil.Bæger.Terninger[4].Eyes = 2;

            int exptedResult = 4;
             
            _spil.EvaluateTerninger.RunAllEvaluate(0);

            Assert.AreEqual(exptedResult, _spil.SpillereCollection[0].PointFelter[8].Point);
        }
        //Tjekker om Point bliver ændret hvis de ikke kan
        [TestMethod]
        public void TestOm4EnsCanNotChange()
        {
            _spil = SpilSingelton.InstansSpil;
            _spil.SpillereCollection.Add(new Spiller("name"));
            _spil.SpillereCollection[0].PointFelter[8].Point = 0;
            _spil.SpillereCollection[0].PointFelter[8].CanChange = false;

            _spil.Bæger.Terninger[0].Eyes = 1;
            _spil.Bæger.Terninger[1].Eyes = 1;
            _spil.Bæger.Terninger[2].Eyes = 3;
            _spil.Bæger.Terninger[3].Eyes = 4;
            _spil.Bæger.Terninger[4].Eyes = 2;

            int exptedResult = 0;

            _spil.EvaluateTerninger.RunAllEvaluate(0);

            Assert.AreEqual(exptedResult, _spil.SpillereCollection[1].PointFelter[8].Point);
        }
    }
}