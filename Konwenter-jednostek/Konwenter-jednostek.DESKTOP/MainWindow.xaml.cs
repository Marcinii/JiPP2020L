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
using System.Diagnostics;
using System.Windows.Media.Animation;
using System.Threading;

namespace Konwenter_jednostek.DESKTOP
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            konwenterComboBox.ItemsSource = new List<IKonwenter>()
            {
                new konwenter_dlugosci(),
                new konwenter_temperatury(),
                new konwenter_masy(),
                new konwenter_cisnienia(),
                new konwenter_czasu()
            };
           
        filtrComboBox.ItemsSource = konwenterComboBox.ItemsSource;
       
           
        }

        private void ZmienGodzineNaZegarze(double godziny)
            {
                RotateTransform transformacjaGodzin = new RotateTransform
                {
                    CenterX = 100,
                    CenterY = 100,
                    Angle = godziny / 12 * 360
                };

                RotateTransform transformacjaMinut = new RotateTransform
                {
                    CenterX = 100,
                    CenterY = 100,
                    Angle = (double.Parse(czas_minutyTextBox.Text) / 60) * 360
                };

                Godzina.RenderTransform = transformacjaGodzin;
                Minuta.RenderTransform = transformacjaMinut;

            }

        private void czasTextBox_TextChanged(object sender, TextChangedEventArgs e) { }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ((Storyboard)Resources["Storyboard1"]).Begin();
            ((Storyboard)Resources["Storyboard2"]).Begin();
        }
        bool on = true;
        private void button2_Click(object sender, RoutedEventArgs e)
            {
                
                if (on)
                {
                    ((Storyboard)Resources["Storyboard3"]).Begin();
                    showTextBlock.Text = "OFF";
                    showTextBlock.Background = Brushes.Red;
                    on = false;
                }
                else
                {
                    ((Storyboard)Resources["Storyboard3"]).Stop();
                    showTextBlock.Text = "ON";
                    showTextBlock.Background = Brushes.Green;
                    on = true;
                }

            }

        public  void DisplayDataEF()
            {
                using(konwenterBazaEntities context = new konwenterBazaEntities())
                {
                List<dane> dane_wszystkie = context.dane.ToList();
                daneDataGrid.ItemsSource = dane_wszystkie;
                daneDataGrid.ItemsSource = dane_wszystkie.OrderByDescending(el => el.id);

                }

            }

        public void DisplayDataEF11()
        {

            string rodzaj = filtrComboBox.SelectedItem.ToString();


            using (konwenterBazaEntities context = new konwenterBazaEntities())
            {
                List<dane> dane_wszystkie = context.dane.ToList();

                daneDataGrid.ItemsSource = dane_wszystkie.Where(el => el.rodzaj == rodzaj.Remove(0, 30))
                                                         .OrderByDescending(el => el.id)
                                                         .Take(20)
                                                         .Where(el => (el.data_konwersji > Data1.SelectedDate) && (el.data_konwersji < Data2.SelectedDate));
            }
        }
            
        private void InsertDataEF()
            {
                string rodzaj1 = konwenterComboBox.Text.ToString();
                DateTime thisDay = DateTime.Today;

            using (konwenterBazaEntities context = new konwenterBazaEntities())
                {
                    dane newdane = new dane()
                    {
                        rodzaj = rodzaj1.Remove(0, 30),
                        jednostki = zComboBox.Text.ToString() + " " + "na" + " " + dooComboBox.Text.ToString(),
                        data_konwersji = thisDay,
                        wartosc_konwertowana = double.Parse(wpiszTextBox.Text),
                        wartosc_przekonwertowana = double.Parse(wyswietlTextBlock.Text)
                   };
                    context.dane.Add(newdane);
                    context.SaveChanges();
                }
            }

        private void konwenterComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            zComboBox.ItemsSource = ((IKonwenter)konwenterComboBox.SelectedItem).Jednostki;
            dooComboBox.ItemsSource = ((IKonwenter)konwenterComboBox.SelectedItem).Jednostki;
        }

        private void konwertujButton_Click(object sender, RoutedEventArgs e)
        {
            
            string inputText = wpiszTextBox.Text;
            string inputCzas = czasTextBox.Text;
            double inputValueCzas = double.Parse(inputCzas);
            double inputValue = double.Parse(inputText);

            if (konwenterComboBox.SelectedItem.ToString() == "Konwenter_jednostek.konwenter_czasu")
            {
               
                double result = ((IKonwenter)konwenterComboBox.SelectedItem).Konwertuj(zComboBox.SelectedItem.ToString(), dooComboBox.SelectedItem.ToString(), inputValueCzas);
                konwersja_czasu();

                wpiszTextBox.Text = inputCzas;
                wyswietlTextBlock.Text = result.ToString();
            }
            else
            {

                double result = ((IKonwenter)konwenterComboBox.SelectedItem).Konwertuj(zComboBox.SelectedItem.ToString(), dooComboBox.SelectedItem.ToString(), inputValue);
                wyswietlTextBlock.Text = result.ToString();



            }
            
            zTextBlock.Text = zComboBox.Text.ToString();
            dooTextBlock1.Text = dooComboBox.Text.ToString();
            InsertDataEF();
        }

        private void konwersja_czasu()
            {
            

            if (int.Parse(czasTextBox.Text) < 12)
                {
                    dooTextBlock1.Text = "PM";
                    zTextBlock.Text = "AM";
                }
                else
                {
                    dooTextBlock1.Text = "AM";
                    zTextBlock.Text = "PM";
                }
                ZmienGodzineNaZegarze(double.Parse(czasTextBox.Text));
            }

        public void testButton_Click(object sender, RoutedEventArgs e)
        {
            DisplayDataEF();
        }

        private void filtrComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DisplayDataEF11();
        }

        private void Data1Button_Click(object sender, RoutedEventArgs e)
        {
            if (Data1.Visibility == Visibility.Hidden) Data1.Visibility = Visibility.Visible;
            else Data1.Visibility = Visibility.Hidden;
        }
        
        private void Data2Button_Click(object sender, RoutedEventArgs e)
        {
            if (Data2.Visibility == Visibility.Hidden) Data2.Visibility = Visibility.Visible;
            else Data2.Visibility = Visibility.Hidden;
        }

        

       
    }
}







           
    
    

