using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Windows.UI.Xaml.Controls;
using RosTorv.Annotations;
using RosTorv.MainView;
using System.Linq;
using RosTorv.Line.View;

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
            PopulateNavigationItems();

            SelectedItem = NavigationItems.First(x => x.GetType() == typeof(NavigationViewItem));
        }

        private void PopulateNavigationItems()
        {
            AddPage("Home Page", Symbol.Home, typeof(HomePage));
            // Add pages under this comment
            AddPage("Butik information", Symbol.Admin, typeof(Sofus.View.ButikInformationPage));
            AddPage("Lines Yatzy", Symbol.Bullets, typeof(GamePage));
        }

        /// <summary>
        /// Adds a page to the list of pages in the NavigationView (HamburgerMenu)
        /// </summary>
        /// <param name="name">The name shown in the menu</param>
        /// <param name="icon">The icon shown in the menu</param>
        /// <param name="pageType">The page the item navigates to (Your view page)</param>
        private void AddPage(string name, Symbol icon, Type pageType)
        {
            NavigationItems.Add(new NavigationViewItem { Content = name, Icon = new SymbolIcon(icon), Tag = pageType });
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}