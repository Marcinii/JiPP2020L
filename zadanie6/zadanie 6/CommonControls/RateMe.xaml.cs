using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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

namespace CommonControls
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

        private int _rateValue;
       
        public event EventHandler<RateEventArgs> RateValueChanged;

        public int RateValue
        {
            get
            {
                return _rateValue;
            }
            set
            {
               
               
                if (_rateValue == value) {

                    _rateValue = 0;
                }
                else {
                    _rateValue = value;
                    
                    if (RateValueChanged != null)
                    {
                        RateValueChanged(this, new RateEventArgs() { Value = _rateValue });
                    }
                }
                UpdateButtons();
            }
        }

        private void UpdateButtons()
        {
            foreach (var b in starGrid.Children)
            {
                ((Button)b).Background = new SolidColorBrush(Colors.White);
            }
            for (int i = 0; i < _rateValue; i++)
            {
                if (_rateValue > 0)
                {
                    ((Button)starGrid.Children[i]).Background = new SolidColorBrush(Colors.Gold);
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            RateValue = starGrid.Children.IndexOf((Button)sender) + 1;
            

        }

        public class RateEventArgs : EventArgs { 
            public int Value { get; set; }
        }

        
        
    }
}
