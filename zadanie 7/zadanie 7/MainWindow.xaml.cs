using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media.Animation;
using Microsoft.VisualBasic;
using System.Threading;

namespace zadanie_7
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void dodanie_kompa()
        {
            string nazwakompa = text_komp.Text;
            string numerkompa= text_numer.Text;


            DateTime TimeNow = DateTime.Now;
            using (zad7Entities context = new zad7Entities())
            {
                komputer newzad7 = new komputer()
                {
                    nazwa_komputera = nazwakompa,
                    numer_seryjny = numerkompa,
                    data = TimeNow,

                };
                context.komputer.Add(newzad7);
                context.SaveChanges();
            }
         }

        public void wyswietlanie_danych()
        {

            using (zad7Entities context = new zad7Entities())
            {
                List<komputer> komputer = context.komputer
                    .OrderBy(b => b.idkompa)
                    .ToList();


                Thread.Sleep(5000);
                Dispatcher.Invoke(() => 
                {
                    wybor.ItemsSource = komputer;
                    loadscreen.Visibility = Visibility.Hidden;
                });
            }

        }

            private void dodanie_baza_Click(object sender, RoutedEventArgs e)
        {
            dodanie_kompa();
        }

        private void wczytanie_baza_Click(object sender, RoutedEventArgs e)
        {
            loadscreen.Visibility = Visibility.Visible;
            Thread thread = new Thread(() => wyswietlanie_danych());
            thread.Start();
            ((Storyboard)Resources["spinwait"]).Begin();
        
        }



        
    }
}
