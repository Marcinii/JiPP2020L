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
using System.Diagnostics;

namespace UnitConverter.RatingControl
{
    /// <summary>
    /// Logika interakcji dla klasy UserControl1.xaml
    /// </summary>
    public partial class RatingControl : UserControl
    {
        public RatingControl()
        {
            InitializeComponent();           
        }
        public event EventHandler<RateEventArgs> RateValueChange;

        private int _Rating = 0;
        public int Rating
        {
            get
            {
                return _Rating;
            }
            set
            {
                RateValueChange?.Invoke(this, new RateEventArgs() { Value = value });
                _Rating = value;
                UpdateButtons();
            }
        }

        private void StarMouseEnter(object sender, EventArgs e)
        {
            int toColor = StarGrid.Children.IndexOf((UIElement)sender) + 1;
            Brush brush = new SolidColorBrush(Colors.Gold);
            for (int i = 0; i < 5; i++)
            {
                if (i == toColor) brush = new SolidColorBrush(Colors.White);
                ((Button)StarGrid.Children[i]).Background = brush;
            }
        }
        private void StarMouseLeave(object o, EventArgs e)
        {
            UpdateButtons();
        }

        private void StarClick(object sender, RoutedEventArgs e)
        {          
            Rating = StarGrid.Children.IndexOf((UIElement)sender)+1;                     
        }
        private void UpdateButtons()
        {
            Brush brush = new SolidColorBrush(Colors.Gold);
            for (int i = 0; i < 5; i++)
            {
                if (i == Rating) brush = new SolidColorBrush(Colors.White);
                ((Button)StarGrid.Children[i]).Background = brush;
            }
        }       
    }
    public class RateEventArgs : EventArgs
    {
        public int Value { get; set; }
    }
}
