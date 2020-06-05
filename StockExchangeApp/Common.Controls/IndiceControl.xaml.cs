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
    /// Interaction logic for IndiceControl.xaml
    /// </summary>
    public partial class IndiceControl : UserControl
    {
        public IndiceControl()
        {
            InitializeComponent();
        }

        private int indiceValue = 0;

        public event EventHandler<IndiceEventArgs> IndiceValueChanged;

        public int IndiceValue
        {
            get { return indiceValue; }
            set
            {
                if (value < 1 || value > 10)
                {
                    value = 1;
                }
                indiceValue = value;
                updateButtons();

                if (IndiceValueChanged != null)
                {
                    IndiceValueChanged(this, new IndiceEventArgs()
                    {
                        value = indiceValue
                    });
                }

            }
        }

        private void updateButtons()
        {
            foreach (var btn in indicesControlGrid.Children)
            {
                ((Button)btn).Background = new SolidColorBrush(Colors.White);

            }
            if (indiceValue > 0)
            {
                for (int i = 0; i < indiceValue; i++)
                {
                    ((Button)indicesControlGrid.Children[i]).Background = new SolidColorBrush(Colors.Blue);
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            IndiceValue = indicesControlGrid.Children.IndexOf((Button)sender) + 1;
        }

    }

    public class IndiceEventArgs: EventArgs
    {
        public int value { get; set; }
    }

}
