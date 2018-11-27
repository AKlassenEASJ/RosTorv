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

namespace RosTorv.Sofus.ViewModel
{
    public class SearchViewModel : INotifyPropertyChanged
    {
        private string _searchText;
        private IEnumerable<string> _navneKeywords;

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

            // Test keywords
            // SofusTODO 
            _navneKeywords = Persistency.ReadAndDeserializeButikNavne();

            TextChangedCommand = new RelayCommand<AutoSuggestBoxTextChangedEventArgs>(TextChanged);
            SuggestionChosenCommand = new RelayCommand<AutoSuggestBoxSuggestionChosenEventArgs>(SuggestionChosen);
            QuerySubmittedCommand = new RelayCommand<AutoSuggestBoxQuerySubmittedEventArgs>(QuerySubmitted);

        }

        private void TextChanged(AutoSuggestBoxTextChangedEventArgs args)
        {
            if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
            {
                SuggestedItems.Clear();
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
            SearchText = args.SelectedItem.ToString();
        }

        private void QuerySubmitted(AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            if(NavigationService.NavigationFrame.Content.GetType() != typeof(ButikInformationPage))
                NavigationService.Navigate(typeof(ButikInformationPage));

            ButikInformationPage bip = NavigationService.NavigationFrame.Content as ButikInformationPage;
            ButikInformationViewModel bipVM = bip.DataContext as ButikInformationViewModel;
            bipVM.CurrentButik = bipVM.Butikker.First(x => x.Navn == args.QueryText);

            SearchText = null;
        }


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
