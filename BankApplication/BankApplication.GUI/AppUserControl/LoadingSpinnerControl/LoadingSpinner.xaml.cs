using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace BankApplication.GUI.AppUserControl.LoadingSpinnerControl
{
    /// <summary>
    /// Interaction logic for LoadingSpinner.xaml
    /// </summary>
    public partial class LoadingSpinner : UserControl
    {
        public double barHeight { get; set; } = 40;
        public double barWidth { get; set; } = 15;
        public int animationDuration { get; set; } = 500;
        public int barsCount { get; set; } = 5;

        public LoadingSpinner()
        {
            InitializeComponent();
            this.DataContext = this;

            for (int i = 0; i < this.barsCount; i++)
            {
                Rectangle rectangle = new Rectangle();
                rectangle.BeginAnimation(HeightProperty, new DoubleAnimation()
                {
                    From = this.barHeight,
                    To = this.barHeight / 4.0,
                    AutoReverse = true,
                    RepeatBehavior = RepeatBehavior.Forever,
                    EasingFunction = new PowerEase()
                    {
                        EasingMode = EasingMode.EaseInOut
                    },
                    Duration = new Duration(new TimeSpan(0, 0, 0, 0, this.animationDuration)),
                    BeginTime = new TimeSpan(0, 0, 0, 0, (this.animationDuration / this.barsCount) * i)
                });
                this.rectangleContainerStackPanel.Children.Add(rectangle);
            }
        }
    }
}
