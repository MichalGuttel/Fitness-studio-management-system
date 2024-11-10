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
    public sealed partial class new_client : Page
    {
        Service1Client Client = new Service1Client();
        List<city> cityList = null;
        List<category> categoryList = null;
        List<typ_menuyim_price_> priceList = null;
        public new_client()
        {

            this.InitializeComponent();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(enter_direct));
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
           this.Frame.Navigate(typeof(MainPage));
        }

        private void closeb_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private async void Page_Loading(FrameworkElement sender, object args)
        {
            cityList = await Client.GetAllcityAsync();
            cmcity.ItemsSource = cityList;

            categoryList = await Client.GetAllcategoryAsync();
            c20.ItemsSource = categoryList;
        }

        private void cmcity_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private async void add_Click(object sender, RoutedEventArgs e)
        {
            if(legal.IsHebrew(cl2.Text)&&legal.IsHebrew(cl3.Text)&&legal.IsHebrew(cl11.Text)&&legal.IsCellPhone(cl5.Text)&&legal.CheackMail(cl6.Text)&&legal.LegalId(cl1.Text))
            {
            this.Opacity = 0.05;
            castumeres s = new castumeres();
            s.id_castumer = cl1.Text;
            s.private_name = cl2.Text;
            s.family_name = cl3.Text;
            s.adresse = cl11.Text;
            s.date_birth = cl7.Date.Date;
            s.kod_category = (category)(c20.SelectedItem);
            s.pelephone = cl5.Text;
            s.mail = cl6.Text;
            s.kod_city = (city)(cmcity.SelectedItem);
            int t= await Client.AddCastumerAsync(s);
            if(t>0)
            p2.IsOpen = true;
           else
            txtMassege.Text = "הנתונים לא נשמרו - בדוק את תקינות הנתונים";
            }
        }
    }
}
