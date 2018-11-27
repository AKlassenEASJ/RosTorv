using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Microsoft.Toolkit.Uwp.UI.Controls;
using Windows.UI.Xaml.Navigation;
using RosTorv.Line.ViewModel;
using Color = System.Drawing.Color;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace RosTorv.Line.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class GamePage : Page
    {
        int isPressed = 0;
        public GamePageViewModel GamePageViewModel { get; set; }

        public GamePage()
        {
            this.InitializeComponent();
        }

    private void Terning1(object sender, RoutedEventArgs e)
        {
             GamePageViewModel.Bæger.Terning1.ChangeCanRoll();

            if (isPressed == 0)
            {
                Shadow1.Color = Colors.Gold;
                Shadow1.BlurRadius = 4.0;
                Shadow1.OffsetY = 0;
                Shadow1.OffsetX = 0;
                Shadow1.OffsetZ = 0;
                Shadow1.Opacity = 70.0;

                isPressed = 1;
            }
            else if (isPressed == 1)
            {
                Shadow1.Color = Colors.White;
                Shadow1.BlurRadius = 4.0;
                Shadow1.OffsetY = 4;
                Shadow1.OffsetX = 4;
                Shadow1.OffsetZ = 4;
                Shadow1.Opacity = 70.0;
                isPressed = 0;
            }
        }

        
    }
}
