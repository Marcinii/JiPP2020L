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

namespace rateMe
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
        public int rateValue = 0;

        public event ratedelegate RateValueChanged;

        public int rateMe
        {
            get { return rateValue; }
            set
            {
                rateValue = value;

                UpdateRate();
                if(RateValueChanged != null)
                {
                    RateValueChanged(rateValue);
                }
            }
        }
        private void UpdateRate()
        {
            foreach (var b in rateMeGrid.Children)
            {
                ((Button)b).Background = new SolidColorBrush(Colors.White);
            }
            if (rateValue > 0)
            {
                for(int i =0; i< rateValue; i++)
                {
                    ((Button)rateMeGrid.Children[i]).Background = new SolidColorBrush(Colors.Green);
                }
            }
        }
        private void DownRate()
        {
            foreach (var b in rateMeGrid.Children)
            {
                ((Button)b).Background = new SolidColorBrush(Colors.White);
            }
            rateValue = 0;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (rateValue > 0)
            {
                DownRate();
            }
            else
            {
                rateValue = rateMeGrid.Children.IndexOf((Button)sender) + 1;
            }
        }
        public delegate void ratedelegate(int value);
    }
}
