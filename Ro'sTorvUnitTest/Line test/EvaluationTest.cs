using Microsoft.VisualStudio.TestTools.UnitTesting;
using RosTorv.Line.Model;

namespace Ro_sTorvUnitTest.Line_test
{
    [TestClass]
    public class EvaluationTest
    {
        public Spil Spil;
        public BægerSingelton Bæger;

        [TestMethod]
        public void TestFuldtHus()
        {
            // Arrange
            Bæger.Terninger[0].Eyes = 1;
            Bæger.Terninger[1].Eyes = 5;
            Bæger.Terninger[2].Eyes = 4;
            Bæger.Terninger[3].Eyes = 5;
            Bæger.Terninger[4].Eyes = 1;

            int ecptedResult = 12;

            // Act
            Spil.EvaluateTerninger.GetTerningsVærdi();
            Spil.EvaluateTerninger.RunAllEvaluate();

            // Assert
            Assert.AreEqual(ecptedResult, Spil.Spiller1.PointFelter[13]);

        }
    }
}

