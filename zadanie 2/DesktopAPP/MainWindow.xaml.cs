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
using przelicznik;
using przelicznik.Logic;

namespace DesktopAPP
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            convCombobox.ItemsSource = new KonwerterService().GetConverters();         
        }

        private void convCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            unitFrombox.ItemsSource = ((IConverter)convCombobox.SelectedItem).Units;
            unitTobox.ItemsSource = ((IConverter)convCombobox.SelectedItem).Units;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string inputText = inputTextBox.Text;
            decimal inputValue = decimal.Parse(inputText); 
            decimal result = ((IConverter)convCombobox.SelectedItem).Convert(
                unitFrombox.SelectedItem.ToString(),
                unitTobox.SelectedItem.ToString(),
                inputValue);

            outputText.Text = result.ToString();
        }

        private void inputTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void unitFrombox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}

