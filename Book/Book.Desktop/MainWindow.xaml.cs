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

namespace Book.Desktop
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            BookChooseComboBox.ItemsSource = new ComBooks().Getbooks();
        }

      
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Zapisano pomyślnie");

        }

        private void DownloadButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BookChooseComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Choose1ComboBox.ItemsSource = ((Ibook)BookChooseComboBox.SelectedItem).Dane;
            Choose2ComboBox.ItemsSource = ((Ibook)BookChooseComboBox.SelectedItem).Dane;
            Choose3ComboBox.ItemsSource = ((Ibook)BookChooseComboBox.SelectedItem).Dane;
        }
    }
}
