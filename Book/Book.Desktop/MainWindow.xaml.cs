using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Book;
using Book.Desktop;

namespace Book.Desktop
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            BookChooseComboBox.ItemsSource = new ComBooks().Getbooks();
            //TelefonTextBox.Text = null;
            //EmailTextBox.Text = null;
            //Choose1TextBox.Text = null;
            //Choose2TextBox.Text = null;
            //Choose3TextBox.Text = null;
            //Choose1ComboBox.ItemsSource = null;
            //Choose2ComboBox.ItemsSource = null;
            //Choose3ComboBox.ItemsSource = null;
            SaveCommand = new RelayCommand(obj => Save(), obj => BookChooseComboBox.SelectedItem != null && string.IsNullOrEmpty(NazwiskoTextBox.Text) != true && string.IsNullOrEmpty(ImieTextBox.Text) != true);
            SaveButton.Command = SaveCommand;

            DownloadCommand = new RelayCommand(obj => Download(), obj => string.IsNullOrEmpty(GiveNazwiskoTextBox.Text) != true);
            DownloadButton.Command = DownloadCommand;
           
        }

        private RelayCommand SaveCommand;
        private void Save()
        {
            WstawRekordDoBazy();
            MessageBox.Show("Zapisano pomyślnie");
            czysc();
        }

        private RelayCommand DownloadCommand;
        private void Download()
        {
            tokenSource = new CancellationTokenSource();
            Overlay.Visibility = Visibility.Visible;
            WaitPoint.Visibility = Visibility.Visible;
            ((Storyboard)Resources["StoryboardProgres"]).Begin();

            Task t1 = new Task(() => DownloadDate());
            t1.Start();
            Task t2 = new Task(() => Anulacja(tokenSource.Token), tokenSource.Token);
            t2.Start();

            Task.WhenAll(t1, t2).ContinueWith(t =>
            {
                Overlay.Visibility = Visibility.Hidden;
                WaitPoint.Visibility = Visibility.Hidden;
                ((Storyboard)Resources["StoryboardProgres"]).Stop();
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }
        private void DownloadDate()
        {
            using (PhoneBookDataModel context = new PhoneBookDataModel())
            {
                Task.Delay(3000).Wait();
                Dispatcher.Invoke(() =>
                {
                    List<BasBook> konstat = context.BasBookMy.Where(k => k.Nazwisko == GiveNazwiskoTextBox.Text).ToList();
                    {
                        Wynik.ItemsSource = konstat;
                        Wynik.Columns[0].Visibility = Visibility.Hidden;
                       // var selectedWynik = Wynik.SelectedCells;
                      //  NazwiskoTextBoxWynik.Text = selectedWynik.;

                    }
                });
            }
        }
       
        //private void Wynik_CellMouseClick (Oject sender, Data)

    
        private void Anulacja(CancellationToken ct)
        {
            for (int i = 0; i < 20; i++)
            {
                if (ct.IsCancellationRequested)
                {
                    ct.ThrowIfCancellationRequested();
                }
                Thread.Sleep(500);
            }
        }
        CancellationTokenSource tokenSource;
        

        private void AnulujButton_Click(object sender, RoutedEventArgs e)
        {
            tokenSource.Cancel();
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
                string tmp1 = "";
                if (Choose1ComboBox.SelectedItem == null) { tmp1 = ""; }
                else { tmp1 = Choose1ComboBox.SelectedItem.ToString(); }
                string tmp2 = "";
                if (Choose1TextBox.Text == null) { tmp2 = ""; }
                else { tmp2 = Choose1TextBox.Text; }
                string tmp3 = "";
                if (Choose2ComboBox.SelectedItem == null) { tmp3 = ""; }
                else { tmp3 = Choose2ComboBox.SelectedItem.ToString(); }
                string tmp4 = "";
                if (Choose2TextBox.Text == null) { tmp4 = ""; }
                else { tmp4 = Choose2TextBox.Text; }
                string tmp5 = "";
                if (Choose3ComboBox.SelectedItem == null) { tmp5 = ""; }
                else { tmp5 = Choose3ComboBox.SelectedItem.ToString(); }
                string tmp6 = "";
                if (Choose3TextBox.Text == null) { tmp6 = ""; }
                else { tmp5 = Choose3TextBox.Text; }
                BasBook NowyRekord = new BasBook()
                {
                    Typ = ((Ibook)BookChooseComboBox.SelectedItem).Nazwa.ToString(),
                    Nazwisko = NazwiskoTextBox.Text,
                    Imie = ImieTextBox.Text,
                    Nr_telefonu = TelefonTextBox.Text,
                    Email = EmailTextBox.Text,
                    _1 = tmp1,
                    _1_ = tmp2,
                    _2 = tmp3,
                    _2_ = tmp4,
                    _3 = tmp5,
                    _3_ = tmp6
                };

                context.BasBookMy.Add(NowyRekord);
                context.SaveChanges();
            }
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            czysc();
        }

        private void Wynik_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var selectedWynik = Wynik.SelectedCells;
            NazwiskoTextBoxWynik.Text = selectedWynik.ToString();
        }
        private void czysc()
        {
            GiveNazwiskoTextBox.Text = String.Empty;
            NazwiskoTextBox.Text = ImieTextBox.Text = String.Empty;
            TelefonTextBox.Text = String.Empty;
            EmailTextBox.Text = String.Empty;
            Choose1TextBox.Text = String.Empty;
            Choose2TextBox.Text = String.Empty;
            Choose3TextBox.Text = String.Empty;
            Choose1ComboBox.ItemsSource = null;
            Choose2ComboBox.ItemsSource = null;
            Choose3ComboBox.ItemsSource = null;
        }

        private void ClearDataButton_Click(object sender, RoutedEventArgs e)
        {
            Wynik.Columns.Clear();
        }
    }

        
}
