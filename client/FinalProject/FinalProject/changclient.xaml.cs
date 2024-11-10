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
using FinalProject.ServiceReference1;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace FinalProject
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class changclient : Page
    {
        Service1Client Client = new Service1Client();
        List<castumeres>castumerList = null;
        List<city> cityy = null;
        castumeres c;

        public changclient()
        {
            this.InitializeComponent();
        }
                            
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(enter_direct));
        }
        //טעינת רשימת לקוחות
        private async void Page_Loading(FrameworkElement sender, object args)
        {
            castumerList = await Client.GetAllCastumeresAsync();
            lstclient.ItemsSource = castumerList;

        }

        private void lstclient_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void tf_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(new_client));
        }

     
        private async void tru_Click(object sender, RoutedEventArgs e)
        {
            castumeres c = (castumeres)(lstclient.SelectedItem);
         int s= await Client.delateAsync(c);
            if(s>0)
            { 
            txnas.Text = "הלקוחה נמחקה";
            }
            else
                txnas.Text = "הלקוחה לא נמחקה";
            c = null;
        }

        private void fals_Click(object sender, RoutedEventArgs e)
        {
            delcas.IsOpen = false;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_del(object sender, RoutedEventArgs e)
        {
            delcas.IsOpen = true;
            this.Opacity = 0.01;
        }

        private void voct_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void vocat_Click(object sender, RoutedEventArgs e)
        {

        }

        private void update_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
