﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using RosTorv.Line.Model;

namespace UnitTestingProject.Line
{
    [TestClass]
    public class Test2Par
    {
        private SpilSingelton _spil;

        //Tjekker om Point bliver ændret hvis der er 2 Par
        [TestMethod]
        public void TestOm2Par()
        {
            _spil = SpilSingelton.InstansSpil;
            _spil.SpillereCollection[0].PointFelter[9].Point = 0;
            _spil.SpillereCollection[0].PointFelter[9].CanChange = true;

            _spil.Bæger.Terninger[0].Eyes = 1;
            _spil.Bæger.Terninger[1].Eyes = 1;
            _spil.Bæger.Terninger[2].Eyes = 3;
            _spil.Bæger.Terninger[3].Eyes = 2;
            _spil.Bæger.Terninger[4].Eyes = 2;

            int exptedResult = 6;

            _spil.EvaluateTerninger.RunAllEvaluate(0);

            Assert.AreEqual(exptedResult, _spil.SpillereCollection[0].PointFelter[9].Point);
        }
        //Tjekker om Point bliver ændret hvis der ikke er 2 par
        [TestMethod]
        public void TestOmIkke2Par()
        {
            _spil = SpilSingelton.InstansSpil;
            _spil.SpillereCollection[0].PointFelter[9].Point = 0;
            _spil.SpillereCollection[0].PointFelter[9].CanChange = true;

            _spil.Bæger.Terninger[0].Eyes = 1;
            _spil.Bæger.Terninger[1].Eyes = 1;
            _spil.Bæger.Terninger[2].Eyes = 3;
            _spil.Bæger.Terninger[3].Eyes = 4;
            _spil.Bæger.Terninger[4].Eyes = 2;

            int exptedResult = 0;

            _spil.EvaluateTerninger.RunAllEvaluate(0);

            Assert.AreEqual(exptedResult, _spil.SpillereCollection[0].PointFelter[9].Point);
        }
        //I tilfælde af at der er mere end 2 af den ene skal den stadig kunne måle ud fra 2 Par
        [TestMethod]
        public void TestOmMereEnd2Par()
        {
            _spil = SpilSingelton.InstansSpil;
            _spil.SpillereCollection[0].PointFelter[9].Point = 0;
            _spil.SpillereCollection[0].PointFelter[9].CanChange = true;

            _spil.Bæger.Terninger[0].Eyes = 1;
            _spil.Bæger.Terninger[1].Eyes = 1;
            _spil.Bæger.Terninger[2].Eyes = 2;
            _spil.Bæger.Terninger[3].Eyes = 2;
            _spil.Bæger.Terninger[4].Eyes = 2;

            int exptedResult = 6;

            _spil.EvaluateTerninger.RunAllEvaluate(0);

            Assert.AreEqual(exptedResult, _spil.SpillereCollection[0].PointFelter[9].Point);
        }
        //Tjekker om Point bliver ændret hvis de ikke kan
        [TestMethod]
        public void TestOm4EnsCanNotChange()
        {
            _spil = SpilSingelton.InstansSpil;
            _spil.SpillereCollection[0].PointFelter[9].Point = 0;
            _spil.SpillereCollection[0].PointFelter[9].CanChange = false;

            _spil.Bæger.Terninger[0].Eyes = 1;
            _spil.Bæger.Terninger[1].Eyes = 1;
            _spil.Bæger.Terninger[2].Eyes = 3;
            _spil.Bæger.Terninger[3].Eyes = 2;
            _spil.Bæger.Terninger[4].Eyes = 2;

            int exptedResult = 0;

            _spil.EvaluateTerninger.RunAllEvaluate(0);

            Assert.AreEqual(exptedResult, _spil.SpillereCollection[0].PointFelter[9].Point);
        }
    }
}