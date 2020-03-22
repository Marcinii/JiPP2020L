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
using Konwerter_ver01;


namespace Konwerter_ver01.Desktop
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            WybKon.ItemsSource = new ZestawKonw().GetConverter();

            /* JednZtemp.ItemsSource = new Konwerter_ver01.ConTemp().Jedn;
             JednDotemp.ItemsSource = new Konwerter_ver01.ConTemp().Jedn;
             JednZodl.ItemsSource = new Konwerter_ver01.ConOdl().Jedn;
             JednDoodl.ItemsSource = new Konwerter_ver01.ConOdl().Jedn;
             JednZwag.ItemsSource = new Konwerter_ver01.ConWag().Jedn;
             JednDowag.ItemsSource = new Konwerter_ver01.ConWag().Jedn;
             JednZspe.ItemsSource = new Konwerter_ver01.ConSpe().Jedn;
             JednDospe.ItemsSource = new Konwerter_ver01.ConSpe().Jedn;
             */
        }

        private void WybKon_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            JednZ.ItemsSource = ((IConverter)WybKon.SelectedItem).Jedn;
            JednDo.ItemsSource = ((IConverter)WybKon.SelectedItem).Jedn;
        }

        private void Wykonajtemp_Click(object sender, RoutedEventArgs e)
        {
            string inputDane = Dane.Text;
            double inputValue;
            double.TryParse(inputDane, out inputValue);
            double result = ((IConverter)WybKon.SelectedItem).Convert(JednZ.SelectedItem.ToString(), JednDo.SelectedItem.ToString(), inputValue);

            Wynik.Text = result.ToString();
        }



        /*private void Wykonajtemp_Click(object sender, RoutedEventArgs e)
        {
            string inputTemp = Danetemp.Text;
            double inputValue;
            double.TryParse(inputTemp, out inputValue);
           // double result = ((IConverter)ConTemp).Convert(JednZtemp.SelectedItem.ToString(), JednDotemp.SelectedItem.ToString(), inputValue);

            //Wyniktemp.Text = result.ToString();
        }*/


    }
}

