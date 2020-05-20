using System.Windows;
using System.Data;
using System.Windows.Controls;
using System.Configuration;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Media.Animation;
using System;

namespace application
{

    public partial class U2 : UserControl
    {
        public U2()
        {
            InitializeComponent();
            getConverterType();
            getUnitType();
            getValueType();
         }

        public void getConverterType()
        {
            string ConString = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            string CmdString = string.Empty;
            using (SqlConnection con = new SqlConnection(ConString))
            {
                CmdString = "SELECT DISTINCT TOP 3 ConverterType FROM StatTable";
                SqlCommand cmd = new SqlCommand(CmdString, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt1 = new DataTable("StatTable");
                sda.Fill(dt1);

                string l1 = dt1.Rows[0].Field<string>("ConverterType");
                string l2 = dt1.Rows[1].Field<string>("ConverterType");
                string l3 = dt1.Rows[2].Field<string>("ConverterType");

                topConv1.Content = l1;
                topConv2.Content = l2;
                topConv3.Content = l3;
            }
        }

        public void getUnitType()
        {
            string ConString = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            string CmdString = string.Empty;
            using (SqlConnection con = new SqlConnection(ConString))
            {
                CmdString = "SELECT DISTINCT TOP 3 UnitFrom FROM StatTable";
                SqlCommand cmd = new SqlCommand(CmdString, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt2 = new DataTable("StatTable");
                sda.Fill(dt2);

                string u1 = dt2.Rows[0].Field<string>("UnitFrom");
                string u2 = dt2.Rows[1].Field<string>("UnitFrom");
                string u3 = dt2.Rows[2].Field<string>("UnitFrom");

                topU1.Content = u1;
                topU2.Content = u2;
                topU3.Content = u3;
            }
        }

        public void getValueType()
        {
            string ConString = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            string CmdString = string.Empty;
            using (SqlConnection con = new SqlConnection(ConString))
            {
                CmdString = "SELECT DISTINCT TOP 3 ValueFrom FROM StatTable";
                SqlCommand cmd = new SqlCommand(CmdString, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt3 = new DataTable("StatTable");
                sda.Fill(dt3);

                string v1 = dt3.Rows[0].Field<string>("ValueFrom");
                string v2 = dt3.Rows[1].Field<string>("ValueFrom");
                string v3 = dt3.Rows[2].Field<string>("ValueFrom");

                topV1.Content = v1;
                topV2.Content = v2;
                topV3.Content = v3;
            }
        }

        CancellationTokenSource tokenSource1;

        public void user1()
        {
            tokenSource1 = new CancellationTokenSource();
            Task t1 = new Task(() => r_1(tokenSource1.Token), tokenSource1.Token);
            t1.Start();
            loadprogressbar1();
        }
        public void r_1(CancellationToken ct)
        {
            if (ct.IsCancellationRequested) { ct.ThrowIfCancellationRequested(); }
            Thread.Sleep(3000);
            Dispatcher.Invoke(() =>
            r1.Visibility = Visibility.Hidden
            );
        }

        public void loadprogressbar1()
        {
            Duration duration_1 = new Duration(TimeSpan.FromSeconds(10));
            DoubleAnimation doubler1 = new DoubleAnimation(100.0, duration_1);
            Dispatcher.Invoke(() => progressBar_r1.BeginAnimation(System.Windows.Controls.ProgressBar.ValueProperty, doubler1));
        }

        private void btnr1_Click(object sender, RoutedEventArgs e)
        {
            tokenSource1.Cancel();
            r1.Visibility = Visibility.Hidden;
        }

        public void user2()
        {
            tokenSource1 = new CancellationTokenSource();
            Task t2 = new Task(() => r_2(tokenSource1.Token), tokenSource1.Token);
            t2.Start();
            loadprogressbar2();
        }

        public void r_2(CancellationToken ct)
        {
            if (ct.IsCancellationRequested) { ct.ThrowIfCancellationRequested(); }
            Thread.Sleep(6000);
            Dispatcher.Invoke(() =>
            r2.Visibility = Visibility.Hidden
            );
        }

        public void loadprogressbar2()
        {
            Duration duration_2 = new Duration(TimeSpan.FromSeconds(6));
            DoubleAnimation doubler2 = new DoubleAnimation(100.0, duration_2);
            Dispatcher.Invoke(() => progressBar_r2.BeginAnimation(System.Windows.Controls.ProgressBar.ValueProperty, doubler2));
        }

        private void btnr2_Click(object sender, RoutedEventArgs e)
        {
            tokenSource1.Cancel();
            r2.Visibility = Visibility.Hidden;
        }

        public void user3()
        {
            tokenSource1 = new CancellationTokenSource();
            Task t3 = new Task(() => r_3(tokenSource1.Token), tokenSource1.Token);
            t3.Start();
            loadprogressbar3();
        }
  
        public void r_3(CancellationToken ct)
        {
            if (ct.IsCancellationRequested) { ct.ThrowIfCancellationRequested(); }
            Thread.Sleep(9000);
            Dispatcher.Invoke(() =>
            r3.Visibility = Visibility.Hidden
            );
        }

        public void loadprogressbar3()
        {
            Duration duration_3 = new Duration(TimeSpan.FromSeconds(9));
            DoubleAnimation doubler3 = new DoubleAnimation(100.0, duration_3);
            Dispatcher.Invoke(() => progressBar_r3.BeginAnimation(System.Windows.Controls.ProgressBar.ValueProperty, doubler3));
        }

        private void btnr3_Click(object sender, RoutedEventArgs e)
        {
            tokenSource1.Cancel();
            r3.Visibility = Visibility.Hidden;
        }

    }
}





