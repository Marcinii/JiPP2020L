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
    /// Interaction logic for Rate.xaml
    /// </summary>
    public partial class Rate : UserControl
    {
        public int RateValue { get; set; }
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
            foreach (var b in StarsGrid.Children)
            {
                ((Button)b).Background = new SolidColorBrush(Colors.White);
            }

            foreach (var currentButton in StarsGrid.Children)
            {
                if (StarsGrid.Children.IndexOf((Button)currentButton) > StarsGrid.Children.IndexOf((Button)sender)) break;

                ((Button)currentButton).Background = new SolidColorBrush(Colors.Yellow);
            }

            RateValue = StarsGrid.Children.IndexOf((Button)sender) + 1;
            RateValueChanged(this, new RateEventArgs(RateValue));
        }
    }
}
