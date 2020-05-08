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

namespace Common.Control
{
    /// <summary>
    /// Logika interakcji dla klasy UserControl1.xaml
    /// </summary>
    public partial class RateMe : UserControl
    {
        public RateMe()
        {
            InitializeComponent();
            ButtonCommand = new RelayCommand(obj => Button_Click(obj));
            r0.Command = ButtonCommand;
            r1.Command = ButtonCommand;
            r2.Command = ButtonCommand;
            r3.Command = ButtonCommand;
            r4.Command = ButtonCommand;

        }
        private int _rateVal = 0;
        private RelayCommand ButtonCommand;
        public event EventHandler<RateEventArgs> RateValueChanged;

        public int RateVal
        {
            get { return _rateVal; }
            set
            {
                if (value < 0 || value > 4)
                {
                    throw new ArgumentException(nameof(value));
                }
                _rateVal = value;
                UpdateButtons();
                if (RateValueChanged != null)
                {
                    RateValueChanged(this, new RateEventArgs() { Value = _rateVal });
                }
            }
        }


        private void UpdateButtons()
        {
            foreach (var v in rateGrid.Children)
            {
                ((Button)v).Background = new SolidColorBrush(Colors.White);
            }

            if (_rateVal > 0)
            {
                for (int i = 0; i < _rateVal; i++)
                {
                    ((Button)rateGrid.Children[i]).Background = new SolidColorBrush(Colors.Gold);

                }
            }
        }
        private void Button_Click(object sender)
        {
            RateVal = rateGrid.Children.IndexOf((Button)sender);

        }

    }
    public class RateEventArgs : EventArgs
    {
        public int Value
        {
            get;
            set;
        }
    }
}
