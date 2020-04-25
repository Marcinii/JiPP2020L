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
using application;
using stars;


namespace application
{

    public partial class Page0 : Page
    {
        public Page0()
        {
            InitializeComponent();
            _timer.Interval = TimeSpan.FromSeconds(0.2);
            _timer.Tick += Timer_Tick;

        }

    

        private readonly System.Windows.Threading.DispatcherTimer _timer = new System.Windows.Threading.DispatcherTimer();
        private void Timer_Tick(object sender, EventArgs e)
        {
            _timer.Stop();
        }

        public SizeToContent SizeToContent { get; }

        private void clockButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Page3());

        }

        private void converterButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Page1());

        }

        private void rateControl_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void rateControl_RateValueChanged(object sender, UserControl1.RateEventArgs e)
        {

        }
    }
}
