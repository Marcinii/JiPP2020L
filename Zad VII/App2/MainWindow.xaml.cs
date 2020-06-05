using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
using App2.Logic;

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
        }

        private void Analizuj_Click(object sender, RoutedEventArgs e)
        {
            Analyze text = new Analyze(UserControl.TextANA.Text);

            LetterNO.Text = text.letterno().ToString();
            EntropyNO.Text = text.entropy().ToString();

            SaveSQL(text.letterno(), text.entropy());
        }

        public void SaveSQL(int letterno, double entropyno)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=MACBOOK_PRO_ADA\SQLSERVER;Database=App;User Id=sa;Password=Test123;") ;
            SqlCommand comm;

            string tmp = Math.Round(entropyno, 2).ToString();
            tmp = tmp.Replace(',', '.');

            string sql = "insert into stats values ("+ letterno +", " + tmp + ")";

            conn.Open();
            comm = new SqlCommand(sql, conn);
            comm.ExecuteNonQuery();
            comm.Dispose();
            conn.Close();

        }
        public void LoadSQL()
        {
            Dispatcher.Invoke(() => Loader.Width = 10);
            SqlConnection conn = new SqlConnection(@"Data Source=MACBOOK_PRO_ADA\SQLSERVER;Database=App;User Id=sa;Password=Test123;");
            SqlCommand comm;
            string sql = "select * from stats";
            comm = new SqlCommand(sql, conn);

            conn.Open();

            Task.Delay(500).Wait();

            using (SqlDataAdapter adapter = new SqlDataAdapter(comm))
            {
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                StatsGrid.ItemsSource = dt.DefaultView;
            }
            
            conn.Close();
            Dispatcher.Invoke(() => Loader.Width = 377);
        }

        private void StatsBT_Click(object sender, RoutedEventArgs e)
        {
            LoadSQL();
        }
    }

   
}
