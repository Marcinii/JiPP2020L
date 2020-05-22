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
    /// Interaction logic for RateMe.xaml
    /// </summary>
    public partial class RateMe : UserControl
    {
        public RateMe()
        {
            InitializeComponent();
        }

        private int _rateValue = 0;

        public event EventHandler<RateEventArgs> RateValueChanged;

        public int RateValue
        {
            get { return _rateValue; }
            set 
            {
                if (value < 0 || value > 5)
                {
                    throw new ArgumentOutOfRangeException("value", "0/1/2/3/4/5");
                }
                _rateValue = value;
                UpdateButtons();

                if (RateValueChanged != null)
                {
                    RateValueChanged(this, new RateEventArgs() { Value = _rateValue });
                }
            }
        }
        public void Odznacz()
        {
            foreach (var b in ratesGrid.Children)
            {
                ((Button)b).Background = new SolidColorBrush(Colors.White);
            }
        }
        private void UpdateButtons()
        {
            foreach(var b in ratesGrid.Children)
            {
                ((Button)b).Background = new SolidColorBrush(Colors.White);
            }

            if (_rateValue > 0)
            {
                ((Button)ratesGrid.Children[_rateValue - 1]).Background = new SolidColorBrush(Colors.Blue);
                for (int k = _rateValue; k < 5; k++)
                {
                    ((Button)ratesGrid.Children[k]).Background = new SolidColorBrush(Colors.White);
                }
                for (int k = 0; k < _rateValue - 1; k++)
                {
                    ((Button)ratesGrid.Children[k]).Background = new SolidColorBrush(Colors.Blue);
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RateValue = ratesGrid.Children.IndexOf((Button)sender) + 1;
        }
    }
    public class RateEventArgs : EventArgs
    {
        public int Value { get; set; }
    }
}
