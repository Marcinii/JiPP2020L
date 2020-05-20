using System.Windows.Controls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Threading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;
using System.Runtime.CompilerServices;

namespace application
{

    public partial class U1 : System.Windows.Controls.UserControl
    {
        public U1()
        {
            InitializeComponent();
            FillDataGrid();
        }
        public void FillDataGrid()
        {
            string ConString = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            string CmdString = string.Empty;
            using (SqlConnection con = new SqlConnection(ConString))
            {
                CmdString = "SELECT * FROM StatTable";
                SqlCommand cmd = new SqlCommand(CmdString, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("StatTable");
                sda.Fill(dt);
                StatGrid.ItemsSource = dt.DefaultView;
            }
        }

        CancellationTokenSource tokenSource;

        public void user4()
        {
            tokenSource = new CancellationTokenSource();
            Task t4 = new Task(() => r_4(tokenSource.Token), tokenSource.Token);
            t4.Start();
            loadprogressbar();
        }

        public void r_4(CancellationToken ct)
        {
            if (ct.IsCancellationRequested) { ct.ThrowIfCancellationRequested(); }
            Thread.Sleep(10000);
            Dispatcher.Invoke(() => r4.Visibility = Visibility.Hidden);
        }
 
        public void loadprogressbar()
        {
            Duration duration_ = new Duration(TimeSpan.FromSeconds(10));
            DoubleAnimation doubleA = new DoubleAnimation(100.0, duration_);
            Dispatcher.Invoke(() =>  progressBar1.BeginAnimation(System.Windows.Controls.ProgressBar.ValueProperty, doubleA));
        }

        private void btnX_Click(object sender, RoutedEventArgs e)
        {
            tokenSource.Cancel();
            r4.Visibility = Visibility.Hidden;
        }
    }
}
