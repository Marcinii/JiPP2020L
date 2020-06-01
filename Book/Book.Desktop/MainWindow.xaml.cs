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
            WstawRekordDoBazy();
            MessageBox.Show("Zapisano pomyślnie");

        }

        private void DownloadButton_Click(object sender, RoutedEventArgs e)
        {
            using (PhoneBookDataModel context = new PhoneBookDataModel())
            {
                List<BasBook> konstat = context.BasBookMy.Where(k => k.Nazwisko == "Maliniak").ToList();
                foreach (BasBook k in konstat)
                {
                    Wynik.ItemsSource = konstat;
                }
            }
        }

        private void BookChooseComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Choose1ComboBox.ItemsSource = ((Ibook)BookChooseComboBox.SelectedItem).Dane;
            Choose2ComboBox.ItemsSource = ((Ibook)BookChooseComboBox.SelectedItem).Dane;
            Choose3ComboBox.ItemsSource = ((Ibook)BookChooseComboBox.SelectedItem).Dane;
        }
        private void WstawRekordDoBazy()
        {

            using (PhoneBookDataModel context = new PhoneBookDataModel())
            {
                BasBook NowyRekord = new BasBook()
                {
                    Typ = ((Ibook)BookChooseComboBox.SelectedItem).Nazwa.ToString(),
                    Nazwisko = NazwiskoTextBox.Text,
                    Imie = ImieTextBox.Text,
                    Nr_telefonu = TelefonTextBox.Text,
                    Email = EmailTextBox.Text,
                    Inne_1 = Choose1ComboBox.SelectedItem.ToString(),
                    Inne_1_Dane = Choose1TextBox.Text,
                    Inne_2 = Choose2ComboBox.SelectedItem.ToString(),
                    Inne_2_Dane = Choose2TextBox.Text,
                    Inne_3 = Choose3ComboBox.SelectedItem.ToString(),
                    Inne_3_Dane = Choose3TextBox.Text
                };

                context.BasBookMy.Add(NowyRekord);
                context.SaveChanges();
            }
        }
    }
}
