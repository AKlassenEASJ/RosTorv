using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RosTorv.Anders.Handlers
{
    class FileHandler
    {
        #region Instance Fields



        #endregion

        #region Properties

        public PlayerHandler PlayerHandler { get; set; }

        #endregion

        #region Constructor

        public FileHandler(PlayerHandler playerHandler)
        {

        }

        #endregion

        #region Methods



        #endregion






        /*
         * stream = new FileStream("listOfCars.bin", FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, listOfCars);
            stream.Close();

            stream = new FileStream("listOfCars.bin", FileMode.Open, FileAccess.Read, FileShare.None);
            List<Car> listOfCarsDeserialize = (List<Car>)formatter.Deserialize(stream);
            stream.Close();
         */
    }
}
