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

namespace Controls
{
    /// <summary>
    /// Interaction logic for RateMe.xaml
    /// </summary>
    public partial class RateMe : UserControl
    {
        private int _rateValue;

        public int RateValue
        {
            get { return _rateValue; }
            set { 
                _rateValue = value;
                UpdateButtons();
                if(OnRateChanged != null)
                {
                    OnRateChanged(_rateValue);
                }
            }
        }

        public event RateDelegate OnRateChanged;

        private void UpdateButtons()
        {
            foreach(Button b in rateGrid.Children)
            {
                b.Background = new SolidColorBrush(Colors.White);
            }

            for(int i = 0; i < _rateValue; i++)
            {
                Button b = rateGrid.Children[i] as Button;
                b.Background = new SolidColorBrush(Colors.Green);
            }
        }

        public RateMe()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RateValue = rateGrid.Children.IndexOf((Button)sender) + 1;
        }

        public delegate void RateDelegate(int value);
    }
}
