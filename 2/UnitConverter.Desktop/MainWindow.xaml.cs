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
using UnitConverter;

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
           Unit.ItemsSource = new List<>()
            {
                new TemperatureConverter(),
                new LenghtConverter(),
                new WeightConverter(),
            };
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            string inputValue = Input.Text;
            Answer.Text = inputValue;
        }

        private void Unit_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
    }
}
