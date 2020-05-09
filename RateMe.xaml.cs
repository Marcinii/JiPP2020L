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
                //powinnismy sprawdzac czy wartosc jest poprawna (0-5)
                //jesli nie, to powinien byc rzucany wyjatek
                if (!(value >= 0 && value <= 5))
                {
                    throw new ArgumentOutOfRangeException("value", "Value must be: 0, 1, 2, 3, 4 or 5.");
                }
                _rateValue = value;

                UpdateButtons();

                if (RateValueChanged != null)
                {
                    RateValueChanged(this, new RateEventArgs() { Value = _rateValue });
                }
            }
        }

        //odznaczanie przycisku!
        private void UpdateButtons()
        {
            foreach (var b in ratesGrid.Children)
            {
                ((Button)b).Background = new SolidColorBrush(Colors.White);
            }
            if (_rateValue > 0)
            {
                ((Button)ratesGrid.Children[_rateValue - 1]).Background = new SolidColorBrush(Colors.Gold);
                for (int i = 1; i < _rateValue; i++)
                {
                    ((Button)ratesGrid.Children[i - 1]).Background = new SolidColorBrush(Colors.Gold);
                }
            }
            else
            {
                foreach (var b in ratesGrid.Children)
                {
                    ((Button)b).Background = new SolidColorBrush(Colors.White);
                }
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (RateValue != ratesGrid.Children.IndexOf((Button)sender) + 1)
            {
                RateValue = ratesGrid.Children.IndexOf((Button)sender) + 1;
            }
            else { RateValue = 0; }
        }

        //public delegate void RateDelegate(int value);
        public class RateEventArgs : EventArgs
        {
            public int Value { get; set; }
        }

    }
}