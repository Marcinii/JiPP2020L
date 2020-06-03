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

namespace RateUs
{
    /// <summary>
    /// Interaction logic for RateUs.xaml
    /// </summary>
    public partial class RateUs : UserControl
    {
        public event EventHandler<RateEventArgs> OnRateValue;

        private int _rateValue;

        public int RateValue
        {
            get
            {
                return _rateValue;
            }
            set
            {
                _rateValue = value;
                SetupButtons();
                if (OnRateValue != null)
                {
                    OnRateValue(this, new RateEventArgs() { Value = value });
                }
            }
        }

        public RateUs()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            RateValue = Buttons.Children.IndexOf(button) + 1;
        }

        private void SetupButtons()
        {
            foreach (Button b in Buttons.Children)
            {
                b.Background = new SolidColorBrush(Colors.White);
            }

            for (int i = 0; i < RateValue; i++)
            {
                Button b = (Button)Buttons.Children[i];
                b.Background = new SolidColorBrush(Colors.DeepPink);
            }
        }

        public class RateEventArgs : EventArgs
        {
            public int Value;
        }
    }
}
