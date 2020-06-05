using FlowerManager.Logic;
using FlowerManager.Database;
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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FlowerManager.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private FlowerControler flowerControler;
        private RoomControler roomControler;

        public MainWindow()
        {
            flowerControler = new FlowerControler();
            roomControler = new RoomControler();

            InitializeComponent();
        }

        private void AddRoomBtnClicked(object sender, RoutedEventArgs e)
        {
            LoadingPanel.Visibility = Visibility.Visible;
            string roomname = RoomName.Text;
            Task t = new Task(() => {
                Task.Delay(2000).Wait();
                roomControler.AddRecord(roomname);
                Dispatcher.Invoke(() => { LoadingPanel.Visibility = Visibility.Hidden; });
            });
            t.Start();
            roomControler.AddRecord(RoomName.Text);
        }

        private void AddFlowerBtnClicked(object sender, RoutedEventArgs e)
        {
            LoadingPanel.Visibility = Visibility.Visible;
            string flowername = FlowerName.Text;
            string roomname = RoomName.Text;
            int.TryParse(FlowerWateringFQC.Text, out int frequency);
            Task t = new Task(() => {
                Task.Delay(2000).Wait();
                int roomid = roomControler.GetID(roomname);
                flowerControler.AddRecord(flowername, frequency, roomid);
                Dispatcher.Invoke(() => { LoadingPanel.Visibility = Visibility.Hidden; });
            });
            t.Start();
        }

        private void LoadAllData(object sender, RoutedEventArgs e)
        {
            LoadingPanel.Visibility = Visibility.Visible;
            Task t = new Task(() => {
                Task.Delay(2000).Wait();
                List<Flower> flowers = flowerControler.GetRecords().Cast<Flower>().ToList();
                Dispatcher.Invoke(() => { FlowersList.ItemsSource = flowers;});
                Dispatcher.Invoke(() => { LoadingPanel.Visibility = Visibility.Hidden; });
            });
            t.Start();

        }

        private void LoadData(object sender, RoutedEventArgs e)
        {
            LoadingPanel.Visibility = Visibility.Visible;
            Task t = new Task(() => {
                Task.Delay(2000).Wait();
                List<Flower> flowers = flowerControler.GetDyingFlowers();
                Dispatcher.Invoke(() => { FlowersList.ItemsSource = flowers;});
                Dispatcher.Invoke(() => { LoadingPanel.Visibility = Visibility.Hidden; });
            });
            t.Start();
        }

        private void FlowerWatered(object sender, EventArgs e)
        {
            LoadingPanel.Visibility = Visibility.Visible;
            Flower selectedFlower = (Flower)FlowersList.SelectedItem;
            Task t = new Task(() => {
                Task.Delay(2000).Wait();
                flowerControler.UpdateRecord(selectedFlower.ID);
                Dispatcher.Invoke(() => { LoadingPanel.Visibility = Visibility.Hidden; });
            });
            t.Start();
        }

        private void FlowersList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Flower selectedFlower = (Flower)FlowersList.SelectedItem;
            if (selectedFlower != null)
            {
                if (flowerControler.isDead(selectedFlower))
                {
                    flower.State = 0;
                }
                else
                {
                    flower.State = 1;
                }
            }
        }
    }
}
