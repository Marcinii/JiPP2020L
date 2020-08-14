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

namespace UnitConverter.Desktop
{
    /// <summary>
    /// Logika interakcji dla klasy UserRate.xaml
    /// </summary>
    public partial class UserRate : UserControl
    {
        public UserRate()
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

                Button_Update();

                if(RateValueChanged != null)
                {
                    RateValueChanged(this, new RateEventArgs() { Value = _rateValue });
                }
            }

        }

        private void Button_Update() 
        {
            foreach(var b in RateGrid.Children)
            {
                ((Button)b).Background = new SolidColorBrush(Colors.White);
            }

            if(_rateValue > 0)
            {
                ((Button)RateGrid.Children[_rateValue - 1]).Background = new SolidColorBrush(Colors.Gold);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RateValue = RateGrid.Children.IndexOf((Button)sender) + 1;
        }
    }

    public class RateEventArgs : EventArgs
    {
        public int Value { get; set; }
    }
}
