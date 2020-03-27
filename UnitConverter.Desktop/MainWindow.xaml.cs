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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
namespace UnitConverter.Desktop
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
           
            KonwerterComboBox.ItemsSource = new List<IKonwerter>()
            {
                new Temperatura(),
                new Odleglosc(),
                new Masa(),
                new Energia(),
                new Czas()
            };
            clockRotation1.Angle = 0;
        }

        private void KonwerterComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ZComboBox.ItemsSource = ((IKonwerter)KonwerterComboBox.SelectedItem).Unit;
            DoComboBox.ItemsSource = ((IKonwerter)KonwerterComboBox.SelectedItem).Unit;
        }

        private void actionButton_Click(object sender, RoutedEventArgs e)
        {
            

            string inputText = WartoscTextBox.Text;

            string wynik = ((IKonwerter)KonwerterComboBox.SelectedItem).Konwert(
                ZComboBox.SelectedItem.ToString(),
                DoComboBox.SelectedItem.ToString(),
                inputText);

            WynikTextBlock.Text = wynik.ToString();

            if (Convert.ToString(ZComboBox.SelectedItem) == "24h")
            {
                double hour, minutes, h, min;

                int index = wynik.IndexOf(":");
                if (index == 1)
                {
                    h = Convert.ToDouble(wynik.Substring(0, 1));
                    min = Convert.ToDouble(wynik.Substring(2, 2));
                }
                else
                {
                    h = Convert.ToDouble(wynik.Substring(0, 2));
                    min = Convert.ToDouble(wynik.Substring(3, 2));
                }
                hour = h * 30 + 90;
                minutes = min * 6 + 90;

                clockRotation1.Angle = hour;
                clockRotation2.Angle = minutes;
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            ((Storyboard)Resources["Storyboard1"]).Begin();
        }
    }
}
