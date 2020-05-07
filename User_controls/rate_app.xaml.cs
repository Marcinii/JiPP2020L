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

namespace User_controls
{
    /// <summary>
    /// Logika interakcji dla klasy rate_app.xaml
    /// </summary>
    public partial class rate_app : UserControl
    {
        public rate_app()
        {
            InitializeComponent();
        }

        private int private_rate_value = 0;

        public event EventHandler<rate_event_args> rate_value_changed;

        public int rate_value
        {
            get { return private_rate_value; }
            set
            {
                private_rate_value = value;

                update_buttons();
                if (rate_value_changed != null) {
                    rate_value_changed(this, new rate_event_args() { value = private_rate_value});
                }
            }
        }

        private bool duplicate_click = false; //this will tell us, when we click again on the same rate. If yes, we want clear it

        private void update_buttons()
        {
            foreach(var b in rate_grid.Children)
            {
                ((Button)b).Background = new SolidColorBrush(Colors.DarkGreen);
            }
            if (private_rate_value > 0 && !duplicate_click) //if we dont click twice, its ok, but if yes, we don want change any button's color
            {
                for(int i = 1; i < private_rate_value+1; i++)
                {
                    ((Button)rate_grid.Children[private_rate_value - i]).Background = new SolidColorBrush(Colors.Lime);
                }
            }
            else
            {
                duplicate_click = false; //but after this, we need "clear the status" of cliked it twice
            }

        }

        private void click(object sender, RoutedEventArgs e)
        {
            if(rate_grid.Children.IndexOf((Button)sender) + 1 == rate_value)
            {
                duplicate_click = true; //if we click twice on rate, it should clear
            }
            rate_value = rate_grid.Children.IndexOf((Button)sender) + 1;
        }

        public class rate_event_args : EventArgs
        {
            public int value { get; set; }
        }

    }
}
