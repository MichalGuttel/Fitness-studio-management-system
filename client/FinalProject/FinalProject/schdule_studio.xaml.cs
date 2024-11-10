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
    public sealed partial class schdule_studio : Page
    {
        Service1Client client = new Service1Client();
        List<Chugim> lichugim = null;
        List<rishum_to_lesson> listrushum = null;
        public schdule_studio()
        {
            this.InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(enter_private));
        }

        private void CalendarViewDayItem_Tapped_1(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private async void Page_Loading(FrameworkElement sender, object args)
        {
            listrushum = await client.GetAlrishumAsync();
            lichugim = await client.GetAllChugimAsync();
            if (ClassUser.uesr != null)
            {

                lvcc.ItemsSource = lichugim.Where(x => x.day_lesson == "ראשון" && x.kod_category.kod_category == ClassUser.uesr.kod_category.kod_category);
                lvcc1.ItemsSource =lichugim.Where(x => x.day_lesson == "שני" && x.kod_category.kod_category == ClassUser.uesr.kod_category.kod_category);
                lvcc2.ItemsSource =lichugim.Where(x => x.day_lesson == "שלישי" && x.kod_category.kod_category == ClassUser.uesr.kod_category.kod_category);
                lvcc3.ItemsSource =lichugim.Where(x => x.day_lesson == "רביעי" && x.kod_category.kod_category == ClassUser.uesr.kod_category.kod_category);
                lvcc4.ItemsSource =lichugim.Where(x => x.day_lesson == "חמישי" && x.kod_category.kod_category == ClassUser.uesr.kod_category.kod_category);
            }
            else
            {
                lvcc.ItemsSource = lichugim.Where(x => x.day_lesson == "ראשון");
                lvcc1.ItemsSource =lichugim.Where(x => x.day_lesson == "שני");
                lvcc2.ItemsSource =lichugim.Where(x => x.day_lesson == "שלישי");
                lvcc3.ItemsSource =lichugim.Where(x => x.day_lesson == "רביעי");
                lvcc4.ItemsSource =lichugim.Where(x => x.day_lesson == "חמישי");
            }
        }

        private async void lvccm_Click(object sender, RoutedEventArgs e)
        {
            if (ClassUser.mone > 0)
            {
                rishum_to_lesson r = new rishum_to_lesson();
                r.kod_manui = ClassUser.manuy;
                r.kod_lesson = (Chugim)(lvcc.SelectedItem);
                r.date_rishum = DateTime.Today.Date;
                r.is_mustPay = false;
                r.is_perfumence = false;
                int h = await client.AddlesontomanuiAsync(r);
                if (h > 1)
                    txtim.IsOpen = true;
                else
                    donttxtim.IsOpen = true;
                    
            }
                
        }

        private void lvccm_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void lvccm_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void lvccm_Click_3(object sender, RoutedEventArgs e)
        {

        }

        private void lvccm_Click_4(object sender, RoutedEventArgs e)
        {

        }

        private void clos(object sender, RoutedEventArgs e)
        {
            txtim.IsOpen = false;
            donttxtim.IsOpen = false;
        }
    }
}

