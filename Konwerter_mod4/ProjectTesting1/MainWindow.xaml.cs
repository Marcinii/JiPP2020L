using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace ProjectTesting1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            it.Add(new items() { id = 1, item = "item1" });
            it.Add(new items() { id = 2, item = "item2" });
            it.Add(new items() { id = 3, item = "item3" });
            //CollectionViewSource ItemsCol = new CollectionViewSource() { Source = it };
            /*
             * ONE OF THE OPTIONS
             * 
             * ItemsCol.Filter += new FilterEventHandler(RMItem);
            ICollectionView ItemsView = ItemsCol.View;
            dg.ItemsSource = ItemsView;*/
            dg.MouseEnter += RMItem;
            this.ItemsView = CollectionViewSource.GetDefaultView(it);
            dg.ItemsSource = this.ItemsView;
            it.Remove(it[0]);
        }
        //ObservableCollection<items> it = new ObservableCollection<items>();
        List<items> it = new List<items>();
        private ICollectionView ItemsView;
        class items
        {
            public int id { get; set; }
            public string item { get; set; }
        }
        private void RMItem(object sender, MouseEventArgs e)
        {
            
            T1.Text = sender.ToString();
            //dg.ItemsSource = it;
            it.RemoveAt(1);
            //this.ItemsView = CollectionViewSource.GetDefaultView(it);
            this.ItemsView.Refresh();
            //((DataGrid)sender).ItemsSource = it;
            
            
        }
        
       /* private void RMItem(object sender, FilterEventArgs e)
        {
            items o = e.Item as items;
            if (o != null)
            {
                if (o.id != 2) e.Accepted = true;
            }
            else e.Accepted = false;
            T1.Text = sender.ToString();
            //dg.ItemsSource = it;
            it.RemoveAt(1);
            //((DataGrid)sender).ItemsSource = it;
            
            
        }*/
    }
}
