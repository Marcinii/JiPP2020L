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
                //sprawdzac czy wartosc jes poprawana 0-5
                if( !(value >= 0 && value <= 5))
                {
                    throw new ArgumentOutOfRangeException("value", "błąd");
                }
                _rateValue = value;
                
                UpdateButtons();

                if(RateValueChanged != null)
                {
                    RateValueChanged(this, new RateEventArgs() { Value = _rateValue });
                }
                
            }
        }

        private void UpdateButtons()
        {
            foreach(var b in ratesGrid.Children)
            {
                ((Button)b).Background = new SolidColorBrush(Colors.White);
            }

            if(_rateValue > 0)
            {
                ((Button)ratesGrid.Children[_rateValue - 1]).Background = new SolidColorBrush(Colors.Orange);
                
                for (int i = _rateValue; i < 5; i++)
                {
                    ((Button)ratesGrid.Children[i]).Background = new SolidColorBrush(Colors.White);
                }
                for (int j = 0; j < _rateValue; j++)
                {
                    ((Button)ratesGrid.Children[j]).Background = new SolidColorBrush(Colors.Orange);
                }
            }
        }

        public void Remove()
        {
            foreach(var a in ratesGrid.Children)
            {
                ((Button)a).Background = new SolidColorBrush(Colors.White);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RateValue = ratesGrid.Children.IndexOf((Button)sender) + 1;
        }
    }

    public class RateEventArgs: EventArgs
    {
        public int Value { get; set; }
    }
}
