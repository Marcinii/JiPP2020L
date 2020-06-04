using System;
using System.Threading.Tasks;
using System.Windows;
using Sklep.Logika;
using System.Data.SqlClient;
using System.Data;
using System.Threading;

namespace Sklep.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Przychod = new RelayCommand(obj => ObliczPrzychod(), obj => !string.IsNullOrWhiteSpace(textboxNetto.Text)); 
            buttonKonwerujVAT.Command = Przychod;
            StatystykaData = new RelayCommand(obj => FiltrujPoZakresieDat(), obj => datepickerStatystykaOd.SelectedDate != null && datepickerStatystykaDo.SelectedDate != null); 
            buttonStatystykaData.Command = StatystykaData;
        }
        
        private RelayCommand Przychod;
        private RelayCommand StatystykaData;
            


                            //Metody obsługujące Click'i przycisków [z iCommand]
        private void ObliczPrzychod()
        {
            KalkulatorNetto oLiczenie = new KalkulatorNetto();
            textblockWynikBrutto.Text = Convert.ToString(oLiczenie.Oblicz(Convert.ToDouble(textboxNetto.Text)));

            WlozDoBazy_Kwota KWOTA = new WlozDoBazy_Kwota();
            KWOTA.UmiescWartosc(Convert.ToDouble(textboxNetto.Text), Convert.ToDouble(textblockWynikBrutto.Text));
            ellipseAnimacja.Visibility = Visibility.Visible;
        }

                            //Metody obsługujące Click'i przycisków [bez iCommand]
        private void buttonStatystykaTopNajwiekszyZarobek_Click(object sender, RoutedEventArgs e)
        {
            ObsluzZapytanie(1);
        }
        private void buttonStatystykaPokazWszystkoWplaty_Click(object sender, RoutedEventArgs e)
        {
            ObsluzZapytanie(2);
        }
        private void buttonStatystykaPokazWszystkoZapotrzebowanie_Click(object sender, RoutedEventArgs e)
        {
            ObsluzZapytanie(3);
        }


                            //Funkcja ktora tylko czeka [element wspomagajacy anulowanie operacji]
        private void FunkcjaCzekania(CancellationToken ct)
        {
            for (int i = 0; i < 5; i++)
            {
                if (ct.IsCancellationRequested)
                {
                    ct.ThrowIfCancellationRequested();
                }
                Task.Delay(1000).Wait();
            }
        }

                            //Obsługa anulowania operacji poprzez klikniecie w przycisk X
        private void buttonAnulujWczytywanie_Click_1(object sender, RoutedEventArgs e)
        {
            tokenZrodlo.Cancel();
        }
        CancellationTokenSource tokenZrodlo;

                            //Metoda wczytująca dane
        private void ObsluzZapytanie(int a)
        {
            PokazLadowanie();
            tokenZrodlo = new CancellationTokenSource();
            Task task1 = new Task(() => PokazTabele(a, tokenZrodlo.Token), tokenZrodlo.Token);
            task1.Start();
            Task task2 = new Task(() => FunkcjaCzekania(tokenZrodlo.Token), tokenZrodlo.Token);
            task2.Start();
            UkryjLadowanie(task1, task2);
        }

                            //Metody wyswietlajace dane w datagridzie
        private void PokazTabele(int a, CancellationToken ct)
        {
            for (int i = 0; i < 3; i++)
            {
                if (ct.IsCancellationRequested)
                {
                    ct.ThrowIfCancellationRequested();
                }
                PokazTabele_Statystyka Pokaz = new PokazTabele_Statystyka();
                using (SqlConnection polaczenie = new SqlConnection("Data Source=(local)\\SQLEXPRESS;Initial Catalog=jipp7;Integrated Security=True"))
                {
                    polaczenie.Open();
                    SqlCommand komenda = new SqlCommand(Pokaz.Komenda(a), polaczenie);
                    komenda.ExecuteNonQuery();
                    SqlDataAdapter dataAdp = new SqlDataAdapter(komenda);
                    DataTable dt = new DataTable("Wyniki");
                    Task.Delay(1000).Wait();
                    this.Dispatcher.Invoke(() =>
                    {
                        dataAdp.Fill(dt);
                    datagridStatystyka.ItemsSource = dt.DefaultView;
                    dataAdp.Update(dt);
                    });
                }
            }
        }
        private void FiltrujPoZakresieDat()
        {
           
                using (SqlConnection connection = new SqlConnection("Data Source=(local)\\SQLEXPRESS;Initial Catalog=jipp7;Integrated Security=True"))
                {
                    connection.Open();
                    String Query = "Select * FROM Wplaty Where DataWplaty BETWEEN @FOD AND @FDO";
                    SqlCommand command = new SqlCommand(Query, connection);
                    command.Parameters.AddWithValue("@FOD", datepickerStatystykaOd.SelectedDate);
                    command.Parameters.AddWithValue("@FDO", datepickerStatystykaDo.SelectedDate);
                    command.ExecuteNonQuery();
                    SqlDataAdapter dataAdp = new SqlDataAdapter(command);
                    DataTable dt = new DataTable("Wplaty");
                    Task.Delay(2000).Wait();
                    this.Dispatcher.Invoke(() =>
                    {
                        dataAdp.Fill(dt);
                        datagridStatystyka.ItemsSource = dt.DefaultView;
                        dataAdp.Update(dt);
                    });
                }
        }


                            //Obsługa wyświetlania elementów ładowania 
        private void PokazLadowanie()
        {
            Dispatcher.Invoke(() =>
            {
                rectangleLadowanie.Visibility = Visibility.Visible;
                labelTrwaLadowanie.Visibility = Visibility.Visible;
                buttonAnulujWczytywanie.Visibility = Visibility.Visible;
                ellipseLadowanie1.Visibility = Visibility.Visible;
                ellipseLadowanie2.Visibility = Visibility.Visible;
                ellipseLadowanie3.Visibility = Visibility.Visible;
                ellipseLadowanie4.Visibility = Visibility.Visible;
                ellipseLadowanie5.Visibility = Visibility.Visible;
                ellipseLadowanie6.Visibility = Visibility.Visible;
                ellipseLadowanie7.Visibility = Visibility.Visible;
                ellipseLadowanie8.Visibility = Visibility.Visible;

            });
        }

        private void UkryjLadowanie(Task a, Task b)
        {
            Task.WhenAll(a, b).ContinueWith(t =>
            {
                Dispatcher.Invoke(() =>
                {
                    if (t.IsFaulted)
                    {
                        MessageBox.Show("Wystąpił błąd");
                    }
                    rectangleLadowanie.Visibility = Visibility.Hidden;
                    buttonAnulujWczytywanie.Visibility = Visibility.Hidden;
                    labelTrwaLadowanie.Visibility = Visibility.Hidden;
                    ellipseLadowanie1.Visibility = Visibility.Hidden;
                    ellipseLadowanie2.Visibility = Visibility.Hidden;
                    ellipseLadowanie3.Visibility = Visibility.Hidden;
                    ellipseLadowanie4.Visibility = Visibility.Hidden;
                    ellipseLadowanie5.Visibility = Visibility.Hidden;
                    ellipseLadowanie6.Visibility = Visibility.Hidden;
                    ellipseLadowanie7.Visibility = Visibility.Hidden;
                    ellipseLadowanie8.Visibility = Visibility.Hidden;

                });
            });
        }

        
    }
}
