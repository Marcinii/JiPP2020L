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
    /// Interaction logic for UserRate.xaml
    /// </summary>
    public partial class UserRate : UserControl
    {
        public int userRating = 0;
        public UserRate()
        {
            InitializeComponent();
            foreach (StarButton b in starGrid.Children)
            {
                b.StarClick += new EventHandler(StarButton_Click);
            }
        }

        public event EventHandler<UserRatingEventArgs> UserRatingChanged;

        public class UserRatingEventArgs : EventArgs
        {
            public int Rating
            {
                get;
                set;
            }
        }

        private void StarButton_MouseEnter(object sender, MouseEventArgs e)
        {
            var col = ((StarButton)sender).GetValue(Grid.ColumnProperty);
            int i = 0;
            foreach(StarButton b in starGrid.Children)
            {
                if (i <= (int)col)
                {
                    b.Fill = new Tuple<byte, byte, byte, byte>(0xFF, 0xFF, 0xD7, 0x00);
                }
                i++;
            }
        }

        private void StarButton_MouseLeave(object sender, MouseEventArgs e)
        {
            foreach (StarButton b in starGrid.Children)
            {

                b.DefaultFill();
            }
        }

        private void StarButton_Click(object sender, EventArgs e)
        {
            var col = ((StarButton)sender).GetValue(Grid.ColumnProperty);
            this.userRating = (int)col + 1;
            UserRatingChanged(sender, new UserRatingEventArgs() { Rating = this.userRating });
        }

    }
}
