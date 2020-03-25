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

namespace Konwerter.GUI
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

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            TextBlock1.Text = KonwerterJednostek.Logic.Dispatcher.ConvertWithDispatch("c", "f", double.Parse(TextBox1.Text)).ToString();
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            TextBlock2.Text = KonwerterJednostek.Logic.Dispatcher.ConvertWithDispatch("f", "c", double.Parse(TextBox2.Text)).ToString();

        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            TextBlock3.Text = KonwerterJednostek.Logic.Dispatcher.ConvertWithDispatch("kg", "lb", double.Parse(TextBox3.Text)).ToString();

        }

        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            TextBlock4.Text = KonwerterJednostek.Logic.Dispatcher.ConvertWithDispatch("lb", "kg", double.Parse(TextBox4.Text)).ToString();

        }

        private void Button5_Click(object sender, RoutedEventArgs e)
        {
            TextBlock5.Text = KonwerterJednostek.Logic.Dispatcher.ConvertWithDispatch("km", "mil", double.Parse(TextBox5.Text)).ToString();

        }

        private void Button6_Click(object sender, RoutedEventArgs e)
        {
            TextBlock6.Text = KonwerterJednostek.Logic.Dispatcher.ConvertWithDispatch("mil", "km", double.Parse(TextBox6.Text)).ToString();

        }
        private void Button7_Click(object sender, RoutedEventArgs e)
        {
            TextBlock7.Text = KonwerterJednostek.Logic.Dispatcher.ConvertWithDispatch("Pa", "hPa", double.Parse(TextBox7.Text)).ToString();

        }

        private void Button8_Click(object sender, RoutedEventArgs e)
        {
            TextBlock8.Text = KonwerterJednostek.Logic.Dispatcher.ConvertWithDispatch("hPa", "Pa", double.Parse(TextBox8.Text)).ToString();

        }

        private void TButton24_Click(object sender, RoutedEventArgs e)
        {
            TBlock24.Text = (string) KonwerterJednostek.Logic.Dispatcher.ConvertWithDispatch("T24", "T12", TBox24.Text);
        }

        private void TButton12_Click(object sender, RoutedEventArgs e)
        { 
            TBlock12.Text = (string) KonwerterJednostek.Logic.Dispatcher.ConvertWithDispatch("T12", "T24", TBox12.Text);
        }
    }
}
