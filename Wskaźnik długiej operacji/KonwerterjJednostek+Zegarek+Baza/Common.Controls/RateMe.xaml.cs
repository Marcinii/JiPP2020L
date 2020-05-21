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

        private int _RateValue = 0;

        public event EventHandler<RateEventArgs> RateValueChanged;
        public event EventHandler<RateEventArgs> costam;

        public int RateValue
        {
            get { return _RateValue; }  
            set 
            { 
                //if (value<1 && value>5)
                //{
                    _RateValue = value;
                    UpdateButtons();

                    if (RateValueChanged != null)
                    {
                        RateValueChanged(this, new RateEventArgs() { Value = _RateValue });
                    }
                //}
            }            
        }

        private void UpdateButtons()
        {
            foreach (var b in RateGrid.Children)
            {
                ((Button)b).Background = new SolidColorBrush(Colors.White);
            }

            if (_RateValue>0)
            {
                ((Button)RateGrid.Children[_RateValue - 1]).Background = new SolidColorBrush(Colors.Blue);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RateValue = RateGrid.Children.IndexOf((Button)sender) + 1;
        }

        //public delegate void RateDelegate(int value);
        public class RateEventArgs: EventArgs
        {
            public int Value { get; set; }
        }
            
    }
}
