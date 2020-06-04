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

namespace Calendar
{
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent(); mainFrame.Content = new LandingPage();
            Loaded += startWindow;
        }


        private void startWindow(object sender, RoutedEventArgs e)
        {
            mainFrame.NavigationService.Navigate(new LandingPage());
        }


        private void Frame_Navigated(object sender, NavigationEventArgs e)
        {
            mainFrame.NavigationService.Navigate(new LandingPage());
        }


    }
}
