using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;
using RosTorv.Annotations;
using RosTorv.Common;
using RosTorv.MainView;
using RosTorv.Sofus.View;
using RosTorv.ViewModel;

namespace RosTorv.Sofus.ViewModel
{
    public class SearchViewModel : INotifyPropertyChanged
    {
        private string _searchText;
        private IEnumerable<string> _navneKeywords;
        private IEnumerable<string> _kategoriKeyword;

        public string SearchText
        {
            get { return _searchText; }
            set
            {
                _searchText = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<string> SuggestedItems { get; set; }


        public ICommand TextChangedCommand { get; set; }
        public ICommand SuggestionChosenCommand { get; set; }
        public ICommand QuerySubmittedCommand { get; set; }

        public SearchViewModel()
        {
            SuggestedItems = new ObservableCollection<string>();
 
            _navneKeywords = Persistency.ReadAndDeserializeButikNavne();
            _kategoriKeyword = Persistency.ReadAndDeserializeKategorier();

            TextChangedCommand = new RelayCommand<AutoSuggestBoxTextChangedEventArgs>(TextChanged);
            SuggestionChosenCommand = new RelayCommand<AutoSuggestBoxSuggestionChosenEventArgs>(SuggestionChosen);
            QuerySubmittedCommand = new RelayCommand<AutoSuggestBoxQuerySubmittedEventArgs>(QuerySubmitted);

        }

        private void TextChanged(AutoSuggestBoxTextChangedEventArgs args)
        {
            if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
            {
                // Clear the previous suggestions
                SuggestedItems.Clear();

                // Finds all keywords that starts whith what the user has typed
                // And then suggests them
                foreach (string s in _navneKeywords)
                {
                    if (s.ToLower().StartsWith(SearchText))
                    {
                        SuggestedItems.Add(s);
                    }
                }
            }
        }

        private void SuggestionChosen(AutoSuggestBoxSuggestionChosenEventArgs args)
        {
            //SearchText = args.SelectedItem.ToString();
        }

        private void QuerySubmitted(AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            // Checks if already on the page
            if (NavigationService.NavigationFrame.Content.GetType() != typeof(ButikInformationPage))
            {
                // If not navigates to ButikInformationPage
                NavigationService.Navigate(typeof(ButikInformationPage));

                // Gets the ViewModel of the MenuPage and then changes the selected item
                MenuViewModel mvm = ((Windows.UI.Xaml.Window.Current.Content as Frame).Content as MenuPage).DataContext as MenuViewModel;
                mvm.SelectedItem = mvm.NavigationItems.First(x => (x.Tag as Type) == typeof(ButikInformationPage));
            }

            // SofusTODO: Change so i dosnt matter what query the user submits
            if (SuggestedItems.Contains(args.QueryText))
            {
                // Gets the ViewModel for the ButikInformationPage
                ButikInformationViewModel bipVM = (NavigationService.NavigationFrame.Content as ButikInformationPage).DataContext as ButikInformationViewModel;
                // Changes the current butik to what the user searched for
                bipVM.CurrentButik = bipVM.Butikker.First(x => x.Navn == args.QueryText);
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
