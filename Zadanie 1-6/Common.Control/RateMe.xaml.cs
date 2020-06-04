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

namespace Common.Control
{
    /// <summary>
    /// Logika interakcji dla klasy RateMe.xaml
    /// </summary>
    public partial class RateMe : UserControl
    {
        public RateMe()
        {
            InitializeComponent();
        }
        private int _rateValue = 0;
        public event EventHandler<EventArgs> RateValueChanged;

        public int RateValue
        {
            get { return _rateValue; }
            set 
            { 
                _rateValue = value;

                updateButton();
               if(RateValueChanged != null)
                {
                    RateValueChanged(this,new RateEventArgs() { value = _rateValue });
                }
            }
        }
        private void updateButton()
        {
            foreach (var b in Ocena.Children)
            {
                ((Button)b).Background = new SolidColorBrush(Colors.White);
            }
            for (int i = 0; i <= _rateValue; i++) { 
            if (_rateValue >= 0)
            {
                ((Button)Ocena.Children[i]).Background = new SolidColorBrush(Colors.Gold);
            }
        }

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RateValue = Ocena.Children.IndexOf((Button)sender);
        }

    }
    public class RateEventArgs: EventArgs
    {
        public int value { get; set; }
    }
}
