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

namespace Common.Controls7
{
    /// <summary>
    /// Logika interakcji dla klasy Kontrolka7.xaml
    /// </summary>
    public partial class Kontrolka7 : UserControl
    {
        public Kontrolka7()
        {
            InitializeComponent();
        }


        private int _rateValue = 0;

        public event EventHandler<RateEventArgs> RateValueChanged;

        public int RateValue
        {
            get { return _rateValue; }
            set
            {
                if (value < 1 && value > 3)
                {
                    MessageBox.Show("Nieprawidłowa wartość");
                }
                else
                {
                    _rateValue = value;

                    UpdateButtons();
                }

                if (RateValueChanged != null)
                {
                    RateValueChanged(this, new RateEventArgs() { Value = _rateValue });
                }
            }
        }

        //odznaczanie przycisku!
        private void UpdateButtons()
        {
            foreach (var b in ratesGrid.Children)
            {
                ((Button)b).Background = new SolidColorBrush(Colors.Orange);
            }
            if (_rateValue > 0)
            {
                ((Button)ratesGrid.Children[_rateValue - 1]).Background = new SolidColorBrush(Colors.Red);
                for (int i = 1; i < _rateValue; i++)
                {
                    ((Button)ratesGrid.Children[i - 1]).Background = new SolidColorBrush(Colors.Red);
                }
            }
            else
            {
                foreach (var b in ratesGrid.Children)
                {
                    ((Button)b).Background = new SolidColorBrush(Colors.Orange);
                }
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (RateValue != ratesGrid.Children.IndexOf((Button)sender) + 1)
            {
                RateValue = ratesGrid.Children.IndexOf((Button)sender) + 1;
            }
            else { RateValue = 0; }
        }

        //public delegate void RateDelegate(int value);
        public class RateEventArgs : EventArgs
        {
            public int Value { get; set; }
        }


    }
}
