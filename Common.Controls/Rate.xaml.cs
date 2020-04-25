using System;
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
                    UpdateStars(_rateValue);             
                }   
            }
        }
        public Rate()
        {
            InitializeComponent();

            RateAppCommand = new RelayCommand((object sender) => RateApp(sender));

            FirstStarButton.Command = RateAppCommand;
            FirstStarButton.CommandParameter = FirstStarButton;

            SecondStarButton.Command = RateAppCommand;
            SecondStarButton.CommandParameter = SecondStarButton;

            ThirdStarButton.Command = RateAppCommand;
            ThirdStarButton.CommandParameter = ThirdStarButton;

            FourthStarButton.Command = RateAppCommand;
            FourthStarButton.CommandParameter = FourthStarButton;

            FifthStarButton.Command = RateAppCommand;
            FifthStarButton.CommandParameter = FifthStarButton;
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

        public RelayCommand RateAppCommand;
        private void RateApp(object sender)
        {       
            RateValue = StarsGrid.Children.IndexOf((Button)sender) + 1;
            RateValueChanged(this, new RateEventArgs(RateValue));
        }

        private void UpdateStars(int rating)
        {
            foreach (var b in StarsGrid.Children)
            {
                ((Button)b).Background = new SolidColorBrush(Colors.White);
            }

            foreach (var b in StarsGrid.Children)
            {
                if (StarsGrid.Children.IndexOf((Button)b) == rating) break;

                ((Button)b).Background = new SolidColorBrush(Colors.Yellow);
            }
        }
    }
}
