using System.Windows;
using System.Windows.Controls;
using System.Threading;
using System.Threading.Tasks;
using application;


namespace application
{
    public partial class Page4 : Page
    {
        public Page4()
        {
            InitializeComponent();
            panel1.Visibility = Visibility.Collapsed;
            panel2.Visibility = Visibility.Collapsed;
            panel3.Visibility = Visibility.Collapsed;
            panel4.Visibility = Visibility.Collapsed;
         
        }

        private void btnHome2_Click(object sender, RoutedEventArgs e)
        {
            s0.Opacity = 100;
            s1.Opacity = 0;
            s2.Opacity = 0;
            s3.Opacity = 0;
            s4.Opacity = 0;
            s0.Height = btnHome2.Height;
            panel1.Visibility = Visibility.Collapsed;
            panel2.Visibility = Visibility.Collapsed;
            panel3.Visibility = Visibility.Collapsed;
            panel4.Visibility = Visibility.Collapsed;
            this.NavigationService.Navigate(new Page0());

        }

        CancellationTokenSource aa;
        

        private void btnShowStats_Click(object sender, RoutedEventArgs e)
        {
            s0.Opacity = 0;
            s1.Opacity = 100;
            s2.Opacity = 0;
            s3.Opacity = 0;
            s4.Opacity = 0;
            s1.Height = btnShowStats.Height;
            panel1.Visibility = Visibility.Visible;
            panel2.Visibility = Visibility.Collapsed;
            panel3.Visibility = Visibility.Collapsed;
            panel4.Visibility = Visibility.Collapsed;

            panel1.user4();
        }

        private void btnTop3_Click(object sender, RoutedEventArgs e)
        {
            s0.Opacity = 0;
            s1.Opacity = 0;
            s2.Opacity = 100;
            s3.Opacity = 0;
            s4.Opacity = 0;
            s2.Height = btnTop3.Height;
            panel1.Visibility = Visibility.Collapsed;
            panel2.Visibility = Visibility.Visible;
            panel3.Visibility = Visibility.Collapsed;
            panel4.Visibility = Visibility.Collapsed;

            panel2.user1();
            panel2.user2();
            panel2.user3();
        }

        private void btnSearchType_Click(object sender, RoutedEventArgs e)
        {
            s0.Opacity = 0;
            s1.Opacity = 0;
            s2.Opacity = 0;
            s3.Opacity = 100;
            s4.Opacity = 0;
            s3.Height = btnSearchType.Height;
            panel1.Visibility = Visibility.Collapsed;
            panel2.Visibility = Visibility.Collapsed;
            panel3.Visibility = Visibility.Visible;
            panel4.Visibility = Visibility.Collapsed;
            panel3.r5.Visibility = Visibility.Hidden;

            panel3.user5();
        }

        private void btnSearchDate_Click(object sender, RoutedEventArgs e)
        {
            s0.Opacity = 0;
            s1.Opacity = 0;
            s2.Opacity = 0;
            s3.Opacity = 0;
            s4.Opacity = 100;
            s4.Height = btnSearchDate.Height;
            panel1.Visibility = Visibility.Collapsed;
            panel2.Visibility = Visibility.Collapsed;
            panel3.Visibility = Visibility.Collapsed;
            panel4.Visibility = Visibility.Visible;
            panel4.r6.Visibility = Visibility.Visible;

            panel4.r6.Visibility = Visibility.Hidden;
            panel4.user6();
        }

        private void btnBackStat_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Page1());
            panel1.Visibility = Visibility.Visible;
            panel3.Visibility = Visibility.Collapsed;
            panel2.Visibility = Visibility.Collapsed;
            panel4.Visibility = Visibility.Collapsed;
        }
    }
}
