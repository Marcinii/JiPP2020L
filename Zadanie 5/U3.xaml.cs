using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Data;

namespace application
{
   

    public partial class U3 : UserControl
    {
        public U3() { InitializeComponent(); }

        private void btnt_Click(object sender, RoutedEventArgs e)
        {
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
            using (DB context = new DB())
            {
                string tmp2 = "weight";
                List<StatTable> catconv = context.StatTable
                   .Where(tmp => tmp.ConverterType == tmp2)
                   .ToList();
                gridSelection.ItemsSource = catconv;
            }
        }
    }

}
