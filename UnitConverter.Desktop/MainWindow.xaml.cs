using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Threading;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UnitConverter.Logic;

namespace UnitConverter.Desktop
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public bool top3 = false;
        public int pages = 0;
        public string SQL_START;
        public string SQL_LAST;
        public int control = 1;
        public MainWindow()
        {
            InitializeComponent();

            ComboboxConv.ItemsSource = new List<Iconverter>
            {
                new CelToFar(),
                new FarToCel(),
                new KgToFu(),
                new FuToKg(),
                new KmToMi(),
                new MiToKm(),
                new MeToKm(),
                new MinToSec(),
                new SecToMin(),
                new ZegarConv()
            };

            Filtr_Combo.ItemsSource = new List<Iconverter>
            {
                new CelToFar(),
                new FarToCel(),
                new KgToFu(),
                new FuToKg(),
                new KmToMi(),
                new MiToKm(),
                new MeToKm(),
                new MinToSec(),
                new SecToMin(),
                new ZegarConv()
            };

            UserRate.RateValue = DownloadRate();




            ConvertCommand = new RelayCommand(obj => Convert(), obj => ComboboxConv.SelectedItem != null && string.IsNullOrEmpty(InputTextBox.Text) != true);
            ConvertButton.Command = ConvertCommand;

            StatisticsCommand = new RelayCommand(obj => Statistics());
            Statistics_Button.Command = StatisticsCommand;

            RateCommand = new RelayCommand(obj => Rating());
            Rate.Command = RateCommand;

            MoreCommand = new RelayCommand(obj => MoreRecords());
            moreButton.Command = MoreCommand;

            LessCommand = new RelayCommand(obj => LessRecords());
            lessbutton.Command = LessCommand;

            TopCommand = new RelayCommand(obj => Popular());
            popular.Command = TopCommand;

        }

        private RelayCommand ConvertCommand;
        private RelayCommand StatisticsCommand;
        private RelayCommand RateCommand;
        private RelayCommand MoreCommand;
        private RelayCommand LessCommand;
        private RelayCommand TopCommand;


        private void ComboboxConv_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            LabelFrom.Content = ((Iconverter)ComboboxConv.SelectedItem).unitFrom;
            LabelTo.Content = ((Iconverter)ComboboxConv.SelectedItem).unitTo;

            if (((Iconverter)ComboboxConv.SelectedItem).unitFrom == "24h")
            {
                Tarcza.Visibility = Visibility.Visible;
                Wskaz_godz.Visibility = Visibility.Visible;
                Wskaz_min.Visibility = Visibility.Visible;
                Statistics_Button.Visibility = Visibility.Hidden;
                Rate.Visibility = Visibility.Hidden;
            }
            else
            {
                Tarcza.Visibility = Visibility.Hidden;
                Wskaz_godz.Visibility = Visibility.Hidden;
                Wskaz_min.Visibility = Visibility.Hidden;
                Statistics_Button.Visibility = Visibility.Visible;
                Rate.Visibility = Visibility.Visible;
            }
        }

        private void Convert()
        {
            string inputText = InputTextBox.Text;
            double inputValue = double.Parse(inputText);

            double result = ((Iconverter)ComboboxConv.SelectedItem).Convert(inputValue);

            if (((Iconverter)ComboboxConv.SelectedItem).unitFrom == "24h")
            {
                double angle_godz = Math.Floor(result) * 360 / 12;
                double angle_min = (result - Math.Floor(result)) * 100 * 360 / 60;

                RotateTransform obrotogodz = new RotateTransform(angle_godz);
                RotateTransform obrotomin = new RotateTransform(angle_min);

                Wskaz_godz.RenderTransform = obrotogodz;
                Wskaz_min.RenderTransform = obrotomin;
            }

            outputTextBlock.Text = Math.Round(result, 2).ToString();

            Save_SQL(((Iconverter)ComboboxConv.SelectedItem).name, ((Iconverter)ComboboxConv.SelectedItem).unitFrom, Math.Round(inputValue, 2), ((Iconverter)ComboboxConv.SelectedItem).unitTo, Math.Round(result, 2));

        }

        public void Save_SQL(string Rodzaj_konwersji, string Z, double Pierwotna, string Na, double Wynik)
        {
            SqlConnection connection = new SqlConnection("server=localhost;user id=testuser;pwd=qaz123wsx;database=statisctisc");

            string konwersja = Rodzaj_konwersji;
            string unitFrom = Z;
            string value = Math.Floor(Pierwotna).ToString().Replace(',', '.');
            string unitTo = Na;
            string result = Math.Floor(Wynik).ToString().Replace(',', '.');
            DateTime date = DateTime.Today;
            string truedate = date.ToString("yyyy-MM-dd");

            string query = "insert into [dbo].[statistics] (Rodzaj_konwersji, Z, Pierwotnie, Na, Wynik, Data) values ('" + konwersja + "', '" + unitFrom + "', " + value + ", '" + unitTo + "', " + result + ", '" + truedate + "')";

            connection.Open();

            SqlCommand exec = new SqlCommand(query, connection);

            exec.ExecuteNonQuery();
            exec.Dispose();

            connection.Close();
        }

        public void Load_SQL()
        {
            Dispatcher.Invoke(() =>
            {
                ProgessRectangle.Height = 30;
                ProgessRectangle.Visibility = Visibility.Visible;
            });

            Task.Delay(1000).Wait();

            Dispatcher.Invoke(() =>
            {
                ProgessRectangle.Height = 250;
            });

            Task.Delay(1000).Wait();

            Dispatcher.Invoke(() =>
            {
                ProgessRectangle.Height = 419;
            });

            Task.Delay(1000).Wait();
            DoQuery("");

            Dispatcher.Invoke(() =>
            {
                ProgessRectangle.Visibility = Visibility.Hidden;
            });
        }

        public void DoQuery(string query)
        {
            SqlConnection connection = new SqlConnection("server=localhost;user id=testuser;pwd=qaz123wsx;database=statisctisc");

            SQL_LAST = query;

            if (query == "")
            {
                SQL_START = "select * from [dbo].[statistics] where ID between " + ((pages * 20) + 1).ToString() + " and " + ((pages + 1 * 20)).ToString() + " ";
                query = SQL_START + query;
            }
            else
            {
                query = "" + query;
            }

            SqlCommand exec = new SqlCommand(query, connection);

            connection.Open();

            using (SqlDataAdapter adapter = new SqlDataAdapter(exec))
            {
                DataTable Stats = new DataTable();
                adapter.Fill(Stats);

                Dispatcher.Invoke(() =>
                {
                    DataStats.ItemsSource = Stats.DefaultView;
                });
            }

            connection.Close();
        }

        public string Filtruj_SQL(string Rodzaj_konwersji)
        {
            string query = SQL_START + "and Rodzaj_konwersji='" + Rodzaj_konwersji + "' ";

            return query;
        }

        private void Statistics()
        {
            Task t = new Task(() => Load_SQL());

            top3 = false;

            if (Stats.Visibility == Visibility.Visible)
            {
                Stats.Visibility = Visibility.Hidden;
                DataStats.ItemsSource = null;
                return;
            }

            Stats.Visibility = Visibility.Visible;

            t.Start();
        }

        private void Filtr_Combo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string query = Filtruj_SQL(((Iconverter)Filtr_Combo.SelectedItem).name);

            DoQuery(query);
        }

        private void MoreRecords()
        {
            pages++;
            if (pages > 1)
            {
                lessbutton.Visibility = Visibility.Visible;
            }
            DoQuery("");
        }

        private void LessRecords()
        {
            pages--;
            if (pages > 1)
            {
                lessbutton.Visibility = Visibility.Hidden;
            }
            DoQuery("");
        }

        public string Date_SQL(DateTime first, DateTime second)
        {
            string od = first.ToString("yyyy-MM-dd");
            string to = second.ToString("yyyy-MM-dd");

            string query = "where [Data] between '" + od + "' and '" + to + "'";

            return query;
        }

        public void Top_SQL()
        {
            if (top3 == true)
            {
                string query_data = Date_SQL(FirstDate.SelectedDate.Value, SecondDate.SelectedDate.Value);

                string query = "Select TOP(3) Count([Data]) as [Liczba_użyć], [Rodzaj_konwersji] from[dbo].[statistics] " + query_data + "group by [Rodzaj_konwersji] order by [Liczba_użyć] DESC";

                DoQuery(query);

                top3 = false;
            }
            else top3 = true;
        }

        private void Popular()
        {
            Top_SQL();
        }

        private void SecondDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (top3 == true)
            {
                Top_SQL();
            }
            else { DoQuery(Date_SQL(FirstDate.SelectedDate.Value, SecondDate.SelectedDate.Value)); }
        }

        private void Rating()
        {
            if (UserRate.Visibility == Visibility.Visible)
            {
                UserRate.Visibility = Visibility.Hidden;
                return;
            }

            UserRate.Visibility = Visibility.Visible;


        }

        private void UserRate_RateValueChanged(object sender, RateEventArgs e)
        {
            if (control == 0)
            {
                SqlConnection connection = new SqlConnection("server=localhost;user id=testuser;pwd=qaz123wsx;database=statisctisc");

                int rate = e.Value;
                DateTime date = DateTime.Today;
                string truedate = date.ToString("yyyy-MM-dd");

                string query = "insert into [dbo].[rating] (Rate_value, Date) values ('" + rate + "', '" + truedate + "')";

                connection.Open();

                SqlCommand exec = new SqlCommand(query, connection);

                exec.ExecuteNonQuery();
                exec.Dispose();

                connection.Close();

                return;
            }
            control = 0;
        }

        private int DownloadRate()
        {
            int tmp = 0;

            SqlConnection connection = new SqlConnection("server=localhost;user id=testuser;pwd=qaz123wsx;database=statisctisc");

            string query = "Select TOP (1) [Rate_value] from [dbo].rating order by id desc";

            connection.Open();

            SqlCommand exec = new SqlCommand(query, connection);

            tmp = (int)exec.ExecuteScalar();

            connection.Close();

            return tmp;
        }
    }
}
