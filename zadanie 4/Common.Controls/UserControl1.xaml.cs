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
    /// Logika interakcji dla klasy UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }
        private int _Ratevalue = 0;
        public int Rate
        {
            get { return _Ratevalue; }
            set
            {
                _Ratevalue = value;

                updatebuttons();
                if (RateValueChanged != null)
                {
                    RateValueChanged(this, new RateEventArgs() { Value = _Ratevalue });
                }
            }
        }
        public event EventHandler<RateEventArgs> RateValueChanged;
        private void updatebuttons()
        {
            foreach(var b in ratesGrid.Children)
            {
                ((Button)b).Background = new SolidColorBrush(Colors.White);
            }
            if (_Ratevalue > 0)
            {
                for (int i = 0; i < _Ratevalue; i++)
                {
                    ((Button)ratesGrid.Children[i]).Background = new SolidColorBrush(Colors.Yellow);

                }
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Rate = ratesGrid.Children.IndexOf((Button)sender) + 1;
        }
        
    }
    public class RateEventArgs : EventArgs
    {
        public int Value { get; set; }
    }
}
