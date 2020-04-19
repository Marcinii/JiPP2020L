using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Project.Desktop
{
    /// <summary>
    /// Interaction logic for Clock.xaml
    /// </summary>
    public partial class Clock : Window
    {
        

        public Clock()
        {
            InitializeComponent();
            AmPmDisplayLabel.Visibility = Visibility.Collapsed;
        }

        private Timer waitTimer;
 

        public void OnTimerClock_Elapsed(object sender, ElapsedEventArgs e)
        {
            ((Storyboard)this.Resources["ClockStoryboard"]).Pause(this);
            waitTimer = new Timer(7000);
            waitTimer.Elapsed += OnWaitTimerElapsed;
            waitTimer.Start();
            
        }

        private void OnWaitTimerElapsed(object sender, ElapsedEventArgs e)
        {

            this.Dispatcher.Invoke(() =>
            {
                this.Close();
            });

        }
    }
}
