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

namespace OcenaApki2
{
    /// <summary>
    /// Interaction logic for Rate.xaml
    /// </summary>
    public partial class Rate : UserControl
    {
        public Rate()
        {
            InitializeComponent();
        }

        private int _RateValue = 0;

        public int RateValue
        {
            get { return _RateValue; }
            set 
            { 
                _RateValue = value;
                UpdateButton();
            }
        }

        private void UpdateButton()
        {
            foreach(var b in RatesGrid.Children)
            {
                ((Button)b).Background = new SolidColorBrush(Colors.White);
            }

            if (_RateValue > 0)
            {
                ((Button)RatesGrid.Children[_RateValue - 1]).Background = new SolidColorBrush(Colors.Blue);
            }
        }

        private void ElipsaButtonClick(object sender, RoutedEventArgs e)
        {
            RateValue = RatesGrid.Children.IndexOf((Button)sender) + 1;
        }
    }
}
