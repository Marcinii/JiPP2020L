using System;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;


namespace stars
{

    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
            _timer.Interval = TimeSpan.FromSeconds(0.2);
            _timer.Tick += Timer_Tick;
            getLastRating();
            setStar();
        }


        private int _rateValue = 0;
        public event EventHandler<RateEventArgs> RateValueChanged;
        public class RateEventArgs : EventArgs
        {
            public int Value { get; set; }
        }

        private readonly System.Windows.Threading.DispatcherTimer _timer = new System.Windows.Threading.DispatcherTimer();
        private void Timer_Tick(object sender, EventArgs e)
        {
            _timer.Stop();
        }

        public void InsertData(int rank_value)
        {
            using (DB2 context = new DB2())
            {
                ranking rank = new ranking()
                {
                    rating = rank_value
                };

                context.ranking.Add(rank);
                context.SaveChanges();
            }
        }

        public int getLastRating()
        {   
            string ConString = ConfigurationManager.ConnectionStrings["DB2"].ConnectionString;
            string CmdString = string.Empty;
            int returnedRanking = 0;
            using (SqlConnection con = new SqlConnection(ConString))
            {
                CmdString = "USE Staticat SELECT TOP 1 rating FROM ranking ORDER BY Id DESC";
                SqlCommand cmd = new SqlCommand(CmdString, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt1 = new DataTable("ranking");
                sda.Fill(dt1);

                returnedRanking = dt1.Rows[0].Field<int>("rating");
                _rateValue = returnedRanking;
            }
             return _rateValue;
        }

        private void rateControl_RateValueChanged(object sender, RateEventArgs e)
        {
            getLastRating();
        }
      

        public int RateValue
        {
            get { return _rateValue; }
            set
            {
                _rateValue = value;
                setStar();

                if (RateValueChanged != null)
                {
                    RateValueChanged(this, new RateEventArgs() { Value = _rateValue });
                }
            }
        }

        public void setStar()
        {
            int tmp = getLastRating();

            if (tmp == 0)
            {
                str1.Background = Brushes.White;
                str2.Background = Brushes.White;
                str3.Background = Brushes.White;
                str4.Background = Brushes.White;
                str5.Background = Brushes.White;
            }

            if (tmp == 1)
            {
                str1.Background = Brushes.Goldenrod;
                str2.Background = Brushes.White;
                str3.Background = Brushes.White;
                str4.Background = Brushes.White;
                str5.Background = Brushes.White;
            }

            if (tmp == 2)
            {
                str1.Background = Brushes.Goldenrod;
                str2.Background = Brushes.Goldenrod;
                str3.Background = Brushes.White;
                str4.Background = Brushes.White;
                str5.Background = Brushes.White;
            }

            if (tmp == 3)
            {
                str1.Background = Brushes.Goldenrod;
                str2.Background = Brushes.Goldenrod;
                str3.Background = Brushes.Goldenrod;
                str4.Background = Brushes.White;
                str5.Background = Brushes.White;
            }

            if (tmp == 4)
            {
                str1.Background = Brushes.Goldenrod;
                str2.Background = Brushes.Goldenrod;
                str3.Background = Brushes.Goldenrod;
                str4.Background = Brushes.Goldenrod;
                str5.Background = Brushes.White;
            }

            if (tmp == 5)
            {
                str1.Background = Brushes.Goldenrod;
                str2.Background = Brushes.Goldenrod;
                str3.Background = Brushes.Goldenrod;
                str4.Background = Brushes.Goldenrod;
                str5.Background = Brushes.Goldenrod;
            }
        }

        private void str5_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                _timer.Stop();
                str1.Background = Brushes.White;
                str2.Background = Brushes.White;
                str3.Background = Brushes.White;
                str4.Background = Brushes.White;
                str5.Background = Brushes.White;

                _rateValue = 0;
            }
            else
            {
                _timer.Start();
                str1.Background = Brushes.Goldenrod;
                str2.Background = Brushes.Goldenrod;
                str3.Background = Brushes.Goldenrod;
                str4.Background = Brushes.Goldenrod;
                str5.Background = Brushes.Goldenrod;
                _rateValue = 5;
            }

            InsertData(_rateValue);
        }
        private void str4_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                _timer.Stop();
                str1.Background = Brushes.White;
                str2.Background = Brushes.White;
                str3.Background = Brushes.White;
                str4.Background = Brushes.White;
                str5.Background = Brushes.White;
                _rateValue = 0;
            }
            else
            {
                _timer.Start();
                str1.Background = Brushes.Goldenrod;
                str2.Background = Brushes.Goldenrod;
                str3.Background = Brushes.Goldenrod;
                str4.Background = Brushes.Goldenrod;
                str5.Background = Brushes.White;
                _rateValue = 4;
            }
            InsertData(_rateValue);
        }
        private void str3_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                _timer.Stop();
                str1.Background = Brushes.White;
                str2.Background = Brushes.White;
                str3.Background = Brushes.White;
                str4.Background = Brushes.White;
                str5.Background = Brushes.White;
                _rateValue = 0;
            }
            else
            {
                _timer.Start();
                str1.Background = Brushes.Goldenrod;
                str2.Background = Brushes.Goldenrod;
                str3.Background = Brushes.Goldenrod;
                str4.Background = Brushes.White;
                str5.Background = Brushes.White;

                _rateValue = 3;
            }
            InsertData(_rateValue);
        }
        private void str2_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                _timer.Stop();
                str1.Background = Brushes.White;
                str2.Background = Brushes.White;
                str3.Background = Brushes.White;
                str4.Background = Brushes.White;
                str5.Background = Brushes.White;
                _rateValue = 0;
            }
            else
            {
                _timer.Start();
                str1.Background = Brushes.Goldenrod;
                str2.Background = Brushes.Goldenrod;
                str3.Background = Brushes.White;
                str4.Background = Brushes.White;
                str5.Background = Brushes.White;
                _rateValue = 2;
            }
            InsertData(_rateValue);
        }
        private void str1_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                _timer.Stop();
                str1.Background = Brushes.White;
                str2.Background = Brushes.White;
                str3.Background = Brushes.White;
                str4.Background = Brushes.White;
                str5.Background = Brushes.White;
                _rateValue = 0;
            }
            else
            {
                _timer.Start();
                str1.Background = Brushes.Goldenrod;
                str2.Background = Brushes.White;
                str3.Background = Brushes.White;
                str4.Background = Brushes.White;
                str5.Background = Brushes.White;
                _rateValue = 1;
            }
            InsertData(_rateValue);
        }

    }
}




