using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;
using RosTorv.Common;

namespace RosTorv.Sofus.ViewModel
{
    public class SearchViewModel
    {
        public ICommand TextChangedCommand { get; set; }
        public ICommand SuggestionChosenCommand { get; set; }
        public ICommand QuerySubmittedCommand { get; set; }

        public SearchViewModel()
        {
            TextChangedCommand = new RelayCommand<AutoSuggestBoxTextChangedEventArgs>(TextChanged);
            SuggestionChosenCommand = new RelayCommand<AutoSuggestBoxSuggestionChosenEventArgs>(SuggestionChosen);
            QuerySubmittedCommand = new RelayCommand<AutoSuggestBoxQuerySubmittedEventArgs>(QuerySubmitted);
        }

        private void TextChanged(AutoSuggestBoxTextChangedEventArgs args)
        {
            if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
            {

            }
        }

        private void SuggestionChosen(AutoSuggestBoxSuggestionChosenEventArgs args)
        {

        }

        private void QuerySubmitted(AutoSuggestBoxQuerySubmittedEventArgs args)
        {

        }
    }
}
