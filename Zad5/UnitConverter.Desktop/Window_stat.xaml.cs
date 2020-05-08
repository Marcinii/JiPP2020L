using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Shapes;
using Stats;

namespace UnitConverter.Desktop

{
    /// <summary>
    /// Logika interakcji dla klasy Window_stat.xaml
    /// </summary>
    /// zadanie  5
    public partial class Window_stat : Window
    {
        private int _maxPage = 0;
        public Window_stat()
        {
            InitializeComponent();
            ShowCommand = new RelayCommand(obj => Button_Click(obj));
            show.Command = ShowCommand;
            PrevCommand = new RelayCommand(obj => Prev_OnClick(), obj => int.Parse(activePage.Content.ToString()) > 1);
            prev.Command = PrevCommand;
            NextCommand = new RelayCommand(obj => Next_OnClick(), obj => int.Parse(activePage.Content.ToString()) < _maxPage);
            next.Command = NextCommand;
        }

        private RelayCommand ShowCommand;
        private RelayCommand PrevCommand;
        private RelayCommand NextCommand;

        private void Button_Click(object sender)
        {
            string converter = c1.Text;
            DateTime from = (DateTime)From.SelectedDate;
            DateTime to = (DateTime)To.SelectedDate;
            
            var list = getGridData(converter,from, to);
            setMaxPage(list);
            setActivePage();
            updateGridData();
            getTopGridData(from, to);
        }

        private List<Stats.Stats> getGridData(string converter, DateTime from, DateTime to)
        {
            var list = StatsClass.Search(converter, from, to, int.Parse(activePage.Content.ToString()));
            return list;

        }

        private void getTopGridData(DateTime from, DateTime to)
        {
            var list = StatsClass.Top(from, to);
            Top.ItemsSource = list;
        }

        private void updateGridData()
        {
            DataGrid.ItemsSource = getGridData(c1.Text, (DateTime) From.SelectedDate, (DateTime) To.SelectedDate);

        }
        private void Prev_OnClick()
        {
            setActivePage(-1);
            updateGridData();
        }

        private void Next_OnClick()
        {
            setActivePage(1);
            updateGridData();
        }

        private void setMaxPage(List<Stats.Stats> data)
        {
            if(data.Count>0)
            _maxPage = (data.Count % 20 != 0) ? (data.Count/20 + 1) : (data.Count/20);
        }

        private void setActivePage()
        {
            activePage.Content = 1;
            prev.IsEnabled = false;
            if (_maxPage <= 1)
            {
                next.IsEnabled = false;
            }
        }

        private void setActivePage(int direction)
        {
            prev.IsEnabled = true;
            next.IsEnabled = true;
            if (int.Parse(activePage.Content.ToString()) < _maxPage && int.Parse(activePage.Content.ToString()) > 1)
            {
                activePage.Content = int.Parse(activePage.Content.ToString()) + direction;
            }
            /*
            if (int.Parse(activePage.Content.ToString()) == 1)
            {
                prev.IsEnabled = false;
            }

            if (int.Parse(activePage.Content.ToString()) == _maxPage)
            {
                next.IsEnabled = false;
            }*/
        }
    }
}
