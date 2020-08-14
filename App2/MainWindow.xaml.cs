using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data.SqlClient;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using App2.Logic;
using System.CodeDom.Compiler;
using System.Data;

namespace App2
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       public MainWindow()
        {
            InitializeComponent();

            DiceType.ItemsSource = new List<IDice>
            {
                new K4(),
                new K6(),
                new K8(),
                new K10(),
                new K12(),
                new K20()
            };
        }
        public void Save_SQL(string rodzaj_kosci, int ilosc_rzutow, string rzuty)
        {
            SqlConnection connection = new SqlConnection("server=localhost;user id=testuser;pwd=qaz123wsx;database=statisctisc");

            DateTime date = DateTime.Today;
            string truedate = date.ToString("yyyy-MM-dd");

            string query = "insert into [dbo].[dices] (Typ_kosci, Ilosc_rzutow, Wynik, Data) values ('" + rodzaj_kosci + "', " + ilosc_rzutow + ", '" + rzuty + "', '" + truedate + "')";

            connection.Open();

            SqlCommand exec = new SqlCommand(query, connection);

            exec.ExecuteNonQuery();
            exec.Dispose();

            connection.Close();
        }

        public void Load_SQL_A()
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
            Load_SQL();

            Dispatcher.Invoke(() =>
            {
                ProgessRectangle.Visibility = Visibility.Hidden;
            });
        }

        public void Load_SQL()
        {
            SqlConnection connection = new SqlConnection("server=localhost;user id=testuser;pwd=qaz123wsx;database=statisctisc");

            string query = "select * from [dbo].[dices]";
           
            SqlCommand exec = new SqlCommand(query, connection);

            connection.Open();

            using (SqlDataAdapter adapter = new SqlDataAdapter(exec))
            {
                DataTable Stats = new DataTable();
                adapter.Fill(Stats);

                Dispatcher.Invoke(() =>
                {
                    StatisticsGrid.ItemsSource = Stats.DefaultView;
                });
            }

            connection.Close();
        }

        private void ThrowButton_Click(object sender, RoutedEventArgs e)
        {
            int[] result = ((IDice)DiceType.SelectedItem).Throw(Convert.ToInt32(AmountSlider.Value));

            List<Label> Wyniki = new List<Label>
            {
                Results.V1,
                Results.V2,
                Results.V3,
                Results.V4
            };

            for (int i = 0; i < result.Length; i++)
            {
                ((Label)Wyniki[i]).Content = result[i];
            }

            string rzuty = Results.V1.Content.ToString() + ", " + Results.V2.Content.ToString() + ", " + Results.V3.Content.ToString() + ", " + Results.V4.Content.ToString();

            Save_SQL(((IDice)DiceType.SelectedItem).name, Convert.ToInt32(AmountSlider.Value), rzuty);
        }

        private void DiceType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AmountSlider.Maximum = Convert.ToDouble(((IDice)DiceType.SelectedItem).max_amount);
        }

        private void AmountSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            List<Label> Wyniki = new List<Label>
            {
                Results.V1,
                Results.V2,
                Results.V3,
                Results.V4
            };

            AmountValue.Content = Math.Round(AmountSlider.Value).ToString();

            foreach (var item in Wyniki)
            {
                item.Visibility = Visibility.Hidden;
            }

            for (int i = 0; i < Math.Round(AmountSlider.Value); i++)
            {
                ((Label)Wyniki[i]).Visibility = Visibility.Visible;
            }
        }

        private void Stats_Click(object sender, RoutedEventArgs e)
        {
            Task t = new Task(() => Load_SQL_A());
            t.Start();
        }
    }
}
