using Microsoft.VisualStudio.TestTools.UnitTesting;
using RosTorv.Anders.Exceptions;
using RosTorv.Anders.Model;

namespace UnitTestingProject.Anders
{
    [TestClass]
    public class PlayerNameUnitTest
    {

        [TestMethod]
        public void TestPlayer_Constructor_NameIsBlankException()
        {
            //Assert
            Assert.ThrowsException<NameIsBlankException>(() => { new Player("", 5000, 10); });
        }

        [TestMethod]
        public void TestPlayer2_Constructor_NameIsBlankException()
        {
            //Assert
            Assert.ThrowsException<NameIsBlankException>(() => { new Player(null, 2000, 4); });
        }

        [TestMethod]
        public void TestPlayer_Constructor_NameIsInappropriate()
        {


            //Assert
            Assert.ThrowsException<NameIsInappropriateException>(() => { new Player("fuckyou", 2000, 50); });

        }

        [TestMethod]
        public void TestPlayer2_Constructor_NameIsInappropriate()
        {


            //Assert
            Assert.ThrowsException<NameIsInappropriateException>(() => { new Player("Fuckyou", 2000, 50); });

        }

        [TestMethod]
        public void TestPlayer3_Constructor_NameIsInappropriate()
        {


            //Assert
            Assert.ThrowsException<NameIsInappropriateException>(() => { new Player("Killyourself", 2000, 50); });

        }

        [TestMethod]
        public void TestPlayer4_Constructor_NameIsInappropriate()
        {


            //Assert
            Assert.ThrowsException<NameIsInappropriateException>(() => { new Player("KillYourself", 2000, 50); });

        }

        [TestMethod]
        public void TestPlayer5_Constructor_NameIsInappropriate()
        {


            //Assert
            Assert.ThrowsException<NameIsInappropriateException>(() => { new Player("k1llyourself", 2000, 50); });

        }

        [TestMethod]
        public void TestPlayer6_Constructor_NameIsInappropriate()
        {


            //Assert
            Assert.ThrowsException<NameIsInappropriateException>(() => { new Player("K1llYourself", 2000, 50); });

        }

    }
}
