using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using RosTorv.Common;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace RosTorv.MainView
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MenuPage : Page
    {
        public MenuPage()
        {
            this.InitializeComponent();
            NavigationService.NavigationFrame = navFarme;
            NavigationService.Navigate(typeof(HomePage));
        }

        private void NavView_BackRequested(NavigationView sender, NavigationViewBackRequestedEventArgs args)
        {
            NavigationService.GoBack();
            Type t = NavigationService.NavigationFrame.Content.GetType();
            sender.SelectedItem = (sender.MenuItemsSource as IEnumerable<NavigationViewItemBase>).First(x => (x.Tag as Type) == t);
        }

        private void NavView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            if (args.IsSettingsInvoked)
            {

            }
            else
            {
                string itemtitle = args.InvokedItem as string;
                NavigationViewItemBase navItem = (sender.MenuItemsSource as IEnumerable<NavigationViewItemBase>).First(x => x.Content as string == itemtitle);
                NavigationService.Navigate(navItem.Tag as Type);
            }
        }
    }
}
