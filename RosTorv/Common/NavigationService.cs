using System;
using Windows.UI.Xaml.Controls;

namespace RosTorv.Common
{
    public static class NavigationService
    {
        public static Frame NavigationFrame { get; set; }

        public static void Navigate(Type pageType)
        {
            NavigationFrame.Navigate(pageType);
        }
    }
}