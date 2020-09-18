using Storage.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace Storage
{
    /// <summary>
    /// Interaction logic for Basedase.xaml
    /// </summary>
    public partial class Basedase : Page
    {

        int page;
        public Basedase()
        {

            InitializeComponent();
            TypeFilter.ItemsSource = new InterfaceService().getTypes();
            getAllStats();

        }

        public void getAllStats(int ShowPage = 0)
        {

            CoverPage.Visibility = Visibility.Visible;
            StackpanelAnimation.Visibility = Visibility.Visible;
            LoaderAnimation(1);
            Thread thread = new Thread(() => showDataBase());
            thread.Start();
            PageNumber.Text = "page: " + (page / 20 + 1).ToString();



        }
        public void showDataBase()
        {
            
            using (VehicleEntitiesData context = new VehicleEntitiesData())
            {
                
                /*List<Store> stores = context.Store.OrderBy(e => e.ID).Skip(ShowPage).Take(20).ToList();*/
                List<Store> stores = context.Store.OrderBy(e => e.ID).ToList();
                Dispatcher.Invoke(() => DataStoreGrid.ItemsSource = stores);
                if (Dispatcher.Invoke(() => TypeFilter.SelectedIndex != -1))
                {
                    Dispatcher.Invoke(() => stores = sortByType(stores));
                }
                if (Dispatcher.Invoke(() => Brand.Text != ""))
                {
                    Dispatcher.Invoke(() => stores = sortByBrand(stores));
                }
                if (Dispatcher.Invoke(() => FromPrice.Text != "" || ToPrice.Text != ""))
                {
                    Dispatcher.Invoke(() => stores = sortByPrice(stores));
                }
                if (Dispatcher.Invoke(() => FromCapacity.Text != "" || ToCapacity.Text != ""))
                {
                    Dispatcher.Invoke(() => stores = sortByCapacity(stores));
                }
                if (Dispatcher.Invoke(() => ByID.Text != ""))
                {
                    Dispatcher.Invoke(() => stores = sortByID(stores));
                }
                showData(stores);
                Dispatcher.Invoke(() => CoverPage.Visibility = Visibility.Hidden);
                Dispatcher.Invoke(() => StackpanelAnimation.Visibility = Visibility.Hidden);
                LoaderAnimation(0);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (page >= 20)
            {
                page -= 20;
                getAllStats(page);
            }
        }

        private void showData(List<Store> stores)
        {
            stores = stores.Skip(page).Take(20).ToList();
            Dispatcher.Invoke(() => DataStoreGrid.ItemsSource = stores);
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            page += 20;
            getAllStats(page);
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            page = 0;
            ResetFiltering();
            getAllStats(page);


        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            ResetFiltering();
        }
        private void ResetFiltering()
        {
            TypeFilter.SelectedIndex = -1;
            Brand.SelectedIndex = -1;
            FromPrice.Text = "";
            ToPrice.Text = "";
            FromCapacity.Text = "";
            ToCapacity.Text = "";
            ByID.Text = "";
        }

        private List<Store> sortByType(List<Store> stores)
        {
           stores = stores.Where(e => e.Type == ((IStorageLogicApp)TypeFilter.SelectedItem).type).ToList();
            return stores;

        }

        private List<Store> sortByBrand(List<Store> stores)
        {
           stores = stores.Where(e => e.Brand == Brand.Text).ToList();
            return stores;
        }

        private List<Store> sortByPrice(List<Store> stores)
        {
            if ( FromPrice.Text == "")
            {
                FromPrice.Text = "0";
            }
            else if ( ToPrice.Text == "")
            {
               ToPrice.Text = "9000000000";
            }

            stores = stores.Where(e => e.Value >= Convert.ToDouble(FromPrice.Text) && e.Value <= Convert.ToDouble(ToPrice.Text)).ToList();
            return stores;
        }

        private List<Store> sortByCapacity(List<Store> stores)
        {
            if (FromCapacity.Text == "")
            {
                FromCapacity.Text = "0";
            }
            else if (ToCapacity.Text == "")
            {
                ToCapacity.Text = "9000000000";
            }
            stores = stores.Where(e => e.Capacity >= Convert.ToDouble(FromCapacity.Text) && e.Capacity <= Convert.ToDouble(ToCapacity.Text)).ToList();
            return stores;
        }

        private List<Store> sortByID(List<Store> stores)
        {
          stores = stores.Where(e => e.ID == Convert.ToInt32(ByID.Text)).ToList();
            return stores;
        }




        private void SummitButton_Click(object sender, RoutedEventArgs e)
        {
            page = 0;
            getAllStats();

        }

        private void TypeFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if  (TypeFilter.SelectedIndex != -1)
            {
                Brand.ItemsSource = ((IStorageLogicApp)TypeFilter.SelectedItem).company;
            }
        }


        //Animacje

        private void LoaderAnimation(int loaderInfo)
        {
            Storyboard storyboard = this.FindResource("Storyboard1") as Storyboard;

            if (loaderInfo == 1)
            {
                Dispatcher.Invoke(() => storyboard.Begin());
            }
            else
            {
                Dispatcher.Invoke(() => storyboard.Stop());

            }
        }
    }
}
