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
    /// Logika interakcji dla klasy UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
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
                _rateValue = value;
                if(value >= 0 && value < 5)
                {
                    updateButtons();
                    if (RateValueChanged != null)
                    {
                        RateValueChanged(this, new RateEventArgs() { Value = _rateValue });
                    }
                }

            }
        }

        private void updateButtons()
        {
            foreach(var button in ratesGrid.Children)
            {
                ((Button) button).Background = new SolidColorBrush(Colors.White);
            }

            if(_rateValue > 0)
            {
                for(int i=0; i<_rateValue; i++)
                {
                    ((Button)ratesGrid.Children[i]).Background = new SolidColorBrush(Colors.Yellow);
                }
            }
        }

        private void Button_Click(Object sender, RoutedEventArgs e)
        {
            RateValue = ratesGrid.Children.IndexOf((Button)sender) + 1;
        }

    }

    public class RateEventArgs : EventArgs
    {
        public int Value { get; set; }
    }
}
