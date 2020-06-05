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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FlowerManager.Controls
{
    /// <summary>
    /// Logika interakcji dla klasy FlowerState.xaml
    /// </summary>
    public partial class FlowerState : UserControl
    {
        private int state = 1;

        public FlowerState()
        {
            InitializeComponent();
        }

        public event EventHandler<EventArgs> Watered;
        public int State
        {
            get { return state; }
            set
            {
                if (value == 0)
                {
                    Dead();
                    state = value;
                }
                else
                {
                    Alive();
                    if (Watered != null && state==0) Watered(this, new RoutedEventArgs());
                    state = 1;
                }
            }
        }

        public void Dead()
        {
            Storyboard sb = this.FindResource("DeadAnimation") as Storyboard;
            Storyboard.SetTarget(sb, DeadFlower);
            sb.Begin();
        }
        
        public void Alive()
        {
            Storyboard sb = this.FindResource("AliveAnimation") as Storyboard;
            Storyboard.SetTarget(sb, DeadFlower);
            sb.Begin();
        }

        private void WaterFlower(object sender, RoutedEventArgs e)
        {
            State = 1;
        }
    }
}
