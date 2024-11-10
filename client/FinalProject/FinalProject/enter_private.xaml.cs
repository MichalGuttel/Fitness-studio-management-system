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


namespace FinalProject
{
   
    public sealed partial class enter_private : Page
    {
        Service1Client client = new Service1Client();
        List<menuyim> listMenuyimToCust;
        List<typ_menuyim_price_> listypmanui = null;
        public enter_private()
        {
            this.InitializeComponent();
           
        }
        private async void tf_Click(object sender, RoutedEventArgs e)
        {
            var check = await client.CheckCastumerIfExistAsync(txt1.Text);
            if (check==true)
            {
                tb.Visibility = Visibility.Collapsed;
                castumeres c = await client.GetCustByIdAsync(txt1.Text);
                ClassUser.uesr = c;
                txtName.Text = "שלום וברכה"+" "+c.private_name + " " + c.family_name;
                vis.Visibility = Visibility.Visible;
             
                listMenuyimToCust = await client.GetManuyToCustAsync(c);
               menuyim m = listMenuyimToCust.FirstOrDefault(x => x.first_date.Date<= DateTime.Today.Date && x.last_date.Date >= DateTime.Today.Date);

                ClassUser.manuy = m;
                if (m != null)
                {
                    ClassUser.mone = await client.GetNumLessonfreeAsync(m.kod_manui);
                    numone.Text = "מספר השיעורים שנשארו לך לשבוע זה" + ClassUser.mone;
                }
                if (m==null)
                {
                    tbt.Text="אין לך מנוי";
                    AddManuy.Visibility = Visibility.Visible;
                }
               

            }
            else
            {
                tb.Visibility = Visibility.Visible;
               
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
            this.Frame.Navigate(typeof(schdule_studio));
        }

        private void AddManuy_Click(object sender, RoutedEventArgs e)
        {
            popAddManuy.IsOpen = true;
            Background.Opacity = 0.5;
        }

        private void closePopAddM(object sender, RoutedEventArgs e)
        {
            popAddManuy.IsOpen = false;
            Background.Opacity = 1;
        }

        private async void Page_Loading(FrameworkElement sender, object args)
        {
            listypmanui = await client.GetAllTypmanuiAsync();
            typeManuyCombo.ItemsSource = listypmanui;

        }

        private async void add_Click(object sender, RoutedEventArgs e)
        {
            menuyim n = new menuyim();
            n.kod_manui = await client.GetCodtomenuyimAsync();
            n.id_castumer = ClassUser.uesr;
            n.first_date = DateTime.Today.Date;
            n.last_date = DateTime.Today.AddMonths(ClassUser.manuy.kod_typmanui.num_month);
            n.kod_typmanui = (typ_menuyim_price_)(typeManuyCombo.SelectedItem);
            n.Ispay = true;
            await client.AddManuiAsync(n);
        }

       
    }
}
