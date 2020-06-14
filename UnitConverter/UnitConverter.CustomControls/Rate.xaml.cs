using System;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace UnitConverter.CustomControls
{
    public partial class RateControl : UserControl
    {
        public int user_rating = 0;
        public RateControl()
        {
            InitializeComponent();
        }
        public event EventHandler<UserRatingEventArgs> UserRatingChanged;

        public class UserRatingEventArgs : EventArgs
        {
            public int UserRating { get; set; }
        }

        public void ResetColor()
        {
            foreach (Rectangle c in RatingGrid.Children)
            {
                c.Fill = new SolidColorBrush(Color.FromRgb(0xff, 0xff, 0xff));

            }
        }

        public void FillColor(int how_many)
        {
            ResetColor();
            int i = 0;
            foreach (Rectangle c in RatingGrid.Children)
            {
                if (i == how_many)
                {
                    break;
                }
                c.Fill = new SolidColorBrush(Color.FromRgb(0xff, 0xc4, 0x0d));
                i++;
            }
        }

        private void Rectangle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var column = ((Rectangle)sender).GetValue(Grid.ColumnProperty);
            this.user_rating = (int)column + 1;

            UserRatingChanged(sender, new UserRatingEventArgs() { UserRating = this.user_rating });
        }
    }
}
