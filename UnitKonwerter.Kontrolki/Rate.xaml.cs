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

namespace UnitKonwerter.Kontrolki
{
    /// <summary>
    /// Interaction logic for Rate.xaml
    /// </summary>
    public partial class Rate : UserControl
    {
        public Rate()
        {
            InitializeComponent();
        }

        private int _rateValue = 0;

        public int RateValue
        {
            get 
            { 
                return _rateValue; 
            }
            set
            {
                if (value > 5)
                    _rateValue = 5;
                else if (value < 0)
                    _rateValue = 0;
                else 
                    _rateValue = value;

                UpdateButtons();
            }
        }

        private void UpdateButtons()
        {
            foreach(var b in RateGrid.Children)
            {
                ((Button)b).Tag = "";
            }

            for (int i = 0; i < RateValue; i++)
            {
                ((Button)RateGrid.Children[i]).Tag = "y";
            }

            RateValueChanged?.Invoke(this, new RateEventArgs() { Value = _rateValue });
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            int ClickedButtonId = RateGrid.Children.IndexOf((Button)sender) + 1;
            if (RateValue != ClickedButtonId)
                RateValue = ClickedButtonId;         
            else
                RateValue = 0;
            

        }

        public event EventHandler<RateEventArgs> RateValueChanged;

        public class RateEventArgs : EventArgs
        {
            public int Value { get; set; }
        }


    }
}
