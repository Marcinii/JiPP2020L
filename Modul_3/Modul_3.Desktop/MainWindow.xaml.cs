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
namespace Modul_3.Desktop
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        List<Ikonwerter> konwertetr = new List<Ikonwerter>(){
             new Temperatura(),
             new Dlugosc(),
            new Waga(),
             new Czas(),
             new Hour()

        };
        public MainWindow()
        {
            InitializeComponent();
            converterCombobox.ItemsSource = new ConverterService().GetConverter();

            Storyboard seconds = (Storyboard)second.FindResource("stsecunda");
            seconds.Begin();
            seconds.Seek(new TimeSpan(0, 0, 0, DateTime.Now.Second, 0));

            Storyboard minutes = (Storyboard)minute.FindResource("sbminuty");
            minutes.Begin();
            minutes.Seek(new TimeSpan(0, 0, DateTime.Now.Minute, DateTime.Now.Second, 0));

            Storyboard hours = (Storyboard)hour2.FindResource("sbhour");
            hours.Begin();
            hours.Seek(new TimeSpan(0, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, 0));

            using (JIPPEntities context = new JIPPEntities())
            {
                List<Ocena> ocenas = context.Ocenas
                    .OrderByDescending(e => e.ID)
                    .ToList();
                rateControl.RateValue=ocenas[0].Oceny;
             
            }

                rateControl.RataVAlueChange += RateControl_RataVAlueChange;

            ConvertCommand = new RelayCommand(obj => Convert(), obj =>
                converterCombobox.SelectedItem != null && ListaJednostek.SelectedItem != null &&
                string.IsNullOrEmpty(inputTextBox.Text) != true);
            convertButton.Command = ConvertCommand;


        }

        private void RateControl_RataVAlueChange(int value)
        {
            DBOcena dodaj = new DBOcena();
            dodaj.dodac2(rateControl.RateValue);
        }
        private void Temp_Click_1(object sender, RoutedEventArgs e)
        {
            Temperatura temp = new Temperatura();
            ListaJednostek.ItemsSource = temp.Unit;
            converterCombobox.SelectedIndex = 1;

        }

        private void Waga_Click(object sender, RoutedEventArgs e)
        {
            Waga wight = new Waga();
            ListaJednostek.ItemsSource = wight.Unit;
            converterCombobox.SelectedIndex = 3;
        }

        private void Lenght_Click(object sender, RoutedEventArgs e)
        {
            Dlugosc lenght = new Dlugosc();
            ListaJednostek.ItemsSource = lenght.Unit;
            converterCombobox.SelectedIndex = 0;
        }

        private void BtTime_Click(object sender, RoutedEventArgs e)
        {
            Czas time = new Czas();
            ListaJednostek.ItemsSource = time.Unit;
            converterCombobox.SelectedIndex = 2;

        }
        private void Zamia_Click(object sender, RoutedEventArgs e)
        {
            Hour abcd = new Hour();
            ListaJednostek.ItemsSource = abcd.Unit;
            converterCombobox.SelectedIndex = 4;

        }

        private RelayCommand ConvertCommand;

        private void Convert()
        {
            string inputText = inputTextBox.Text;

            string[] foo = inputText.Split(new char[] { ':' });
            inputText = foo[0];
            double.TryParse(inputText, out double inputValue);

            double result = ((Ikonwerter)converterCombobox.SelectedItem).Zamiana(
                inputValue, ListaJednostek.SelectedIndex + 1);

            if (converterCombobox.SelectedIndex == 4)
            {
                if (foo[0] != result.ToString()) outputTextBlock.Text = (result.ToString() + ":" + foo[1] + "PM");
                else outputTextBlock.Text = (result.ToString() + ":" + foo[1] + "AM");
                clockmin.Angle = int.Parse(foo[1]) * 6;
                clockhour.Angle = result * 30 + (int.Parse(foo[1]) / 2);

            }
            else outputTextBlock.Text = result.ToString();
            DBDodaj dodaj = new DBDodaj();

            dodaj.dodac(((Ikonwerter)converterCombobox.SelectedItem).nazwa, ListaJednostek.SelectedItem.ToString(), (decimal)inputValue, (decimal)result);

        }
        private void converterCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListaJednostek.ItemsSource = ((Ikonwerter)converterCombobox.SelectedItem).Unit;
            if (converterCombobox.SelectedIndex == 4) { ((Storyboard)Resources["Storyboard2"]).Begin(); }
        }

        private void ListaJednostek_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


        }

        private void Statystki_Click(object sender, RoutedEventArgs e)
        {
            Window1 nwd = new Window1();
            nwd.Show();
        }
      
    }
}
