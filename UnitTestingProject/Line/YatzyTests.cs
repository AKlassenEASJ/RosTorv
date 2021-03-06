﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using RosTorv.Line.Model;

namespace UnitTestingProject.Line
{
    [TestClass]
    public class YatzyUnitTest
    {
        private SpilSingelton _spil;

        [TestMethod]
        public void TestYatzyMed1()
        {
            _spil = SpilSingelton.InstansSpil;
            _spil.SpillereCollection.Add(new Spiller("name"));
            _spil.SpillereCollection[0].PointFelter[16].Point = 0;
            _spil.SpillereCollection[0].PointFelter[16].CanChange = true;

            _spil.Bæger.Terninger[0].Eyes = 1;
            _spil.Bæger.Terninger[1].Eyes = 1;
            _spil.Bæger.Terninger[2].Eyes = 1;
            _spil.Bæger.Terninger[3].Eyes = 1;
            _spil.Bæger.Terninger[4].Eyes = 1;

            int exptedResult = 50;

            _spil.EvaluateTerninger.RunAllEvaluate(0);

            Assert.AreEqual(exptedResult, _spil.SpillereCollection[0].PointFelter[16].Point);
        }

        [TestMethod]
        public void TestYatzyMed2()
        {
            _spil = SpilSingelton.InstansSpil;
            _spil.SpillereCollection.Add(new Spiller("name"));
            _spil.SpillereCollection[0].PointFelter[16].Point = 0;
            _spil.SpillereCollection[0].PointFelter[16].CanChange = true;

            _spil.Bæger.Terninger[0].Eyes = 2;
            _spil.Bæger.Terninger[1].Eyes = 2;
            _spil.Bæger.Terninger[2].Eyes = 2;
            _spil.Bæger.Terninger[3].Eyes = 2;
            _spil.Bæger.Terninger[4].Eyes = 2;

            int exptedResult = 50;

            _spil.EvaluateTerninger.RunAllEvaluate(0);

            Assert.AreEqual(exptedResult, _spil.SpillereCollection[0].PointFelter[16].Point);
        }

        [TestMethod]
        public void TestYatzyMed3()
        {
            _spil = SpilSingelton.InstansSpil;
            _spil.SpillereCollection.Add(new Spiller("name"));
            _spil.SpillereCollection[0].PointFelter[16].Point = 0;
            _spil.SpillereCollection[0].PointFelter[16].CanChange = true;

            _spil.Bæger.Terninger[0].Eyes = 3;
            _spil.Bæger.Terninger[1].Eyes = 3;
            _spil.Bæger.Terninger[2].Eyes = 3;
            _spil.Bæger.Terninger[3].Eyes = 3;
            _spil.Bæger.Terninger[4].Eyes = 3;

            int exptedResult = 50;

            _spil.EvaluateTerninger.RunAllEvaluate(0);

            Assert.AreEqual(exptedResult, _spil.SpillereCollection[0].PointFelter[16].Point);
        }
        [TestMethod]
        public void TestYatzyMed4()
        {
            _spil = SpilSingelton.InstansSpil;
            _spil.SpillereCollection.Add(new Spiller("name"));
            _spil.SpillereCollection[0].PointFelter[16].Point = 0;
            _spil.SpillereCollection[0].PointFelter[16].CanChange = true;

            _spil.Bæger.Terninger[0].Eyes = 4;
            _spil.Bæger.Terninger[1].Eyes = 4;
            _spil.Bæger.Terninger[2].Eyes = 4;
            _spil.Bæger.Terninger[3].Eyes = 4;
            _spil.Bæger.Terninger[4].Eyes = 4;

            int exptedResult = 50;

            _spil.EvaluateTerninger.RunAllEvaluate(0);

            Assert.AreEqual(exptedResult, _spil.SpillereCollection[0].PointFelter[16].Point);
        }

        [TestMethod]
        public void TestYatzyMed5()
        {
            _spil = SpilSingelton.InstansSpil;
            _spil.SpillereCollection.Add(new Spiller("name"));
            _spil.SpillereCollection[0].PointFelter[16].Point = 0;
            _spil.SpillereCollection[0].PointFelter[16].CanChange = true;

            _spil.Bæger.Terninger[0].Eyes = 5;
            _spil.Bæger.Terninger[1].Eyes = 5;
            _spil.Bæger.Terninger[2].Eyes = 5;
            _spil.Bæger.Terninger[3].Eyes = 5;
            _spil.Bæger.Terninger[4].Eyes = 5;

            int exptedResult = 50;

            _spil.EvaluateTerninger.RunAllEvaluate(0);

            Assert.AreEqual(exptedResult, _spil.SpillereCollection[0].PointFelter[16].Point);
        }
        [TestMethod]
        public void TestYatzyMed6()
        {
            _spil = SpilSingelton.InstansSpil;
            _spil.SpillereCollection.Add(new Spiller("name"));
            _spil.SpillereCollection[0].PointFelter[16].Point = 0;
            _spil.SpillereCollection[0].PointFelter[16].CanChange = true;

            _spil.Bæger.Terninger[0].Eyes = 6;
            _spil.Bæger.Terninger[1].Eyes = 6;
            _spil.Bæger.Terninger[2].Eyes = 6;
            _spil.Bæger.Terninger[3].Eyes = 6;
            _spil.Bæger.Terninger[4].Eyes = 6;

            int exptedResult = 50;

            _spil.EvaluateTerninger.RunAllEvaluate(0);

            Assert.AreEqual(exptedResult, _spil.SpillereCollection[0].PointFelter[16].Point);
        }

        [TestMethod]
        public void TestYatzyMed4Ens()
        {
            _spil = SpilSingelton.InstansSpil;
            _spil.SpillereCollection.Add(new Spiller("name"));
            _spil.SpillereCollection[0].PointFelter[16].Point = 0;
            _spil.SpillereCollection[0].PointFelter[16].CanChange = true;

            _spil.Bæger.Terninger[0].Eyes = 6;
            _spil.Bæger.Terninger[1].Eyes = 1;
            _spil.Bæger.Terninger[2].Eyes = 1;
            _spil.Bæger.Terninger[3].Eyes = 1;
            _spil.Bæger.Terninger[4].Eyes = 1;

            int exptedResult = 0;

            _spil.EvaluateTerninger.RunAllEvaluate(0);

            Assert.AreEqual(exptedResult, _spil.SpillereCollection[0].PointFelter[16].Point);
        }

        [TestMethod]
        public void TestYatzyKanIkkeÆndres()
        {
            _spil = SpilSingelton.InstansSpil;
            _spil.SpillereCollection.Add(new Spiller("name"));
            _spil.SpillereCollection[0].PointFelter[16].Point = 0;
            _spil.SpillereCollection[0].PointFelter[15].CanChange = false;

            _spil.Bæger.Terninger[0].Eyes = 6;
            _spil.Bæger.Terninger[1].Eyes = 1;
            _spil.Bæger.Terninger[2].Eyes = 1;
            _spil.Bæger.Terninger[3].Eyes = 1;
            _spil.Bæger.Terninger[4].Eyes = 1;

            int exptedResult = 0;

            _spil.EvaluateTerninger.RunAllEvaluate(0);

            Assert.AreEqual(exptedResult, _spil.SpillereCollection[0].PointFelter[16].Point);
        }

    }
}
