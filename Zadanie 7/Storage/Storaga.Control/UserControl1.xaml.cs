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

namespace Storaga.Control
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        private int _quantityValue;

        public event EventHandler<QuantityEventArgs> QuantityEventValue;

        public int QuantityValue
        {
            get
            {
                return _quantityValue;
            }

            set
            {
                if (QuantityEventValue != null)
                {
                    QuantityEventValue(this, new QuantityEventArgs() { Value = _quantityValue });
                }
            }
        }

        private void FillButtons()
        {
            foreach( var e in DataField.Children)
            {
                ((Button)e).Background = new SolidColorBrush(Colors.White);
            }

            for(int i = 0; i < _quantityValue; i++)
            {
                ((Button)DataField.Children[i]).Background = new SolidColorBrush(Colors.Goldenrod);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            QuantityValue = DataField.Children.IndexOf((Button)sender) + 1;
        }

        public class QuantityEventArgs : EventArgs
        {
            public int Value { get; set; }
        }
    }
}
