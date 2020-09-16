using Ksiegarnia.Logic;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Ksiegarnia
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void LoadFromDatabaseButton_Click(object sender, RoutedEventArgs e)
        {
            LoadingPanel.Start();
            switch (ItemSelction.Text)
            {
                case "Book":
                    await Task.Delay(2000);
                    await Task.Run(() =>
                    {
                        Dispatcher.Invoke(() =>
                        {
                            ItemsGrid.ItemsSource = DatabaseIO.GetBooks();
                        });                       
                    });
                    break;
                case "Magazine":
                    await Task.Delay(2000);
                    await Task.Run(() =>
                    {
                        Dispatcher.Invoke(() =>
                        {
                            ItemsGrid.ItemsSource = DatabaseIO.GetMagazines();
                        });
                    });
                    break;
            }
            LoadingPanel.Stop();
        }

        private void SellCountTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!int.TryParse(e.Text, out _))
                e.Handled = true;
        }

        private void InsertNewButton_Click(object sender, RoutedEventArgs e)
        {
            AddButton.IsEnabled = true;
            switch (ItemSelction.Text)
            {
                case "Book":
                    ItemsGrid.ItemsSource = new List<Book>();
                    break;
                case "Magazine":
                    ItemsGrid.ItemsSource = new List<Book>();
                    break;
            }
            
        }

        private async void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddButton.IsEnabled = false;
            await Task.Delay(2000);
            await (ItemsGrid.SelectedItem as IBookstoreItem).Save();           
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            (ItemsGrid.SelectedItem as IBookstoreItem).Edit();
        }
    }
}
