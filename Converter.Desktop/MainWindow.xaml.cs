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

namespace Converter.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Category.ItemsSource= new List<IConverter>()
            {
                new Temperatura(),
                new Dystans(),
                new Masa(),
                new Powierzchnia()
            };
        }

        private void selectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UnitFrom.ItemsSource = ((IConverter)Category.SelectedItem).Units;
            UnitTo.ItemsSource = ((IConverter)Category.SelectedItem).Units;
        }

        private void Convert(object sender, RoutedEventArgs e)
        {
            double.TryParse(Toconvert.Text, out double value);
            Converted.Content = ((IConverter)Category.SelectedItem).convert(value, UnitFrom.Text, UnitTo.Text);
        }
    }
}
