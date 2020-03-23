using Konwerter_jednostek_wersja2;
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


namespace Konwerterjednostek.Pulpit
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Konwerter_ComboBox.ItemsSource = new List<Ikonwenter>()
            {
                new KonwerterCali(),
                new KonwerterCelcjusza(),
                new KonwerterCzasu(),
                new KonwerterFahrenheita(),
                new KonwerterFuntow(),
                new KonwerterKilkometrow(),
                new KonwerterKilogramow(),
                new KonwerterMil()
            };
            wskazowka.Angle = 100;
        }

        private void Konwerter_ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            unitFrom_comboBox.ItemsSource = ((Ikonwenter)Konwerter_ComboBox.SelectedItem).Units;
            unitTo_comboBox.ItemsSource = ((Ikonwenter)Konwerter_ComboBox.SelectedItem).Units;
        }

        private void wykonaj_Button_Click(object sender, RoutedEventArgs e)
        {
            string inputText = input_TexBox.Text;

            string inputValue = inputText ;

            string result =((Ikonwenter)Konwerter_ComboBox.SelectedItem).Convert(
                 unitFrom_comboBox.SelectedItem.ToString(),
                 unitTo_comboBox.SelectedItem.ToString(),
                inputValue.ToString());
            output_TextBlock.Text = result.ToString();



        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ((Storyboard)Resources ["koloStoryboard"]).Begin();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ((Storyboard)Resources["koloStoryboard"]).Stop();
        }
    }
}
