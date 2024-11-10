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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace FinalProject
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class enter_direct : Page
    {
        public enter_direct()
        {
            this.InitializeComponent();
        }
      
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(cheking));
        }
      
       private void di_Click_1(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(schedul_direct));
        }

        private void d2_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(changedetail));
        }

        private void d_Click_1(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(changclient));
        }
    }
}
