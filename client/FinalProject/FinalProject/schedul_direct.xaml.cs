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
    public sealed partial class schedul_direct : Page
    {
        Service1Client client = new Service1Client();
        List<Chugim> ChugimsList = null;
        List<typ_chugim> tchugimlist = null;
        List<category> catelist = null;
        List<gauides> gauidlist = null;
        List<city> cilit = null;

        public schedul_direct()
        {
            this.InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(enter_direct));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private async void Page_Loading(FrameworkElement sender, object args)
        {
            tchugimlist = await client.GetAllTyp_ChugimsAsync();
            enless.ItemsSource = tchugimlist;
            shewtypchugim.ItemsSource = tchugimlist;

            catelist = await client.GetAllcategoryAsync();
            encategor.ItemsSource = catelist;

            gauidlist = await client.GetAllGauidesAsync();
            engau.ItemsSource = gauidlist;

            cilit = await client.GetAllcityAsync();
            shewcity.ItemsSource = cilit;

            ChugimsList = await client.GetAllChugimAsync();

            if (ClassUser.uesr != null)
            {

                lvc.ItemsSource = ChugimsList.Where(x => x.day_lesson == "ראשון" && x.kod_category.kod_category == ClassUser.uesr.kod_category.kod_category);
              //  lvc.ItemsSource = ChugimsList.Where(x => x.day_lesson == "ראשון");
                lvc1.ItemsSource = ChugimsList.Where(x => x.day_lesson == "שני");
                lvc2.ItemsSource = ChugimsList.Where(x => x.day_lesson == "שלישי");
                lvc3.ItemsSource = ChugimsList.Where(x => x.day_lesson == "רביעי");
                lvc4.ItemsSource = ChugimsList.Where(x => x.day_lesson == "חמישי");
            }
            else
            {
                lvc.ItemsSource = ChugimsList.Where(x => x.day_lesson == "ראשון");
                lvc1.ItemsSource = ChugimsList.Where(x => x.day_lesson == "שני");
                lvc2.ItemsSource = ChugimsList.Where(x => x.day_lesson == "שלישי");
                lvc3.ItemsSource = ChugimsList.Where(x => x.day_lesson == "רביעי");
                lvc4.ItemsSource = ChugimsList.Where(x => x.day_lesson == "חמישי");
            }
        }


        private void typc_Click(object sender, RoutedEventArgs e)
        {
            changtypchugim.IsOpen = true;
            this.Opacity = 0.1;

        }

        private void lessn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void upless_Click(object sender, RoutedEventArgs e)
        {

        }

        private void deless_Click(object sender, RoutedEventArgs e)
        {

        }

        private void vocat_Click(object sender, RoutedEventArgs e)
        {

        }

        private void typmni_Click(object sender, RoutedEventArgs e)
        {
            popmanuy.IsOpen = true;
            this.Opacity = 0.1;
        }

        private void upcit_Click(object sender, RoutedEventArgs e)
        {
            changcity.IsOpen = true;
            this.Opacity = 0.1;
        }
        //x => x.first_date.Date<= DateTime.Today.Date
        private async void entypch_Click(object sender, RoutedEventArgs e)
        {
            typ_chugim t = new typ_chugim();
            if (legal.IsHebrew(entyp.Text))
            {
                var chec = await client.CheckchugifexcistAsync(entyp.Text);
                if(chec==true)
                {
                    txtname.Text = "החוג כבר קיים במערכת";
                }
                else
            {
                t.name_lesson = entyp.Text;
                t.kod_typLesson = await client.GetCodtotypchugimAsync();
                int x = await client.AddtypchugAsync(t);
                if (x > 0)
                {
                        txtname.Text = "הנתונים נשמרו בהצלחה";
                        clisch.Visibility = Visibility.Visible;
                   
                }
            }
            }
            else
                   clisch.Visibility = Visibility.Visible;
                   txtname.Text = "הנתונים לא נשמרו בדוק את תקינותם";
        }

        private void clisch_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(schedul_direct));
        }

        private async void encit_Click(object sender, RoutedEventArgs e)
        {
                city c = new city();
              if (legal.IsHebrew(encity.Text))
            {
                var chek = await client.CheckcityIfExistAsync(encity.Text);
                if(chek==true)
                {
                    txtnname.Text = "העיר כבר קיימת במערכת";
                }
                else
                { 
                c.kod_city = await client.GetCodtocityAsync();
                c.name_city = encity.Text;
                int x = await client.AddcityAsync(c);
                if(x>0)
                {
                    txtnname.Text = "הנתונים נשמרו בהצלחה";
                }

                }
            }
               else
                txtnname.Text = "הנתונים לא נשמרו בדוק את תקינותם";
        }

        private async void enmnuy_Click(object sender, RoutedEventArgs e)
        {
            typ_menuyim_price_ t = new typ_menuyim_price_();
            if(legal.IsNumber(prise.Text)&&legal.IsNumber(numonth.Text)&&legal.IsNumber(numewwk.Text))
            {

            }
        }

        private void clos(object sender, RoutedEventArgs e)
        {
            popcity.IsOpen = false;
            popmanuy.IsOpen = false;
            dontdelcity.IsOpen = false;
            this.Opacity = 1;
            dontdeltypchug.IsOpen = false;
            this.Opacity =1;
        }

        private async void dalete_Click(object sender, RoutedEventArgs e)
        {
            typ_chugim t = (typ_chugim)(shewtypchugim.SelectedItem);
            int f = await client.delatetypchugAsync(t);
            if (f > 0)
            {
                changtypchugim.IsOpen = false;
                this.Opacity = 0;
            }
            else
            {
                changtypchugim.IsOpen = false;
                dontdeltypchug.IsOpen = true;
            }
        }

        private void addtypchugim_Click(object sender, RoutedEventArgs e)
        {
            changtypchugim.IsOpen = false;
             poptypchug.IsOpen = true;
        }

        private void addcity_Click(object sender, RoutedEventArgs e)
        {
            popcity.IsOpen = true;
            changcity.IsOpen = false;
        }

        private async void daletecity_Click(object sender, RoutedEventArgs e)
        {
            city c = (city)(shewcity.SelectedItem);
            int f = await client.delatecieyAsync(c);
            if(f>0)
            {
                changcity.IsOpen = false;
            }
            else
            {
                changcity.IsOpen = false;
                dontdelcity.IsOpen = true;
            }
        }
    }
    }



