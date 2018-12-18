using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RosTorv.Line.Exceptions;
using RosTorv.Line.Model;
using RosTorv.Line.ViewModel;

namespace UnitTestingProject.Line
{
    [TestClass]
    public class TjekNavn
    {
        private StartPageViewModel _startPageViewModel;
        private SpilSingelton _spil;

        [TestMethod]
        public void TjekException()
        {
            _spil = SpilSingelton.InstansSpil;

            Assert.ThrowsException<NameMissing>(() => { _spil.AddSpiller(new Spiller("")); });
        }
    }

}
