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

namespace UC_01
{
    /// <summary>
    /// Logika interakcji dla klasy szachy.xaml
    /// </summary>
    public partial class szachy : UserControl
    {
        public szachy()
        {
            InitializeComponent();
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://memy.pl/show/big/uploads/Post/203016/15232084880351.jpg");
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://i1.kwejk.pl/k/obrazki/2018/09/W0doDfrUKN5q68E3.jpg");
        }

        private void Button_Click3(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.xdpedia.com/obrazki/przygody_programistow_43786.jpg");
        }


    }




}
