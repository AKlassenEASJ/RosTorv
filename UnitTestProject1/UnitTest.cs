
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RosTorv.Sofus.Model;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Butik b = new Butik();
            Butik b2 = b;

            Assert.AreEqual(b, b2);
        }
    }
}
