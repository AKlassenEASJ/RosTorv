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
using RosTorv.Sofus.Model;
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
                    if (s.ToLower().StartsWith(SearchText.ToLower()))
                        SuggestedItems.Add(s);
                }
                foreach (string s in _kategoriKeyword)
                {
                    if (s.ToLower().StartsWith(SearchText.ToLower()))
                        SuggestedItems.Add(s);
                }

                if (SuggestedItems.Count == 0)
                {
                    //SuggestedItems.Add("No Results");
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
            }

            // Gets the ViewModel for the ButikInformationPage
            ButikInformationViewModel bipVM = (NavigationService.NavigationFrame.Content as ButikInformationPage).DataContext as ButikInformationViewModel;
            
            // Checks if a store name matches what user submitted
            if (_navneKeywords.Contains(args.QueryText))
            {
                bipVM.SelectedKategori = "Alle butikker";
                // Changes the current butik to what the user searched for
                bipVM.CurrentButik = bipVM.Butikker.First(x => x.Navn == args.QueryText);
            }
            // Checks if a category matches what user submitted
            else if (_kategoriKeyword.Contains(args.QueryText))
            {
                // Changes the selected category to match what user searched
                bipVM.SelectedKategori = bipVM.Kategorier.First(x => x == args.QueryText);
            }
            // SofusTODO : shows a list of stores that starts with what user submitted
            else
            {
                bipVM.SelectedKategori = args.QueryText;
                bipVM.CurrentButik = bipVM.Butikker.First();
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
