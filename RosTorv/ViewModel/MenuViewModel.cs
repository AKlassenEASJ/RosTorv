using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Windows.UI.Xaml.Controls;
using RosTorv.Annotations;
using RosTorv.MainView;
using System.Linq;

namespace RosTorv.ViewModel
{
    public class MenuViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<NavigationViewItemBase> NavigationItems { get; set; }

        private NavigationViewItemBase _selectedItem;

        public NavigationViewItemBase SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                OnPropertyChanged();
            }
        }


        public MenuViewModel()
        {
            NavigationItems = new ObservableCollection<NavigationViewItemBase>();

            NavigationItems.Add(new NavigationViewItemHeader() {Content = "Header"});

            NavigationViewItem n1 = new NavigationViewItem();

            // Title i menuen
            n1.Content = "Home Page";
            // Ikonet
            n1.Icon = new SymbolIcon(Symbol.Home);
            // Den page der skal navigates til
            n1.Tag = typeof(HomePage);
            
            NavigationItems.Add(n1);
            SelectedItem = n1;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}