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

namespace common.controls
{
    /// <summary>
    /// Logika interakcji dla klasy ocena.xaml
    /// </summary>
    public partial class ocena : UserControl
    {
        public ocena()
        {
            InitializeComponent();
        }

        private int _rateValue;

        public event RateDelegate RateValueChange;

        public int RateValue
        {
            get { return _rateValue; }
            set {
                if (_rateValue >= 0 || _rateValue <= 5)
                {
                    _rateValue = value;
                    UpdateButtons();

                    if (RateValueChange != null)
                    {
                        RateValueChange(_rateValue);
                    }
                }
                else { }


            }
        }

        private void UpdateButtons()
        {
         
            
                foreach (var b in rategwiazdki.Children)
                {
                    ((Button)b).Background = new SolidColorBrush(Colors.Black);
                }


                for (int i = 0; i <= _rateValue - 1; i++)
                {
                    ((Button)rategwiazdki.Children[i]).Background = new SolidColorBrush(Colors.Yellow);

                }
            
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RateValue = rategwiazdki.Children.IndexOf((Button)sender) + 1;

        }


        public delegate void RateDelegate(int value);

    }
}
