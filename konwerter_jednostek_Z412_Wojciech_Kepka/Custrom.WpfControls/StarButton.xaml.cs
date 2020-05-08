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

namespace Custrom.WpfControls
{
    /// <summary>
    /// Interaction logic for StarButton.xaml
    /// </summary>
    public partial class StarButton : UserControl
    {
        public event EventHandler StarClick;
        private Tuple<byte, byte, byte, byte> fill;
        public StarButton()
        {
            InitializeComponent();
            DefaultFill();
        }

        public Tuple<byte, byte, byte, byte> Fill
        {
            get { return fill; }
            set 
            {
                this.fill = value;
                var brush = new SolidColorBrush();
                brush.Color = Color.FromArgb(fill.Item1, fill.Item2, fill.Item3, fill.Item4);
                starPath.Fill = brush;
            }
        }

        public void DefaultFill()
        {
            var brush = new SolidColorBrush();
            brush.Color = Color.FromArgb(0xff, 0xff, 0xff, 0xff);
            starPath.Fill = brush;
        }

        public void Button_Click(object sender, EventArgs e)
        {
            StarClick(this, e);
        }
    }
}
