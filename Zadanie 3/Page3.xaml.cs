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
using System.Windows.Media.Animation;
using System.Globalization;
//---------------------------------------NAJNOWSZY ------------------------------
namespace application
{
  
    public partial class Page3 : Page
    {
        public Page3()
        {
            InitializeComponent();
            PM_AM.Visibility = Visibility.Collapsed;
            btn12H.Visibility = Visibility.Collapsed;
            btn24H.Visibility = Visibility.Collapsed;
        }

        public void TimeNow()
        {
            Storyboard hours = (Storyboard)FindResource("hours");
            hours.Begin();
            hours.Seek(new TimeSpan(0, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, 0));

            Storyboard minutes = (Storyboard)FindResource("minutes");
            minutes.Begin();
            minutes.Seek(new TimeSpan(0, 0, DateTime.Now.Minute, DateTime.Now.Second, 0));

            Storyboard seconds = (Storyboard)FindResource("seconds");
            seconds.Begin();
            seconds.Seek(new TimeSpan(0, 0, 0, DateTime.Now.Second, 0));
        }

        public void TimeZeroed()
        {
            Storyboard hours = (Storyboard)FindResource("hours");
            hours.Begin();
            hours.Seek(new TimeSpan(0, 0, 0, 0, 0));

            Storyboard minutes = (Storyboard)FindResource("minutes");
            minutes.Begin();
            minutes.Seek(new TimeSpan(0, 0, 0, 0, 0));

            Storyboard seconds = (Storyboard)FindResource("seconds");
            seconds.Begin();
            seconds.Seek(new TimeSpan(0, 0, 0, 0, 0));
        }


