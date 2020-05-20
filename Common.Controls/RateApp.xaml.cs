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
    /// Logika interakcji dla klasy RateApp.xaml
    /// </summary>
    public partial class RateApp : UserControl
    {
        public RateApp()
        {
            InitializeComponent();
        }
        public event EventHandler<RateEventArgs> RateValueChanged;

        private int _rateValue = 0;

        public int RateValue
        {
            get { return _rateValue; }
            set
            {
                if (value >= 1 && value <= 5)
                {
                    _rateValue = value;
                }else
                {
                    _rateValue = 0;
                }
                UpdateButtons(_rateValue);

                if (RateValueChanged != null)
                {
                    RateValueChanged(this, new RateEventArgs() {RateValue = _rateValue });
                }
            }
        }

        private void UpdateButtons(int _rateValue)
        {
            int i = 0;
            foreach(var b in ratesGrid.Children)
            {
                if (i < _rateValue)
                {
                    ((Button)b).Background = new SolidColorBrush(Colors.Yellow);
                }else
                {
                    ((Button)b).Background = new SolidColorBrush(Colors.LightGray);
                }
                i++;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e) 
        {
            RateValue = ratesGrid.Children.IndexOf((Button)sender) + 1;
            
        }

        public class RateEventArgs : EventArgs
        {
            public int RateValue { get; set; }
        }

    }
}
