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
    public sealed partial class changedetail : Page
    {
        Service1Client Client = new Service1Client();
        List<gauides> gauidList = null;
        List<city> cityy = null;
        public changedetail()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(enter_direct));
        }
        //טעינת רשימת מדריכות
        private async void Page_Loading(FrameworkElement sender, object args)
        {
            gauidList = await Client.GetAllGauidesAsync(); 
            lstgauides.ItemsSource = gauidList;

            cityy = await Client.GetAllcityAsync();
            lcity.ItemsSource = cityy;
        }

        private void lstgauides_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void tf_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cop_Click(object sender, RoutedEventArgs e)
        {

        }

        private void poc_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void clspp_Click(object sender, RoutedEventArgs e)
        {
           
            gauides g = new gauides();
            g.kod_guaid = await Client.GetCodtogauidAsync();
           // if (legal.IsHebrew(firnam.Text) && legal.IsHebrew(lasnam.Text) && legal.IsHebrew(addrs.Text) && legal.IsCellPhone(pele.Text) && legal.IsNumber(vtk.Text))
           // {
                g.name_guaid = firnam.Text;
                g.family_guaid = lasnam.Text;
                g.adresse_guaid = addrs.Text;
                g.dateBirth_guaid = birth.Date.Value.Date;
                g.tel_guaid = pele.Text;
                g.vetek = Convert.ToInt32(vtk);
                g.kod_city = (city)(lcity.SelectedItem);
                await Client.AddgauidAsync(g);
            //  }
            //int f = await Client.AddgauidAsync(g);
            //    if (f > 0)

            //        gauid.IsOpen = true;
            //    else
            //        nogauid.IsOpen = true;


        }

        private void clos(object sender, RoutedEventArgs e)
        {
            newgauid.IsOpen = false;
            gauid.IsOpen = false;
            nogauid.IsOpen = false;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            newgauid.IsOpen = true;
            this.Opacity = 0.1;
        }
    }
}
