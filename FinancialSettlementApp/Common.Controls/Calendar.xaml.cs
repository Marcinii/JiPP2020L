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
    /// Logika interakcji dla klasy Calendar.xaml
    /// </summary>
    public partial class Calendar : UserControl
    {
        public Calendar()
        {
            InitializeComponent();
        }

        private string _month = "";
        int numberOfMonth = -1;

        public event EventHandler<CalendarEventArgs> CalendarMonthChanged;

        public string SelectedMonth
        {
            get { return _month; }
            set
            {
                _month = value;
                UpdateButtons();

                if (CalendarMonthChanged != null)
                {
                    CalendarMonthChanged(this, new CalendarEventArgs() { Value = _month });
                }
            }
        }

        private void January_Click(object sender, RoutedEventArgs e)
        {
            numberOfMonth = calendarGrid.Children.IndexOf((Button)sender);
            SelectedMonth = Month[(calendarGrid.Children.IndexOf((Button)sender))];

        }

        private void UpdateButtons()
        {
            foreach (var b in calendarGrid.Children)
            {
                ((Button)b).Background = new SolidColorBrush(Colors.Silver);
            }

            if (numberOfMonth > -1)
            {
                ((Button)calendarGrid.Children[numberOfMonth]).Background = new SolidColorBrush(Colors.DeepSkyBlue);

            }
        }

        public List<string> Month => new List<string>() {
            "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"
        };

        public class CalendarEventArgs : EventArgs
        {
            public string Value { get; set; }
        }
    }
}
