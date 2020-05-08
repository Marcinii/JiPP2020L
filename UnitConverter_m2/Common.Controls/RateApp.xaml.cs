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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Common.Controls
{
    /// <summary>
    /// Interaction logic for RateApp.xaml
    /// </summary>
    public partial class RateApp : UserControl
    {
        public RateApp()
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
                if (value < 0 || value > 5) throw new System.ArgumentException("Ocena moze byc w przedziale tylko 0-5!", "value"); 


                /* jesli kliknieto znowu to samo, ustawiana jest wartosc 0,
                 * czyli brak oceny */
                if (value == _rateValue)
                    _rateValue = 0;
                else
                    _rateValue = value;

                UpdateButtons();

                if (RateValueChanged != null)
                {
                    RateValueChanged(this, new RateEventArgs() { Value = _rateValue });
                }
            }
        }

        private void UpdateButtons()
        {
            int i = 1;
            foreach (var b in ratesGrid.Children)
            {
                if (i <= _rateValue && _rateValue != 0)
                    ((Button)b).Background = new SolidColorBrush(Colors.Blue);
                else
                    ((Button)b).Background = new SolidColorBrush(Colors.White);
                i++;
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

