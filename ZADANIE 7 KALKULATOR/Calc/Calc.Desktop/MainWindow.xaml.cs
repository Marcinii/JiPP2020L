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
using Calc.Logic;

namespace Calc.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Calc.ItemsSource = new Dzialania().SelectPick();
        }

        private void Kalkulator_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void Oblicz_Click(object sender, RoutedEventArgs e)
        {
            string pierwszaWartosc = pierwsza.Text;
            double pierwszy = double.Parse(pierwszaWartosc); // !! TryParse

            string WpiszWynik = druga.Text;
            double drugi = double.Parse(WpiszWynik); // !! TryParse


            double wynik = ((IDzialanie)Kalkulator.SelectedItem).Oblicz(pierwszy, drugi);

            Wynik.Text = wynik.ToString();

            SaveLog((IDzialanie)Kalkulator.SelectedItem, pierwszy, drugi, wynik);

        }

        private void SaveLog(IDzialanie type, double firstValue, double secondValue, double valueAfter)
        {

            using (var db = new jippEntities())
            {
                var newItem = new HistoriaObliczen()
                {
                    Dzialanie = type.Nazwa,
                    PierwszaWartosc = firstValue.ToString(),
                    DrugaWartosc = secondValue.ToString(),
                    WartoscPo = valueAfter.ToString(),
                    Date = DateTime.Now
                };

                db.HistoriaObliczen.Add(newItem);

                db.SaveChanges();
            }
        }



        private void toggleHistoryButton_Click(object sender, RoutedEventArgs e)
        {
            hwindow.Show();
            hwindow.LoadHistory();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            hwindow.Close();
            Application.Current.Shutdown();
        }
    }
}