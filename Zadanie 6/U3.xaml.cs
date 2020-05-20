using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using System;
using System.Windows.Media.Animation;
using System.Data.Entity.Core.Objects;
using System.ComponentModel;

namespace application
{
   

    public partial class U3 : UserControl
    {
        public U3() 
        { 
          InitializeComponent();
        }


        CancellationTokenSource tokenSource2;
   
        public void user5()
        {
            tokenSource2 = new CancellationTokenSource();
            Task t5 = new Task(() => r_5(tokenSource2.Token), tokenSource2.Token);
            t5.Start();
        }
        public void r_5(CancellationToken ct)
        {
                if (ct.IsCancellationRequested)
                {
                    ct.ThrowIfCancellationRequested();
                }
                Thread.Sleep(10000);
                Dispatcher.Invoke(() =>
                r5.Visibility = Visibility.Hidden
                );
        }

        public void loadprogressbar5()
        {
            if (progressBar_r5.Value < 99 )
            {
                Duration duration_5 = new Duration(TimeSpan.FromSeconds(5));
                DoubleAnimation doubler5 = new DoubleAnimation(100.0, duration_5);
                Dispatcher.Invoke(() => progressBar_r5.BeginAnimation(System.Windows.Controls.ProgressBar.ValueProperty, doubler5));
            } else 
            {
                lblr5.Content = "Done!";
            }

        }

        private void btnt_Click(object sender, RoutedEventArgs e)
        {
            
            r5.Visibility = Visibility.Visible;
            loadprogressbar5();

            using (DB context = new DB())
            {
                string tmp2 = "time";
                List<StatTable> catconv = context.StatTable
                   .Where(tmp => tmp.ConverterType == tmp2)
                   .ToList();
                gridSelection.ItemsSource = catconv;
            }
         }

        private void bttp_Click(object sender, RoutedEventArgs e)
        {
            r5.Visibility = Visibility.Visible;
            loadprogressbar5();

            using (DB context = new DB())
            {
                string tmp2 = "temperature";
                List<StatTable> catconv = context.StatTable
                   .Where(tmp => tmp.ConverterType == tmp2)
                   .ToList();
                gridSelection.ItemsSource = catconv;
            }
        }

        private void btnd_Click(object sender, RoutedEventArgs e)
        {
            r5.Visibility = Visibility.Visible;
            loadprogressbar5();

            using (DB context = new DB())
            {
                string tmp2 = "distance";
                List<StatTable> catconv = context.StatTable
                   .Where(tmp => tmp.ConverterType == tmp2)
                   .ToList();
                gridSelection.ItemsSource = catconv;
            }
        }

        private void btnw_Click(object sender, RoutedEventArgs e)
        {
            r5.Visibility = Visibility.Visible;
            loadprogressbar5();

            using (DB context = new DB())
            {
                string tmp2 = "weight";
                List<StatTable> catconv = context.StatTable
                   .Where(tmp => tmp.ConverterType == tmp2)
                   .ToList();
                gridSelection.ItemsSource = catconv;
            }
        }

        private void btnr5_Click(object sender, RoutedEventArgs e)
        {
            tokenSource2.Cancel();
            r5.Visibility = Visibility.Hidden;
        }
    }
}
