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
    /// Logika interakcji dla klasy Rate.xaml
    /// </summary>
    public partial class Rate : UserControl
    {
        public Rate()
        {
            InitializeComponent();
        }
        private int ratingVal = 0;

        public event EventHandler<RatingEventArgs> RatingValueChanged;

        public int RatingVal
        {
            get { return ratingVal; }
            set {
                ratingVal = value;
                UpdateRatings();
                RatingValueChanged?.Invoke(this, new RatingEventArgs() { Value = ratingVal });
            }
        }

        private void UpdateRatings()
        {
            foreach(var button in RatingGrid.Children)
            {
                if (RatingGrid.Children.IndexOf((Button)button) < RatingVal)
                {
                    ((Button)button).Background = new SolidColorBrush(Colors.Yellow);
                } else
                {
                    ((Button)button).Background = new SolidColorBrush(Colors.White);
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RatingVal = RatingGrid.Children.IndexOf((Button)sender) + 1;
            
        }

        public class RatingEventArgs: EventArgs
        {
            public int Value { get; set; }
        }
    }
}
