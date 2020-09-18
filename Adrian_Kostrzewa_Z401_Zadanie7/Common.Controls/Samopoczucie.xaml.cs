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

namespace Common.Controls
{
    /// <summary>
    /// Interaction logic for Samopoczucie.xaml
    /// </summary>
    public partial class Samopoczucie : UserControl
    {
        public Samopoczucie()
        {
            InitializeComponent();
        }

        private void b4_Click(object sender, RoutedEventArgs e)
        {
            s2.Content = "Kocham SI SZARPA !!! :))";
            var bc = new BrushConverter();
            s2.Background = (Brush)bc.ConvertFrom("#FF7FFA90");
        }

        private void b3_Click(object sender, RoutedEventArgs e)
        {
            s2.Content = "Tak średnio bym powiedział.";
            var bc = new BrushConverter();
            s2.Background = (Brush)bc.ConvertFrom("#FF7FFAD6");
        }

        private void b2_Click(object sender, RoutedEventArgs e)
        {
            s2.Content = "Wakacje się skończyły...";
            var bc = new BrushConverter();
            s2.Background = (Brush)bc.ConvertFrom("#FFFAD366");
        }

        private void b1_Click(object sender, RoutedEventArgs e)
        {
            s2.Content = "Życie jest takie trudne ;(( !";
            var bc = new BrushConverter();
            s2.Background = (Brush)bc.ConvertFrom("#FFFA5A83");
        }
    }
}
