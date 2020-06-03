using Logic;
using System;
using System.Collections.Generic;
using System.Globalization;
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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static RateUs.RateUs;

namespace Projekt7
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IVehicle currentVehicle = null;

        public MainWindow()
        {
            InitializeComponent();

            this.Title = "Sowa i samochody";

            List<string> types = new List<string>();
            types.Add("Wszystkie");
            types.Add("Samochody");
            types.Add("Skutery");
            types.Add("Rowery");

            typeList.ItemsSource = types;
            typeList.SelectedIndex = 0;

            List<IVehicle> vehicles = loadVehicles();
            rentList.ItemsSource = vehicles;
            rentList.SelectedItem = "{Binding Path=IVehicle}";
            rentList.DisplayMemberPath = "Name";

            List<RentTable> rents = loadRents();
            rentsGrid.ItemsSource = rents;

            KosztTotal.Text = rents.Sum(x => x.price).ToString();
            LoadRateDB();
        }

        private void LoadRateDB()
        {
            using (RateMeBaseEntities context = new RateMeBaseEntities())
            {
                RateTable rateTable = context.RateTable.ToList().Last();
                if (rateTable != null)
                {
                    rateUs.RateValue = rateTable.Ocena;
                }
            }
        }

        private void RateControl_OnRateValue(object sender, RateEventArgs e)
        {
            using (RateMeBaseEntities context = new RateMeBaseEntities())
            {
                context.RateTable.Add(new RateTable()
                {
                    Ocena = e.Value
                });
                context.SaveChanges();
            }
        }

        private List<IVehicle> loadVehicles()
        {
            using (RentDBEntities context = new RentDBEntities())
            {
                List<Vehicles> vehicles = context.Vehicles.ToList();
                List<IVehicle> result = new List<IVehicle>();
                foreach(Vehicles v in vehicles)
                {
                    if(v.Vehicle_type.Equals("Scooter"))
                    {
                        result.Add(new Scooter(v.Brand, v.Model, v.Price.Value));
                    }
                    else if(v.Vehicle_type.Equals("Car"))
                    {
                        result.Add(new Car(v.Brand, v.Model, v.Vehicle_class));
                    }
                    else if(v.Vehicle_type.Equals("Bike"))
                    {
                        result.Add(new Bike(v.Brand, v.Model, v.Vehicle_class, v.Price.Value));
                    }
                }
                return result;
            }
        }

        private List<RentTable> loadRents()
        {
            using (RentDBEntities1 context = new RentDBEntities1())
            {
                List<RentTable> rents = context.RentTable.ToList();
                return rents;
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            currentVehicle = (IVehicle)rentList.SelectedItem;
        }

        private int getHours()
        {
            try
            {
                int hours = int.Parse(hoursCount.Text.ToString());
                if (hours < 0)
                {
                    throw new Exception("Negative value");
                }
                return hours;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        private bool CountPrice()
        {
            int hours = getHours();
            if(hours <= 0)
            {
                MessageBox.Show("Niepoprawna ilość godzin.");
                return false;
            }

            if (currentVehicle == null)
            {
                MessageBox.Show("Nie wybrano pojazdu.");
                return false;
            }

            priceBox.Text = currentVehicle.CountPrice(hours).ToString();
            return true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CountPrice();
        }

        private void SendData()
        {
            Thread.Sleep(5000);

            int hours = -1;
            double price = -1;
            Dispatcher.Invoke(() =>
            {
                hours = getHours();
                price = Double.Parse(priceBox.Text);
            });

            if(hours > 0 && price > 0)
            {
                SendDB(currentVehicle.Name, hours, price);
                List<RentTable> rents = loadRents();
                Dispatcher.Invoke(() =>
                {
                    rentsGrid.ItemsSource = rents;
                    Loader.Visibility = Visibility.Hidden;
                    MessageBox.Show("Dodano zamowienie");
                });
            }
            else
            {
                Dispatcher.Invoke(() =>
                {
                    Loader.Visibility = Visibility.Hidden;
                    MessageBox.Show("Bład zamówienia");
                });
            }
            
        }

        private void SendDB(string name, int hours, double price)
        {
            using (RentDBEntities1 context = new RentDBEntities1())
            {
                RentTable rent = new RentTable()
                {
                    car_name = name,
                    hours = hours,
                    price = price,
                    date = DateTime.Now
                };
                context.RentTable.Add(rent);
                context.SaveChanges();
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (CountPrice())
            {
                Loader.Visibility = Visibility.Visible;
                Thread t = new Thread(() => SendData());
                t.Start();
            }
        }

        private void typeList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<IVehicle> vehicles = loadVehicles();
            string option = typeList.SelectedItem as string;
            switch(option)
            {
                case "Wszystkie": //po prostu zaladowala sie baza ze wszystkimi
                    break;
                case "Samochody":
                    vehicles = vehicles.FindAll(x => x.Type == "Car");
                    break;
                case "Skutery":
                    vehicles = vehicles.FindAll(x => x.Type == "Scooter");
                    break;
                case "Rowery":
                    vehicles = vehicles.FindAll(x => x.Type == "Bike");
                    break;
            }
            rentList.ItemsSource = vehicles;
        }
    }
}
