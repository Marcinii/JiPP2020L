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
    /// Logika interakcji dla klasy RateMe.xaml
    /// </summary>
    public partial class RateMe : UserControl
    {
        public RateMe()
        {
            InitializeComponent();
        }

        private int valueOfRate = 0;

        public event EventHandler<RateEventArgs> RateValueChanged;

        public int RateValue
        {
            get { return valueOfRate; }
            set 
            { 
                valueOfRate = value;
                UpdateButtons();

                if (RateValueChanged != null)
                {
                    RateValueChanged(this, new RateEventArgs() { Value = valueOfRate });
                }
               
            }
        }

        static int oldrate = 0;
        static int licznik = 0;

        private void UpdateButtons()
        {
            foreach(var b in starGrid.Children)
            {
                ((Button)b).Background = new SolidColorBrush(Colors.CornflowerBlue);
            }

            if(valueOfRate > 0)
            {
                int a = valueOfRate;
                while (a > 0) { 
                ((Button)starGrid.Children[a - 1]).Background = new SolidColorBrush(Colors.Gold);
                    a--;
                }
            } 
            if (oldrate == valueOfRate)
            {
                int a = valueOfRate;
                while (a > 0)
                {
                    ((Button)starGrid.Children[a - 1]).Background = new SolidColorBrush(Colors.CornflowerBlue);
                    a--;
                }
                licznik++;
            }
            if(licznik > 0)
            {
                oldrate = 0;
                licznik = 0;
            } else
            {
                oldrate = valueOfRate;
            }
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RateValue = starGrid.Children.IndexOf((Button)sender) + 1;
        }

        
    }
    public class RateEventArgs: EventArgs
    {
        public int Value { get; set; }
    }
}
