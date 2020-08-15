using System;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace UnitConverter.WpfControls
{
    public partial class RatingControl : UserControl
    {
        private int UserRating = 0;
        private static SolidColorBrush Gold = new SolidColorBrush(Color.FromRgb(255, 255, 0));
        private static SolidColorBrush Empty = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));

        public RatingControl()
        {
            InitializeComponent();
        }
        public event EventHandler<RatingArgs> RatingChangedEventHandler;
        public class RatingArgs : EventArgs
        {
            public int UserRating { get; set; }
        }

        private void RatingButtonClicked(object sender, MouseButtonEventArgs e)
        {
            var column = ((Ellipse)sender).GetValue(Grid.ColumnProperty);
            this.UserRating = (int)column + 1;
            Clear();
            Fill(Gold);

            RatingChangedEventHandler(sender, new RatingArgs() { UserRating = this.UserRating });
        }

        private void Fill(SolidColorBrush color)
        {
            var elipses = RatingGrid.Children;
            for (int i = 0; i < UserRating; i++)
            {
                ((Ellipse)elipses[i]).Fill = color;
            }
        }

        private void FillAll(SolidColorBrush color)
        {
            foreach (Ellipse e in RatingGrid.Children)
            {
                e.Fill = color;
            }
        }

        public void FillN(int n)
        {
            if (n <= 5 && n >= 0)
            {
                var elipses = RatingGrid.Children;
                for (int i = 0; i < n; i++)
                {
                    ((Ellipse)elipses[i]).Fill = Gold;
                }
            }
        }

        private void Clear()
        {
            FillAll(Empty);
        }
    }
}
