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
    /// Interaction logic for Rate.xaml
    /// </summary>
    public partial class Rate : UserControl
    {
        public Rate()
        {
            InitializeComponent();
        }

        private int _rateValue=0;

        public int RateValue
        {
            get { return _rateValue; }
            set
            {
                if (!(value >= 0 && value <= 3))
                {
                    throw new ArgumentOutOfRangeException("value", "Value must be: 0, 1, 2, 3, 4 or 3.");
                }

                _rateValue = value;

                UpdateButtons();
            }
        }

        private void UpdateButtons()
        {
            foreach(var b in ratesGrid.Children)
            {
                ((Button)b).Background = new SolidColorBrush(Colors.LightGray);
            }

            if (_rateValue > 0)
            {
                //((Button)ratesGrid.Children[_rateValue - 1]).Background = new SolidColorBrush(Colors.Blue);
                switch (_rateValue)
                {
                    case 1:
                        ((Button)ratesGrid.Children[0]).Background = new SolidColorBrush(Colors.Red);
                        break;
                    case 2:
                        ((Button)ratesGrid.Children[0]).Background = new SolidColorBrush(Colors.Yellow);
                        ((Button)ratesGrid.Children[1]).Background = new SolidColorBrush(Colors.Yellow);
                        break;
                    case 3:
                        ((Button)ratesGrid.Children[0]).Background = new SolidColorBrush(Colors.LightGreen);
                        ((Button)ratesGrid.Children[1]).Background = new SolidColorBrush(Colors.LightGreen);
                        ((Button)ratesGrid.Children[2]).Background = new SolidColorBrush(Colors.LightGreen);
                        break;
                }
            }
            else
            {
                foreach (var b in ratesGrid.Children)
                {
                    ((Button)b).Background = new SolidColorBrush(Colors.LightGray);
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(RateValue != ratesGrid.Children.IndexOf((Button)sender) + 1)
            {
                RateValue = ratesGrid.Children.IndexOf((Button)sender) + 1;
            }
            else { RateValue = 0; }
        }
    }
}
