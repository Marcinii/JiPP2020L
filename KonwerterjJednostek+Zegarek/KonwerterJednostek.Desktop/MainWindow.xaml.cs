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
using KonwerterJednostek2.Logic;




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
        }

        private void button_action_Click(object sender, RoutedEventArgs e)
        {
            
            ((StoryBoard).Resources["KoloStory"]).Begin();
            

            string tekst_wejsciowy = textbox_input.Text;
            double wartosc_wejsciowa = double.Parse(tekst_wejsciowy);
            double wynik=0;

            

            wynik = ((IKonwerter)combobox_Rodzaj_konwersji.SelectedItem).Konwerter(combobox_Jednostka_bazowa.SelectedItem.ToString(), combobox_Jednostka_wynikowa.SelectedItem.ToString(), wartosc_wejsciowa);

            textbox_wynik.Text = wynik.ToString();
        }
    }
}