        private void btnGoBack_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Page0());
        }

        private void btnGoConverter_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Page1());
        }


        private void btn12h_Click(object sender, RoutedEventArgs e)
        {
            string tmpH = Convert.ToString(txtSetTimeH.Text);
            int parsedInput = Convert.ToInt32(tmpH);
            lblShowTimeH.Opacity = 100;
            lblShowTimeMIN.Opacity = 100;
            lblShowTimeSEC.Opacity = 100;
            lblShowTime.Opacity = 100;

            if (parsedInput > 12)
            {
                lblShowTimeH.Opacity = 100;
                lblShowTimeMIN.Opacity = 100;
                lblShowTimeSEC.Opacity = 100;
                PM_AM.Content = "PM";
                PM_AM.Visibility = Visibility.Visible;

                if (tmpH == "24") tmpH = "12";
                if (tmpH == "23") tmpH = "11";
                if (tmpH == "22") tmpH = "10";
                if (tmpH == "21") tmpH = "9";
                if (tmpH == "20") tmpH = "8";
                if (tmpH == "19") tmpH = "7";
                if (tmpH == "18") tmpH = "6";
                if (tmpH == "17") tmpH = "5";
                if (tmpH == "16") tmpH = "4";
                if (tmpH == "15") tmpH = "3";
                if (tmpH == "14") tmpH = "2";
                if (tmpH == "13") tmpH = "1";

                lblShowTimeH.Content = tmpH;
            }

            else if (parsedInput <= 12)
            {
                PM_AM.Content = "AM";
                PM_AM.Visibility = Visibility.Visible;
                lblShowTimeH.Content = tmpH;
            }
        }

        private void btn24h_Click(object sender, RoutedEventArgs e)
        {
            lblPM_AM.Opacity = 0;
            lblShowTimeH.Opacity = 0;
            lblShowTimeMIN.Opacity = 0;
            lblShowTimeSEC.Opacity = 0;
            lblShowTime.Opacity = 0;
        }

        private void hideTime_Click(object sender, RoutedEventArgs e)
        {
            TimeZeroed();
            lblPM_AM.Opacity = 0;
            lblShowTime.Opacity = 0;
            lblShowTimeH.Opacity = 0;
            lblShowTimeMIN.Opacity = 0;
            lblShowTimeSEC.Opacity = 0;
            txtSetTimeH.Opacity = 0;
            recGreenH.Opacity = 0;
            txtSetTimeMIN.Opacity = 0;
            recGreenMin.Opacity = 0;
            txtSetTimeSEC.Opacity = 0;
            recGreenSec.Opacity = 0;
            lblSeconds.Opacity = 0;
            btn12H.Visibility = Visibility.Visible;
            PM_AM.Visibility = Visibility.Collapsed;
            lblShowTime.Content = " ";
            btn12H.Visibility = Visibility.Collapsed;

        }

        private void btnSetTime_Click(object sender, RoutedEventArgs e)
        {
            txtSetTimeH.Opacity = 100;
            recGreenH.Opacity = 100;
            txtSetTimeMIN.Opacity = 100;
            recGreenMin.Opacity = 100;
            txtSetTimeSEC.Opacity = 100;
            recGreenSec.Opacity = 100;
            lblShowTime.Opacity = 0;
            lblShowTimeH.Visibility = Visibility.Visible;
            lblShowTimeMIN.Visibility = Visibility.Visible;
            lblShowTimeSEC.Visibility = Visibility.Visible;
            lblShowTime.Visibility = Visibility.Visible;
            lblShowTime.Content = " ";
            btn12H.Visibility = Visibility.Visible;
            btn24H.Visibility = Visibility.Visible;

        }

        private void txtSetTimeH_TextChanged(object sender, TextChangedEventArgs e)
        {
            userSetTimeH();
            string tmpS = txtSetTimeH.Text;
            int tmpI = Convert.ToInt32(tmpS);
            lblShowTimeH.Content = tmpI;
        }

        private void txtSetTimeMIN_TextChanged(object sender, TextChangedEventArgs e)
        {
            userSetTimeMin();
            string tmpS = txtSetTimeMIN.Text;
            int tmpI = Convert.ToInt32(tmpS);
            lblShowTimeMIN.Content = tmpI;
        }

        private void txtSetTimeSEC_TextChanged(object sender, TextChangedEventArgs e)
        {
            userSetTimeSec();
            string tmpS = txtSetTimeSEC.Text;
            int tmpI = Convert.ToInt32(tmpS);
            lblShowTimeSEC.Content = tmpI;
        }

        public void userSetTimeSec()
        {
            string tmpS = txtSetTimeSEC.Text;
            int tmp2S = Int32.Parse(tmpS);
            Storyboard seconds = (Storyboard)FindResource("seconds");
            seconds.Begin();
            seconds.Seek(new TimeSpan(0, 0, 0, tmp2S, 0));
        }

        public void userSetTimeMin()
        {
            string tmpM = txtSetTimeH.Text;
            int tmp2M = Int32.Parse(tmpM);
            Storyboard minutes = (Storyboard)FindResource("minutes");
            minutes.Begin();
            minutes.Seek(new TimeSpan(0, 0, tmp2M, DateTime.Now.Second, 0));
        }

        public void userSetTimeH()
        {
            string tmpH = txtSetTimeH.Text;
            int tmp2H = Int32.Parse(tmpH);
            Storyboard hours = (Storyboard)FindResource("hours");
            hours.Begin();
            hours.Seek(new TimeSpan(0, tmp2H , DateTime.Now.Minute, DateTime.Now.Second, 0));
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            TimeZeroed();
            lblShowTimeH.Opacity = 0;
            lblShowTimeMIN.Opacity = 0;
            lblShowTimeSEC.Opacity = 0;
            lblShowTime.Opacity = 0;

            lblShowTimeH.Content = " ";
            lblShowTimeMIN.Content = " ";
            lblShowTimeSEC.Content = " ";

            recGreenH.Opacity = 0;
            recGreenMin.Opacity = 0;
            recGreenSec.Opacity = 0;
        
            txtSetTimeH.Opacity = 0;
            txtSetTimeMIN.Opacity = 0;
            txtSetTimeSEC.Opacity = 0;
  
            btn12H.Visibility = Visibility.Collapsed;
            btn24H.Visibility = Visibility.Collapsed;
            lblShowTime.Visibility = Visibility.Hidden;
            
        }

        private void btnCurrentTime_Click(object sender, RoutedEventArgs e)
        {
            TimeNow();
            btn12H.Visibility = Visibility.Collapsed;
            lblShowTime.Content = DateTime.Now.ToString("HH:mm:ss");
            lblShowTimeH.Opacity = 0;
            lblShowTimeMIN.Opacity = 0;
            lblShowTimeSEC.Opacity = 0;
            lblShowTime.Opacity = 100;
            lblShowTime.Visibility = Visibility.Visible;
        }



    }
}
