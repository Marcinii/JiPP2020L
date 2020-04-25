using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Common.Controls
{
    /// <summary>
    /// Interaction logic for Rate.xaml
    /// </summary>
    public partial class Rate : UserControl
    {
        private int _rateValue;

        public int RateValue { 
            get { return _rateValue; } 
            set
            {
                if (value > 0 && value <= 5)
                {
                    _rateValue = value;
                    ClearStarsRating();
                    SetStarsRating(_rateValue);
                }   
            }
        }
        public Rate()
        {
            InitializeComponent();
        }

        public event EventHandler<RateEventArgs> RateValueChanged;
        public class RateEventArgs: EventArgs
        {
            private readonly int _value;
            public RateEventArgs(int value)
            {
                _value = value;
            }
            public int Value   
            {
                get { return _value; }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RateValue = StarsGrid.Children.IndexOf((Button)sender) + 1;
            RateValueChanged(this, new RateEventArgs(RateValue));
        }

        private void ClearStarsRating()
        {
            foreach (var b in StarsGrid.Children)
            {
                ((Button)b).Background = new SolidColorBrush(Colors.White);
            }
        }

        private void SetStarsRating(int rating)
        {
            foreach (var currentButton in StarsGrid.Children)
            {
                if (StarsGrid.Children.IndexOf((Button)currentButton) == rating) break;

                ((Button)currentButton).Background = new SolidColorBrush(Colors.Yellow);
            }
        }
    }
}
