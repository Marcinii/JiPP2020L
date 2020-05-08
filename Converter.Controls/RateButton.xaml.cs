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

namespace Converter.Controls
{
    /// <summary>
    /// Logika interakcji dla klasy RateButton.xaml
    /// </summary>
    public partial class RateButton : UserControl
    {
        private int _rate = 0;

        public RateButton()
        {
            InitializeComponent();
        }

        public event EventHandler<RateArgs> RateChanged;
        public int RateV
        {
            get { return _rate; }
            set {
                if (value >= 0 && value < 6)
                {
                    _rate = value;
                    UpdateButton();
                    if (RateChanged != null) RateChanged(this, new RateArgs() { Value = _rate });
                }
            }
        }

        private void UpdateButton()
        {
            for(int i = 0; i < rateGrid.Children.Count; i++)
            {
                if (i < RateV)
                {
                    ((Button)rateGrid.Children[i]).Background = new SolidColorBrush(Colors.Yellow);
                }
                else
                {
                    ((Button)rateGrid.Children[i]).Background = new SolidColorBrush(Colors.White);
                }
            }
        }

        private void Clicked(object sender, RoutedEventArgs e)
        {
            if (RateV == rateGrid.Children.IndexOf((Button)sender) + 1 && RateV > 0)
            {
                RateV--;
            }
            else
            {
                RateV = rateGrid.Children.IndexOf((Button)sender) + 1;
            }
            
        }

        public delegate void RateDelagate(int value);
    }

    public class RateArgs: EventArgs
    {
        public int Value { get; set; }
    }
}
