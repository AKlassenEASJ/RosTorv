using System;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml.Controls;
using RosTorv.MainView;
using RosTorv.ViewModel;

namespace RosTorv.Common
{
    public static class NavigationService
    {
        public static Frame NavigationFrame { get; set; }

        /// <summary>
        /// Navigates to the specified Page, also passing a parameter to be interpreted by the target of the navigation.
        /// </summary>
        /// <param name="pageType">The page to navigate to, specified as a type reference to its partial class type.</param>
        /// <param name="parameter">The navigation parameter to pass to the target page.</param>
        public static void Navigate(Type pageType, object parameter = null)
        {
            NavigationFrame.Navigate(pageType, parameter);
            ChangeMenuSelection();
        }

        /// <summary>
        /// Navigates to the most recent item in back navigation history.
        /// </summary>
        public static void GoBack()
        {
            NavigationFrame.GoBack();
            ChangeMenuSelection();
        }

        /// <summary>
        /// Changes the selected item in the hamburger menu to match what is navigated to
        /// </summary>
        private static void ChangeMenuSelection()
        {
            MenuPage mp = Windows.UI.Xaml.Window.Current.Content as MenuPage;
            if (mp != null)
            {
                MenuViewModel VM = mp.DataContext as MenuViewModel;
                Type t = NavigationFrame.Content.GetType();
                NavigationViewItemBase tmp = (VM.NavigationItems as IEnumerable<NavigationViewItemBase>).FirstOrDefault(x => (x.Tag as Type) == t);
                if (tmp != null)
                    VM.SelectedItem = tmp;
            }
        }
    }
}