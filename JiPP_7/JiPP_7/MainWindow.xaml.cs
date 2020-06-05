using System;
using Logika;
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
using System.Threading;

namespace JiPP_7
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
        void zamk()
        {
            GOceny.Visibility = Visibility.Hidden;
            Gprzedmioty.Visibility = Visibility.Hidden;
            GStatystyki.Visibility = Visibility.Hidden;
            GPlan.Visibility = Visibility.Hidden;
            GHome.Visibility = Visibility.Hidden;
        }
        private void ConvertButton_Oceny(object sender, RoutedEventArgs e)
        {
            zamk();
            GOceny.Visibility = Visibility.Visible;
            using (DziennikEntities context = new DziennikEntities())
            {
                List<Przedmioty> przedmioties = context.Przedmioty.ToList();
                dbprzedmioty.ItemsSource = przedmioties;
                ListaPrzedmiotow.ItemsSource = przedmioties;
            }
        }
        private void ConvertButton_Przedmioty(object sender, RoutedEventArgs e)
        {
            zamk();
            Gprzedmioty.Visibility = Visibility.Visible;
            using (DziennikEntities context = new DziennikEntities())
            {
                List<Przedmioty> przedmioties = context.Przedmioty.ToList();
                dbprzedmioty.ItemsSource = przedmioties;
                ListaPrzedmiotow.ItemsSource = przedmioties;
            }
        }

        private void BPlan_Click(object sender, RoutedEventArgs e)
        {
            zamk();
            GPlan.Visibility = Visibility.Visible;
        }
        private void Home_Click(object sender, RoutedEventArgs e)
        {
            zamk();
            GHome.Visibility = Visibility.Visible;
        }
        private void Bstatystyki_Click(object sender, RoutedEventArgs e)
        {
            zamk();
     
            Thread thread = new Thread(() => ladowanie());
            thread.Start();
            Thread.Sleep(5000);
            GStatystyki.Visibility = Visibility.Visible;
        }
        void ladowanie()
        {
            using (DziennikEntities contex = new DziennikEntities())
            {
                List<Uczen> uczens = contex.Uczen.ToList();
                Dispatcher.Invoke(()=>DStatystyki.ItemsSource = uczens);
            }
            using (DziennikEntities contex = new DziennikEntities())
            {
                List<Uczen> uczens = contex.Uczen.
                    OrderByDescending(a => a.ID)
                    .Take(3)
                    .ToList();
                Dispatcher.Invoke(()=> DStatystyki3.ItemsSource = uczens);
            }
            using (DziennikEntities context = new DziennikEntities())
            {
                List<Przedmioty> przedmioties = context.Przedmioty.ToList();
                Dispatcher.Invoke(()=>StatystykaComboBox.ItemsSource = przedmioties);

            }
           
         
        }



        private void Buttonprzedmiot_Click(object sender, RoutedEventArgs e)
        {
            using (DziennikEntities context = new DziennikEntities())
            {
                Przedmioty newprzed = new Przedmioty()
                {
                    Przedmiot = TextPrzedmiot.Text
                };
                context.Przedmioty.Add(newprzed);
                context.SaveChanges();
            }
            using (DziennikEntities context = new DziennikEntities())
            {
                List<Przedmioty> przedmioties = context.Przedmioty.ToList();
                dbprzedmioty.ItemsSource = przedmioties;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int.TryParse(Jakaocena.Text, out int abc);
            string a = ((Przedmioty)ListaPrzedmiotow.SelectedItem).Przedmiot;

            Daj LED = new Daj();
            LED.dodaj(a, abc);
           
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            using (DziennikEntities contex = new DziennikEntities())
            {
                List<Uczen> uczens = contex.Uczen.
                    Where(a=>a.Przedmiot== ((Przedmioty)StatystykaComboBox.SelectedItem).Przedmiot)
                    .ToList();
                DStatystyki.ItemsSource = uczens;
            }
        }
    }
}
