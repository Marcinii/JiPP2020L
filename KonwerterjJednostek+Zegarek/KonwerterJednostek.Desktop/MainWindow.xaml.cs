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
using KonwerterjJednostek2;
using KonwerterjJednostek2.Logic;






namespace KonwerterJednostek.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            combobox_Rodzaj_konwersji.ItemsSource = new KonwerterSerwis().GetKonwerters();
        }

        private void combobox_Rodzaj_konwersji_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            combobox_Jednostka_bazowa.ItemsSource = ((IKonwerter)combobox_Rodzaj_konwersji.SelectedItem).Units;
            combobox_Jednostka_wynikowa.ItemsSource = ((IKonwerter)combobox_Rodzaj_konwersji.SelectedItem).Units;


            if (combobox_Rodzaj_konwersji.SelectedItem.ToString() == "KonwerterjJednostek2.Format_12_24_class") { uwaga_format.Visibility = Visibility.Visible; }
            if (combobox_Rodzaj_konwersji.SelectedItem.ToString() != "KonwerterjJednostek2.Format_12_24_class") { uwaga_format.Visibility = Visibility.Hidden; }
        }

        private void button_action_Click(object sender, RoutedEventArgs e)
        {
            //((Storyboard) Resources["KoloStory2"]) to nie dziala
            


            string tekst_wejsciowy = textbox_input.Text;
            string costam = combobox_Rodzaj_konwersji.SelectedItem.ToString();

            if (combobox_Rodzaj_konwersji.SelectedItem.ToString() != "KonwerterjJednostek2.Format_12_24_class")
            {
                double wartosc_wejsciowa = double.Parse(tekst_wejsciowy);

                double wynik = 0;

                wynik = ((IKonwerter)combobox_Rodzaj_konwersji.SelectedItem).Konwerter(combobox_Jednostka_bazowa.SelectedItem.ToString(), combobox_Jednostka_wynikowa.SelectedItem.ToString(), wartosc_wejsciowa);
                textbox_wynik.Text = wynik.ToString();
            }


            if (combobox_Rodzaj_konwersji.SelectedItem.ToString() == "KonwerterjJednostek2.Format_12_24_class")
            {
                string wrocony_wynik;

                Format_12_24_class F1 = new Format_12_24_class();
                F1.Konwerter2(tekst_wejsciowy);


                wrocony_wynik = F1.Konwerter2(tekst_wejsciowy);
                textbox_wynik.Text = wrocony_wynik;

                double godzina_kat;
                double minuta_kat;
                godzina_kat = double.Parse(wrocony_wynik.Remove(2));



                string minuta_kat_tmp = wrocony_wynik.Remove(0, 3);


                minuta_kat = double.Parse(minuta_kat_tmp.Remove(2));

                godzinowa_rotacja.Angle = 0;
                minutowa_rotacja.Angle = 0;

                godzinowa_rotacja.Angle = ((godzina_kat+3)*30);
                minutowa_rotacja.Angle = (minuta_kat + 15) * 6;                
            }

            


        }
    }
}
