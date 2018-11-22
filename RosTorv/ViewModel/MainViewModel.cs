using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Windows.UI.Xaml.Controls;
using RosTorv.Annotations;

namespace RosTorv.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<NavigationViewItemBase> NavigationItems { get; set; }

        private NavigationViewItem _selectedItem;

        public NavigationViewItem SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                OnPropertyChanged();
            }
        }


        public MainViewModel()
        {
            NavigationItems = new ObservableCollection<NavigationViewItemBase>();

            NavigationItems.Add(new NavigationViewItemHeader() {Content = "Header"});

            NavigationViewItem n1 = new NavigationViewItem();
            n1.Content = "Home Page";
            n1.Icon = new SymbolIcon(Symbol.Home);
            n1.Tag = typeof(HomePage);
            
            NavigationItems.Add(n1);

            NavigationViewItem n2 = new NavigationViewItem();
            n2.Content = "Color Page";
            n2.Icon = new SymbolIcon(Symbol.Home);
            n2.Tag = typeof(ColorPage);

            NavigationItems.Add(n2);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}