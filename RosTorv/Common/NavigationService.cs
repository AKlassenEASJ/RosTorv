using System;
using Windows.UI.Xaml.Controls;

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
        }

        /// <summary>
        /// Navigates to the most recent item in back navigation history.
        /// </summary>
        public static void GoBack()
        {
            NavigationFrame.GoBack();
        }
    }
}