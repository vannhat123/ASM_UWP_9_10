using System;
using System.Collections.Generic;
using System.Diagnostics;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Asm_UWP_Nhat_9_10.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class IsLogin1 : Page
    {
        public IsLogin1()
        {
            this.InitializeComponent();
        }

        private void ToogleMenu_OnClick(object sender, RoutedEventArgs e)
        {
            this.SplitView.IsPaneOpen = !this.SplitView.IsPaneOpen;
        }

        private void Click_Button(object sender, TappedRoutedEventArgs e)
        {
            var naview = sender as NavigationViewItem;
            if (naview != null)
            {
                switch (naview.Tag)
                {
                    case "upload":
                        this.MainContent.Navigate(typeof(UpLoadSong));
                        break;
                    case "mysong":
                        this.MainContent.Navigate(typeof(MySong));
                        break;
                    case "logout":
                        this.MainContent.Navigate(typeof(MasterLayout));
                        break;
                }
            };
        }
    }
}
