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

namespace Statistic.Controls
{
    /// <summary>
    /// Logika interakcji dla klasy OcenMnie.xaml
    /// </summary>
    public partial class OcenMnie : UserControl
    {
        public OcenMnie()
        {
            InitializeComponent();
        }
        private int _rateValue = 0;
        public event ratedelegate RateValueChanged;
        public int rateValue
        {
            get { return _rateValue; }
            set {

                _rateValue = value;

                UpdateButton();
                RateValueChanged?.Invoke(_rateValue);
            }
            
        }
        private void downgrade()
        {
            foreach(var b in rateGrid.Children)
            {
                ((Button)b).Background = new SolidColorBrush(Colors.White);
            }

            _rateValue = 0;
        }

        private void UpdateButton()
        {
            foreach(var b in rateGrid.Children)
            {
                ((Button)b).Background = new SolidColorBrush(Colors.White);
            }
            if (_rateValue >0)
            {
                var point = _rateValue;
                
                for(var i = 0; i < point ; i++)
                {
                    
                        ((Button)rateGrid.Children[i]).Background = new SolidColorBrush(Colors.Green);

                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (_rateValue > 0)
            {
                downgrade();
            }
            else
            {
                rateValue = rateGrid.Children.IndexOf((Button)sender) + 1;
            }
        }

        public delegate void ratedelegate(int value);
    }
}
