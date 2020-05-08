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

        private int rateValue=0;

        public event EventHandler<RateEventArgs> RateValueChanged;

        public int RateValue
        {
            get { return rateValue; }
            set
            {
                if (value < 1 || value > 5)
                {
                    value = 1;
                }
                rateValue = value;
                updateButtons();

                if (RateValueChanged != null)
                {
                    RateValueChanged(this, new RateEventArgs() { value = rateValue });
                }
            }
        }

        private void updateButtons()
        {
            foreach(var btn in ratesGrid.Children)
            {
                ((Button)btn).Background = new SolidColorBrush(Colors.White);

            }
            if (rateValue > 0)
            {
                for (int i = 0; i < rateValue; i++)
                {
                    ((Button)ratesGrid.Children[i]).Background = new SolidColorBrush(Colors.Blue);
                }
            }            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RateValue = ratesGrid.Children.IndexOf((Button)sender) + 1;
        }
        
    }

    public class RateEventArgs: EventArgs
    {
        public int value { get; set; }
    }
}
