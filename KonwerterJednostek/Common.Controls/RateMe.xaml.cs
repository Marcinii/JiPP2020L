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
    /// Interaction logic for RateMe.xaml
    /// </summary>
    public partial class RateMe : UserControl
    {
        public RateMe()
        {
            InitializeComponent();
        }

        private int _rateValue=0;

        public int RateValue
        {
            get { return _rateValue; }
            set 
            {
                //powinnismy sprawdzac czy wartosc jest poprawna (0-5)
                //jesli nie, to powinien byc rzucany wyjatek
                _rateValue = value;

                UpdateButtons();
            }
        }

        //odznaczanie przycisku!
        private void UpdateButtons()
        {
            foreach(var b in ratesGrid.Children)
            {
                ((Button)b).Background = new SolidColorBrush(Colors.White);
            }
            if (_rateValue > 0)
            {
                ((Button)ratesGrid.Children[_rateValue - 1]).Background = new SolidColorBrush(Colors.Blue);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RateValue = ratesGrid.Children.IndexOf((Button)sender) + 1;
        }
    }
}
