using KonwerterJednostek.Logic;
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

            dziedzinaCombo.ItemsSource = new KonwerterService().GetConverters();
        }

        private void dziedzinaCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            jednFromCombo.ItemsSource = ((IConverter)dziedzinaCombo.SelectedItem).Units;
            jednToCombo.ItemsSource = ((IConverter)dziedzinaCombo.SelectedItem).Units;
        }

        private void jednToCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)    
        //private void Guzik_Click(object sender, RoutedEventArgs e)
        {
            string wartoscText = wartoscBox.Text;
            decimal wartoscValue = decimal.Parse(wartoscText);

            string x = jednFromCombo.SelectedItem.ToString();

            decimal result = ((IConverter)dziedzinaCombo.SelectedItem).Convert(
                jednFromCombo.SelectedItem.ToString(), jednToCombo.SelectedItem.ToString(), wartoscValue);
            
            wynikBlock.Text = result.ToString();
        }
    }
}
