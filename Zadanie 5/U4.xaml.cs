using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Data;

namespace application
{

    public partial class U4 : UserControl
    {
        public U4(){InitializeComponent();int currentPage = 0;  }

        public int currentPage { get; set; }
        private void btnGoU4_Click(object sender, RoutedEventArgs e)
        {
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


        private void tb1_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void tb2_TextChanged(object sender, TextChangedEventArgs e)
        {
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
    }

}
