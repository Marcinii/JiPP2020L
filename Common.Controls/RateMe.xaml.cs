using System;

using System.Windows.Controls;

using System.Windows.Media;


namespace Common.Controls
{
    /// <summary>
    /// Logika interakcji dla klasy Ocena.xaml
    /// </summary>
    public partial class RateMe : UserControl
    {
        private int ocena;

        public int RateValue
        {
            get { return ocena; }
            set
            {
                if (value > 0 && value <= 5)
                {
                    ocena = value;
                    UpdateStars(ocena);
                }
            }
        }
        public RateMe()
        {
            InitializeComponent();

            RateAppCommand = new RelayCommand((object sender) => RateApp(sender));

            button_star_1.Command = RateAppCommand;
            button_star_1.CommandParameter = button_star_1;

            button_star_2.Command = RateAppCommand;
            button_star_2.CommandParameter = button_star_2;

            button_star_3.Command = RateAppCommand;
            button_star_3.CommandParameter = button_star_3;

            button_star_4.Command = RateAppCommand;
            button_star_4.CommandParameter = button_star_4;

            button_star_5.Command = RateAppCommand;
            button_star_5.CommandParameter = button_star_5;
        }

        public event EventHandler<RateEventArgs> RateValueChanged;
        public class RateEventArgs : EventArgs
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