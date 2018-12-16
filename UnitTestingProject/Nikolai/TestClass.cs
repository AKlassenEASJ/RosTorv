using Microsoft.VisualStudio.TestTools.UnitTesting;
using RosTorv.Nikolai.Model;

namespace UnitTestingProject.Nikolai
{
    [TestClass]
    public class Test1
    {
        

        /// <summary>
        /// Tester om diceCount tæller ned af.
        /// </summary>
        [TestMethod]
        public void TestDiceCount()
        {

            Spil game = new Spil();
            int startCount = game.DiceCounter;
            game.RollAll();
            int endCount = game.DiceCounter;
            Assert.AreEqual(startCount - 1,endCount);
        }
    }
}