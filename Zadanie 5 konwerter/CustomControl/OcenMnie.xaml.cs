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

namespace CustomControl
{
    /// <summary>
    /// Interaction logic for OcenMnie.xaml
    /// </summary>
    public partial class OcenMnie : UserControl
    {
        public OcenMnie()
        {
            InitializeComponent();
        }

        private int _rate_value = 0;

        public event EventHandler<RateEventArgs> RateValueChanged;

        public int Rate_value
        {
            get { return _rate_value; }
            set
            {
                if (value < 1 && value > 5)
                {
                    MessageBox.Show("Wybierz poprawną ocene");
                }
                else
                {
                    _rate_value = value;
                    UpdateButtons();
                }
                RateValueChanged?.Invoke(this, new RateEventArgs() { Value = _rate_value });
            }
        }

        private void UpdateButtons()
        {
            foreach (var b in RateGrid.Children)
            {
                ((Button)b).Background = new SolidColorBrush(Colors.Blue);
            }
            if (Rate_value > 0)
            {
                int tmp = 0;
                foreach (var b in RateGrid.Children)
                {
                    tmp++;
                    if (tmp > Rate_value)
                    {
                        break;
                    }
                    ((Button)b).Background = new SolidColorBrush(Colors.Green);
                }
            }
        }

        private void Rate_Button_Click(object sender, RoutedEventArgs e)
        {
            Rate_value = RateGrid.Children.IndexOf((Button)sender) + 1;
        }
    }

    public class RateEventArgs : EventArgs
    {
        public int Value { get; set; }
    }
}