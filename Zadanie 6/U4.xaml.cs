using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Media.Animation;

namespace application
{

    public partial class U4 : UserControl
    {
        public U4()
        {
            InitializeComponent();
        }



        CancellationTokenSource tokenSource3;

        public void user6()
        {
            tokenSource3 = new CancellationTokenSource();
            Task t6 = new Task(() => r_6(tokenSource3.Token), tokenSource3.Token);
            t6.Start();
        }
        public void r_6(CancellationToken ct)
        {
            if (ct.IsCancellationRequested)
            {
                ct.ThrowIfCancellationRequested();
            }
            Thread.Sleep(10500);
            Dispatcher.Invoke(() =>
            r6.Visibility = Visibility.Hidden
            );
        }

        public void loadprogressbar6()
        {
            if (progressBar6.Value < 99)
            {
                Duration duration_6 = new Duration(TimeSpan.FromSeconds(10));
                DoubleAnimation doubler6 = new DoubleAnimation(100.0, duration_6);
                Dispatcher.Invoke(() => progressBar6.BeginAnimation(System.Windows.Controls.ProgressBar.ValueProperty, doubler6));
            }
            else
            {
                lblr6.Content = "Done!";
            }

        }



        public int currentPage { get; set; }

        private void btnGoU4_Click(object sender, RoutedEventArgs e)
        {
            r6.Visibility = Visibility.Visible;
            loadprogressbar6();

            currentPage = 0;
            using (DB context = new DB())
            {
               
                if (DateTime.TryParse(tb1.Text, out DateTime time1)) { } 
                else time1 = new DateTime(2020, 01, 01);
                if (DateTime.TryParse(tb2.Text, out DateTime time2)) 
                { 
                    time2 = new DateTime(time2.Year, time2.Month, time2.Day, 23, 59, 59); } 
                else time2 = DateTime.Now;
                List<StatTable> catconv = context.StatTable
                    .Where(tmp => tmp.ClickDate >= time1)
                    .Where(tmp => tmp.ClickDate <= time2)
                    .OrderBy(tmp => tmp.ClickDate)
                    .Skip(currentPage * 7)
                    .Take(7)
                    .ToList();
                DataGrid4.ItemsSource = catconv;
            }
        }
    
        private void btnNEXT_Click(object sender, RoutedEventArgs e)
        {
            currentPage++;
            using (DB context = new DB())
            {
                if (DateTime.TryParse(tb1.Text, out DateTime time1)) { } else time1 = new DateTime(2020, 01, 01);
                if (DateTime.TryParse(tb2.Text, out DateTime time2)) { time2 = new DateTime(time2.Year, time2.Month, time2.Day, 23, 59, 59); } else time2 = DateTime.Now;
                List<StatTable> catconv = context.StatTable
                .Where(tmp => tmp.ClickDate >= time1)
                .Where(tmp => tmp.ClickDate <= time2)
                .OrderBy(tmp => tmp.ClickDate)
                .Skip(currentPage * 7)
                .Take(7)
                .ToList();
                DataGrid4.ItemsSource = catconv;
            }
        }

        private void btnPREV_Click(object sender, RoutedEventArgs e)
        {
            using (DB context = new DB())
                {
                if (currentPage != 0) { currentPage--; }
                    if (DateTime.TryParse(tb1.Text, out DateTime time1)) { } else time1 = new DateTime(2020, 01, 01);
                    if (DateTime.TryParse(tb2.Text, out DateTime time2)) { time2 = new DateTime(time2.Year, time2.Month, time2.Day, 23, 59, 59); } else time2 = DateTime.Now;
                    List<StatTable> catconv = context.StatTable
                    .Where(tmp => tmp.ClickDate >= time1)
                    .Where(tmp => tmp.ClickDate <= time2)
                    .OrderBy(tmp => tmp.ClickDate)
                    .Skip(currentPage * 7)
                    .Take(7)
                    .ToList();
                    DataGrid4.ItemsSource = catconv;
            }
        }

        private void btn6_Click(object sender, RoutedEventArgs e)
        {
            tokenSource3.Cancel();
            r6.Visibility = Visibility.Hidden;
        
        }
    }

}
