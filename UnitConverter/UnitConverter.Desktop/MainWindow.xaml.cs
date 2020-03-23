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
using UnitConverter.Logic;

namespace UnitConverter.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            c1.ItemsSource = new ConverterService().GetConverters();
        }

        private void c1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            c2.ItemsSource = ((IConverter)c1.SelectedItem).Units;
            c3.ItemsSource = ((IConverter)c1.SelectedItem).Units;
        }

        private void but_Click(object sender, RoutedEventArgs e)
        {
            block.Text = (((IConverter)c1.SelectedItem).Convert(c2.Text, c3.Text, double.Parse((box.Text)))).ToString();
        }
    }
}
