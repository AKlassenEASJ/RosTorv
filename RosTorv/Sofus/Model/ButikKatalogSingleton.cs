using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RosTorv.Sofus.Model
{
    public class ButikKatalogSingleton
    {
        private static ButikKatalogSingleton _instance = new ButikKatalogSingleton();

        public static ButikKatalogSingleton Instance
        {
            get { return _instance; }
            set { _instance = value; }
        }

        public IEnumerable<Butik> ButikKatalog { get; }

        private ButikKatalogSingleton()
        {
            ButikKatalog = Persistency.ReadAndDeserializeButikker();
        }
    }
}
