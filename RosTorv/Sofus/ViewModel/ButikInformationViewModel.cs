using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using RosTorv.Annotations;
using RosTorv.Common;
using RosTorv.Sofus.Model;

namespace RosTorv.Sofus.ViewModel
{
    public class ButikInformationViewModel: INotifyPropertyChanged
    {
        private Butik _currentButik;
        private string _selectedKategori;
        private bool _isPaneOpen;

        public ICommand IsPaneOpenCommand { get => new RelayCommand(() => IsPaneOpen = !IsPaneOpen); }
        public bool IsPaneOpen
        {
            get => _isPaneOpen;
            set
            {
                _isPaneOpen = value;
                OnPropertyChanged();
            } 

        }
        public ObservableCollection<Butik> Butikker { get; set; }
        public ObservableCollection<string> Kategorier { get; set; }

        public string SelectedKategori
        {
            get => _selectedKategori;
            set
            {
                _selectedKategori = value;
                OnPropertyChanged();
                KategoriChanged();
            }
        }
        public Butik CurrentButik
        {
            get { return _currentButik; }
            set
            {
                _currentButik = value;
                OnPropertyChanged();
            }
        }

        public ButikInformationViewModel()
        {
            Butikker = new ObservableCollection<Butik>();
            Kategorier = new ObservableCollection<string>();

            Kategorier.Add("Alle butikker");
            foreach (string k in Persistency.ReadAndDeserializeKategorier())
            {
                Kategorier.Add(k);
            }

            SelectedKategori = Kategorier.First();
            CurrentButik = Butikker.First();
        }

        private void KategoriChanged()
        {
            if (!Kategorier.Contains(SelectedKategori))
            {
                string queryText = SelectedKategori;
                _selectedKategori = "Søge resultater";
                if(!Kategorier.Contains(SelectedKategori))
                    Kategorier.Add(SelectedKategori);
                OnPropertyChanged("SelectedKategori");

                Butikker.Clear();
                foreach (Butik b in ButikKatalogSingleton.Instance.ButikKatalog.Where(x => x.Navn.ToLower().StartsWith(queryText.ToLower())))
                {
                    Butikker.Add(b);
                }
                return;
            }
            else if (SelectedKategori == "Alle butikker") {
                Butikker.Clear();
                foreach (Butik b in ButikKatalogSingleton.Instance.ButikKatalog) {
                    Butikker.Add(b);
                }
            }
            else {
                Butikker.Clear();
                foreach (Butik b in ButikKatalogSingleton.Instance.GetButikkerByKategori(SelectedKategori)) {
                    Butikker.Add(b);
                }
            }

            if (Kategorier.Contains("Søge resultater"))
            {
                Kategorier.Remove("Søge resultater");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
