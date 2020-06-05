using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
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

namespace ProductInventory.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            data.SelectedDate = DateTime.Now;
            List<IInventory> Inventories = new InventoryService().GetInventories();

            ReadData(Orders, Details, OrderNumber, DetailsPaymentSum);

            if (true)
            {
                if (true)
                {
                    water.Text = Inventories[0].Name;
                    drink.Text = Inventories[1].Name;
                    bread.Text = Inventories[2].Name;
                    mayonnaise.Text = Inventories[3].Name;
                    ketchup.Text = Inventories[4].Name;
                }
                if (true)
                {
                    nazwa00.ItemsSource = Inventories[0].ItemsNames;
                    nazwa01.ItemsSource = Inventories[0].ItemsNames;
                    nazwa02.ItemsSource = Inventories[0].ItemsNames;
                    nazwa03.ItemsSource = Inventories[0].ItemsNames;
                    nazwa04.ItemsSource = Inventories[0].ItemsNames;
                    nazwa05.ItemsSource = Inventories[0].ItemsNames;
                    nazwa06.ItemsSource = Inventories[0].ItemsNames;
                    nazwa00.SelectedIndex = 0;
                    nazwa01.SelectedIndex = 1;
                    nazwa02.SelectedIndex = 2;
                    nazwa03.SelectedIndex = 3;
                    nazwa04.SelectedIndex = 4;
                    nazwa05.SelectedIndex = 5;
                    nazwa06.SelectedIndex = 6;

                    price00.Text = BetterPriceFormat(Inventories[0].Items[0].Price.ToString());
                    price01.Text = BetterPriceFormat(Inventories[0].Items[1].Price.ToString());
                    price02.Text = BetterPriceFormat(Inventories[0].Items[2].Price.ToString());
                    price03.Text = BetterPriceFormat(Inventories[0].Items[3].Price.ToString());
                    price04.Text = BetterPriceFormat(Inventories[0].Items[4].Price.ToString());
                    price05.Text = BetterPriceFormat(Inventories[0].Items[5].Price.ToString());
                    price06.Text = BetterPriceFormat(Inventories[0].Items[6].Price.ToString());
                }
                if (true)
                {
                    nazwa10.ItemsSource = Inventories[1].ItemsNames;
                    nazwa11.ItemsSource = Inventories[1].ItemsNames;
                    nazwa12.ItemsSource = Inventories[1].ItemsNames;
                    nazwa13.ItemsSource = Inventories[1].ItemsNames;
                    nazwa14.ItemsSource = Inventories[1].ItemsNames;
                    nazwa15.ItemsSource = Inventories[1].ItemsNames;
                    nazwa10.SelectedIndex = 0;
                    nazwa11.SelectedIndex = 1;
                    nazwa12.SelectedIndex = 2;
                    nazwa13.SelectedIndex = 3;
                    nazwa14.SelectedIndex = 4;
                    nazwa15.SelectedIndex = 5;

                    price10.Text = BetterPriceFormat(Inventories[1].Items[0].Price.ToString());
                    price11.Text = BetterPriceFormat(Inventories[1].Items[1].Price.ToString());
                    price12.Text = BetterPriceFormat(Inventories[1].Items[2].Price.ToString());
                    price13.Text = BetterPriceFormat(Inventories[1].Items[3].Price.ToString());
                    price14.Text = BetterPriceFormat(Inventories[1].Items[4].Price.ToString());
                    price15.Text = BetterPriceFormat(Inventories[1].Items[5].Price.ToString());
                }
                if (true)
                {
                    nazwa20.ItemsSource = Inventories[2].ItemsNames;
                    nazwa21.ItemsSource = Inventories[2].ItemsNames;
                    nazwa22.ItemsSource = Inventories[2].ItemsNames;
                    nazwa23.ItemsSource = Inventories[2].ItemsNames;
                    nazwa24.ItemsSource = Inventories[2].ItemsNames;
                    nazwa20.SelectedIndex = 0;
                    nazwa21.SelectedIndex = 1;
                    nazwa22.SelectedIndex = 2;
                    nazwa23.SelectedIndex = 3;
                    nazwa24.SelectedIndex = 4;

                    price20.Text = BetterPriceFormat(Inventories[2].Items[0].Price.ToString());
                    price21.Text = BetterPriceFormat(Inventories[2].Items[1].Price.ToString());
                    price22.Text = BetterPriceFormat(Inventories[2].Items[2].Price.ToString());
                    price23.Text = BetterPriceFormat(Inventories[2].Items[3].Price.ToString());
                    price24.Text = BetterPriceFormat(Inventories[2].Items[4].Price.ToString());
                }
                if (true)
                {
                    nazwa30.ItemsSource = Inventories[3].ItemsNames;
                    nazwa31.ItemsSource = Inventories[3].ItemsNames;
                    nazwa32.ItemsSource = Inventories[3].ItemsNames;
                    nazwa33.ItemsSource = Inventories[3].ItemsNames;
                    nazwa30.SelectedIndex = 0;
                    nazwa31.SelectedIndex = 1;
                    nazwa32.SelectedIndex = 2;
                    nazwa33.SelectedIndex = 3;

                    price30.Text = BetterPriceFormat(Inventories[3].Items[0].Price.ToString());
                    price31.Text = BetterPriceFormat(Inventories[3].Items[1].Price.ToString());
                    price32.Text = BetterPriceFormat(Inventories[3].Items[2].Price.ToString());
                    price33.Text = BetterPriceFormat(Inventories[3].Items[3].Price.ToString());
                }
                if (true)
                {
                    nazwa40.ItemsSource = Inventories[4].ItemsNames;
                    nazwa41.ItemsSource = Inventories[4].ItemsNames;
                    nazwa42.ItemsSource = Inventories[4].ItemsNames;
                    nazwa43.ItemsSource = Inventories[4].ItemsNames;
                    nazwa40.SelectedIndex = 0;
                    nazwa41.SelectedIndex = 1;
                    nazwa42.SelectedIndex = 2;
                    nazwa43.SelectedIndex = 3;

                    price40.Text = BetterPriceFormat(Inventories[4].Items[0].Price.ToString());
                    price41.Text = BetterPriceFormat(Inventories[4].Items[1].Price.ToString());
                    price42.Text = BetterPriceFormat(Inventories[4].Items[2].Price.ToString());
                    price43.Text = BetterPriceFormat(Inventories[4].Items[3].Price.ToString());
                }
            }
            SumUp();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Task t1 = new Task(() => TaskLoader());
            t1.Start();

            Task.WhenAll(t1).ContinueWith(t =>
            {
                loader.Visibility = Visibility.Hidden;
            }, TaskScheduler.FromCurrentSynchronizationContext());

            int.TryParse(OrderNumber.Text, out int orderNumber);
            double.TryParse(doZaplaty.Text, out double orderPayment);

            double detailPrice00, detailPrice01, detailPrice02, detailPrice03, detailPrice04, detailPrice05, detailPrice06, detailPrice10, detailPrice11, detailPrice12, detailPrice13, detailPrice14, detailPrice15, detailPrice20, detailPrice21, detailPrice22, detailPrice23, detailPrice24, detailPrice30, detailPrice31, detailPrice32, detailPrice33, detailPrice40, detailPrice41, detailPrice42, detailPrice43;
            int detailQuantity00, detailQuantity01, detailQuantity02, detailQuantity03, detailQuantity04, detailQuantity05, detailQuantity06, detailQuantity10, detailQuantity11, detailQuantity12, detailQuantity13, detailQuantity14, detailQuantity15, detailQuantity20, detailQuantity21, detailQuantity22, detailQuantity23, detailQuantity24, detailQuantity30, detailQuantity31, detailQuantity32, detailQuantity33, detailQuantity40, detailQuantity41, detailQuantity42, detailQuantity43;
            double detailPayment00, detailPayment01, detailPayment02, detailPayment03, detailPayment04, detailPayment05, detailPayment06, detailPayment10, detailPayment11, detailPayment12, detailPayment13, detailPayment14, detailPayment15, detailPayment20, detailPayment21, detailPayment22, detailPayment23, detailPayment24, detailPayment30, detailPayment31, detailPayment32, detailPayment33, detailPayment40, detailPayment41, detailPayment42, detailPayment43;

            if (true)
            {
                double.TryParse(price00.Text, out detailPrice00);
                int.TryParse(q00.Text, out detailQuantity00);
                double.TryParse(suma00.Text, out detailPayment00);

                double.TryParse(price01.Text, out detailPrice01);
                int.TryParse(q01.Text, out detailQuantity01);
                double.TryParse(suma01.Text, out detailPayment01);

                double.TryParse(price02.Text, out detailPrice02);
                int.TryParse(q02.Text, out detailQuantity02);
                double.TryParse(suma02.Text, out detailPayment02);

                double.TryParse(price03.Text, out detailPrice03);
                int.TryParse(q03.Text, out detailQuantity03);
                double.TryParse(suma03.Text, out detailPayment03);

                double.TryParse(price04.Text, out detailPrice04);
                int.TryParse(q04.Text, out detailQuantity04);
                double.TryParse(suma04.Text, out detailPayment04);

                double.TryParse(price05.Text, out detailPrice05);
                int.TryParse(q05.Text, out detailQuantity05);
                double.TryParse(suma05.Text, out detailPayment05);

                double.TryParse(price06.Text, out detailPrice06);
                int.TryParse(q06.Text, out detailQuantity06);
                double.TryParse(suma06.Text, out detailPayment06);
            }

            if (true)
            {
                double.TryParse(price10.Text, out detailPrice10);
                int.TryParse(q10.Text, out detailQuantity10);
                double.TryParse(suma10.Text, out detailPayment10);

                double.TryParse(price11.Text, out detailPrice11);
                int.TryParse(q11.Text, out detailQuantity11);
                double.TryParse(suma11.Text, out detailPayment11);

                double.TryParse(price12.Text, out detailPrice12);
                int.TryParse(q12.Text, out detailQuantity12);
                double.TryParse(suma12.Text, out detailPayment12);

                double.TryParse(price13.Text, out detailPrice13);
                int.TryParse(q13.Text, out detailQuantity13);
                double.TryParse(suma13.Text, out detailPayment13);

                double.TryParse(price14.Text, out detailPrice14);
                int.TryParse(q14.Text, out detailQuantity14);
                double.TryParse(suma14.Text, out detailPayment14);

                double.TryParse(price15.Text, out detailPrice15);
                int.TryParse(q15.Text, out detailQuantity15);
                double.TryParse(suma15.Text, out detailPayment15);
            }

            if (true)
            {
                double.TryParse(price20.Text, out detailPrice20);
                int.TryParse(q20.Text, out detailQuantity20);
                double.TryParse(suma20.Text, out detailPayment20);

                double.TryParse(price21.Text, out detailPrice21);
                int.TryParse(q21.Text, out detailQuantity21);
                double.TryParse(suma21.Text, out detailPayment21);

                double.TryParse(price22.Text, out detailPrice22);
                int.TryParse(q22.Text, out detailQuantity22);
                double.TryParse(suma22.Text, out detailPayment22);

                double.TryParse(price23.Text, out detailPrice23);
                int.TryParse(q23.Text, out detailQuantity23);
                double.TryParse(suma23.Text, out detailPayment23);

                double.TryParse(price24.Text, out detailPrice24);
                int.TryParse(q24.Text, out detailQuantity24);
                double.TryParse(suma24.Text, out detailPayment24);
            }

            if (true)
            {
                double.TryParse(price30.Text, out detailPrice30);
                int.TryParse(q30.Text, out detailQuantity30);
                double.TryParse(suma30.Text, out detailPayment30);

                double.TryParse(price31.Text, out detailPrice31);
                int.TryParse(q31.Text, out detailQuantity31);
                double.TryParse(suma31.Text, out detailPayment31);

                double.TryParse(price32.Text, out detailPrice32);
                int.TryParse(q32.Text, out detailQuantity32);
                double.TryParse(suma32.Text, out detailPayment32);

                double.TryParse(price33.Text, out detailPrice33);
                int.TryParse(q33.Text, out detailQuantity33);
                double.TryParse(suma33.Text, out detailPayment33);
            }

            if (true)
            {
                double.TryParse(price40.Text, out detailPrice40);
                int.TryParse(q40.Text, out detailQuantity40);
                double.TryParse(suma40.Text, out detailPayment40);

                double.TryParse(price41.Text, out detailPrice41);
                int.TryParse(q41.Text, out detailQuantity41);
                double.TryParse(suma41.Text, out detailPayment41);

                double.TryParse(price42.Text, out detailPrice42);
                int.TryParse(q42.Text, out detailQuantity42);
                double.TryParse(suma42.Text, out detailPayment42);

                double.TryParse(price43.Text, out detailPrice43);
                int.TryParse(q43.Text, out detailQuantity43);
                double.TryParse(suma43.Text, out detailPayment43);
            }

            if (true)
            {
                InsertOrder(orderNumber, (DateTime)data.SelectedDate, orderPayment);

                InsertDetail(orderNumber, (DateTime)data.SelectedDate, water.Text, nazwa00.Text, detailPrice00, detailQuantity00, detailPayment00);
                InsertDetail(orderNumber, (DateTime)data.SelectedDate, water.Text, nazwa01.Text, detailPrice01, detailQuantity01, detailPayment01);
                InsertDetail(orderNumber, (DateTime)data.SelectedDate, water.Text, nazwa02.Text, detailPrice02, detailQuantity02, detailPayment02);
                InsertDetail(orderNumber, (DateTime)data.SelectedDate, water.Text, nazwa03.Text, detailPrice03, detailQuantity03, detailPayment03);
                InsertDetail(orderNumber, (DateTime)data.SelectedDate, water.Text, nazwa04.Text, detailPrice04, detailQuantity04, detailPayment04);
                InsertDetail(orderNumber, (DateTime)data.SelectedDate, water.Text, nazwa05.Text, detailPrice05, detailQuantity05, detailPayment05);
                InsertDetail(orderNumber, (DateTime)data.SelectedDate, water.Text, nazwa06.Text, detailPrice06, detailQuantity06, detailPayment06);

                InsertDetail(orderNumber, (DateTime)data.SelectedDate, drink.Text, nazwa10.Text, detailPrice10, detailQuantity10, detailPayment10);
                InsertDetail(orderNumber, (DateTime)data.SelectedDate, drink.Text, nazwa11.Text, detailPrice11, detailQuantity11, detailPayment11);
                InsertDetail(orderNumber, (DateTime)data.SelectedDate, drink.Text, nazwa12.Text, detailPrice12, detailQuantity12, detailPayment12);
                InsertDetail(orderNumber, (DateTime)data.SelectedDate, drink.Text, nazwa13.Text, detailPrice13, detailQuantity13, detailPayment13);
                InsertDetail(orderNumber, (DateTime)data.SelectedDate, drink.Text, nazwa14.Text, detailPrice14, detailQuantity14, detailPayment14);
                InsertDetail(orderNumber, (DateTime)data.SelectedDate, drink.Text, nazwa15.Text, detailPrice15, detailQuantity15, detailPayment15);

                InsertDetail(orderNumber, (DateTime)data.SelectedDate, bread.Text, nazwa20.Text, detailPrice20, detailQuantity20, detailPayment20);
                InsertDetail(orderNumber, (DateTime)data.SelectedDate, bread.Text, nazwa21.Text, detailPrice21, detailQuantity21, detailPayment21);
                InsertDetail(orderNumber, (DateTime)data.SelectedDate, bread.Text, nazwa22.Text, detailPrice22, detailQuantity22, detailPayment22);
                InsertDetail(orderNumber, (DateTime)data.SelectedDate, bread.Text, nazwa23.Text, detailPrice23, detailQuantity23, detailPayment23);
                InsertDetail(orderNumber, (DateTime)data.SelectedDate, bread.Text, nazwa24.Text, detailPrice24, detailQuantity24, detailPayment24);

                InsertDetail(orderNumber, (DateTime)data.SelectedDate, mayonnaise.Text, nazwa30.Text, detailPrice30, detailQuantity30, detailPayment30);
                InsertDetail(orderNumber, (DateTime)data.SelectedDate, mayonnaise.Text, nazwa31.Text, detailPrice31, detailQuantity31, detailPayment31);
                InsertDetail(orderNumber, (DateTime)data.SelectedDate, mayonnaise.Text, nazwa32.Text, detailPrice32, detailQuantity32, detailPayment32);
                InsertDetail(orderNumber, (DateTime)data.SelectedDate, mayonnaise.Text, nazwa33.Text, detailPrice33, detailQuantity33, detailPayment33);

                InsertDetail(orderNumber, (DateTime)data.SelectedDate, ketchup.Text, nazwa40.Text, detailPrice40, detailQuantity40, detailPayment40);
                InsertDetail(orderNumber, (DateTime)data.SelectedDate, ketchup.Text, nazwa41.Text, detailPrice41, detailQuantity41, detailPayment41);
                InsertDetail(orderNumber, (DateTime)data.SelectedDate, ketchup.Text, nazwa42.Text, detailPrice42, detailQuantity42, detailPayment42);
                InsertDetail(orderNumber, (DateTime)data.SelectedDate, ketchup.Text, nazwa43.Text, detailPrice43, detailQuantity43, detailPayment43);
            }

            int.TryParse(OrderNumber.Text, out int oldON);
            int newON = oldON + 1;
            OrderNumber.Text = newON.ToString();

            if (true)
            {
                q00.Text = "";
                q01.Text = "";
                q02.Text = "";
                q03.Text = "";
                q04.Text = "";
                q05.Text = "";
                q06.Text = "";
                q10.Text = "";
                q11.Text = "";
                q12.Text = "";
                q13.Text = "";
                q14.Text = "";
                q15.Text = "";
                q20.Text = "";
                q21.Text = "";
                q22.Text = "";
                q23.Text = "";
                q24.Text = "";
                q30.Text = "";
                q31.Text = "";
                q32.Text = "";
                q33.Text = "";
                q40.Text = "";
                q41.Text = "";
                q42.Text = "";
                q43.Text = "";
            }
            ReadData(Orders, Details, OrderNumber, DetailsPaymentSum);
        }

        private void TaskLoader()
        {
            Dispatcher.Invoke(() => loader.Visibility = Visibility.Visible);
            Task.Delay(3000).Wait();
        }

        public void ReadData(DataGrid o, DataGrid d, TextBlock t, TextBlock s)
        {
            if(!(int.TryParse(OrderNumerOd.Text, out int ONumerOd))) { ONumerOd = -1; }
            if(!(int.TryParse(OrderNumerDo.Text, out int ONumerDo))) { ONumerDo = 1000000000; }
            if(!(DateTime.TryParse(OrderDataOd.SelectedDate.ToString(), out DateTime ODataOd))) { ODataOd = new DateTime(1990, 1, 1); }
            if(!(DateTime.TryParse(OrderDataDo.SelectedDate.ToString(), out DateTime ODataDo))) { ODataDo = new DateTime(2090, 1, 1); }
            if(!(double.TryParse(OrderKwotaOd.Text, out double OKwotaOd))) { OKwotaOd = -1; }
            if(!(double.TryParse(OrderKwotaDo.Text, out double OKwotaDo))) { OKwotaDo = 1000000000; }

            ReadOrders(o, t, ONumerOd, ONumerDo, ODataOd, ODataDo, OKwotaOd, OKwotaDo);

            if (!(int.TryParse(DetailsNrOd.Text, out int DNrOd))) { DNrOd = -1; }
            if (!(int.TryParse(DetailsNrDo.Text, out int DNrDo))) { DNrDo = 1000000000; }
            if (!(DateTime.TryParse(DetailsDataOd.SelectedDate.ToString(), out DateTime DDataOd))) { DDataOd = new DateTime(1990, 1, 1); }
            if (!(DateTime.TryParse(DetailsDataDo.SelectedDate.ToString(), out DateTime DDataDo))) { DDataDo = new DateTime(2090, 1, 1); }
            string DTyp = DetailsTyp.Text;
            string DNazwa = DetailsNazwa.Text;
            if (!(double.TryParse(DetailsCenaOd.Text, out double DCenaOd))) { DCenaOd = -1; }
            if (!(double.TryParse(DetailsCenaDo.Text, out double DCenaDo))) { DCenaDo = 1000000000; }
            if (!(int.TryParse(DetailsIloscOd.Text, out int DIloscOd))) { DIloscOd = -1; }
            if (!(int.TryParse(DetailsIloscDo.Text, out int DIloscDo))) { DIloscDo = 1000000000; }
            if (!(double.TryParse(DetailsSumaOd.Text, out double DSumaOd))) { DSumaOd = -1; }
            if (!(double.TryParse(DetailsSumaDo.Text, out double DSumaDo))) { DSumaDo = 1000000000; }

            ReadDetails(d, s, DNrOd, DNrDo, DDataOd, DDataDo, DTyp, DNazwa, DCenaOd, DCenaDo, DIloscOd, DIloscDo, DSumaOd, DSumaDo);
        }
        public static void ReadOrders(DataGrid o, TextBlock t, int ONumerOd, int ONumerDo, DateTime ODataOd, DateTime ODataDo, double OKwotaOd, double OKwotaDo)
        {

            using (OrdersEntities context = new OrdersEntities())
            {
                List<Orders> readOrder = context.Orders.ToList();

                Orders last = readOrder.Last();
                int newOrderNumber = last.Nr + 1;
                t.Text = newOrderNumber.ToString();

                List<Orders> readFilteredOrder = readOrder
                    .Where(s => s.Nr >= ONumerOd && s.Nr <= ONumerDo && s.Data >= ODataOd && s.Data <= ODataDo && s.Kwota >= OKwotaOd && s.Kwota <= OKwotaDo)
                    .ToList();
                o.ItemsSource = readFilteredOrder;
            }
        }
        public static void ReadDetails(DataGrid d, TextBlock s, int DNrOd, int DNrDo, DateTime DDataOd, DateTime DDataDo, string DTyp, string DNazwa,
            double DCenaOd, double DCenaDo, int DIloscOd, int DIloscDo, double DSumaOd, double DSumaDo)
        {
            using (DetailsEntities context = new DetailsEntities())
            {
                List<Details> readDetails = context.Details
                    .Where(w => w.Nr >= DNrOd && w.Nr <= DNrDo && w.Data >= DDataOd && w.Data <= DDataDo && w.Typ.StartsWith(DTyp) && w.Nazwa.StartsWith(DNazwa) &&
                    w.Cena>=DCenaOd && w.Cena<=DCenaDo && w.Ilosc>=DIloscOd && w.Ilosc<=DIloscDo && w.Suma >= DSumaOd && w.Suma <= DSumaDo)
                    .ToList();
                
                d.ItemsSource = readDetails;

                double Sum = 0;
                foreach (Details i in readDetails)
                {
                    Sum += i.Suma;
                }
                s.Text = Sum.ToString();
            }
        }
        public static void InsertOrder(int orderNumber, DateTime orderData, double orderPayment)
        {
            if (orderPayment != 0)
            {
                using (OrdersEntities context = new OrdersEntities())
                {
                    Orders newOrder = new Orders()
                    {
                        Nr = orderNumber,
                        Data = orderData,
                        Kwota = orderPayment
                    };
                    context.Orders.Add(newOrder);

                    context.SaveChanges();
                }
            }
        }
        public static void InsertDetail(int orderNumber, DateTime orderData, string detailType, string detailName, double detailPrice, int detailQuantity, double detailPayment)
        {
            if (detailPayment != 0)
            {
                using (DetailsEntities context = new DetailsEntities())
                {
                    Details newDetails = new Details()
                    {
                        Nr = orderNumber,
                        Data = orderData,
                        Typ = detailType,
                        Nazwa = detailName,
                        Cena = detailPrice,
                        Ilosc = detailQuantity,
                        Suma = detailPayment
                    };
                    context.Details.Add(newDetails);

                    context.SaveChanges();
                }
            }
        }

        private string BetterPriceFormat(string actual)
        {
            if (actual.Length < 3) { return actual + ",00"; }
            else if (actual.Length == 3)
            {
                if (actual.ElementAt(actual.Length - 2) == ',' || actual.ElementAt(actual.Length - 2) == ',') { return actual + '0'; }
                else { return actual + ",00"; }
            }
            else if (actual.ElementAt(actual.Length - 3) == ',' || actual.ElementAt(actual.Length - 3) == '.') { return actual; }
            else if (actual.ElementAt(actual.Length - 2) == ',' || actual.ElementAt(actual.Length - 2) == '.') { return actual + "0"; }
            else { return actual + ",00"; }
        }

        private void SumUp()
        {

            double.TryParse(suma00.Text, out double s00);
            double.TryParse(suma01.Text, out double s01);
            double.TryParse(suma02.Text, out double s02);
            double.TryParse(suma03.Text, out double s03);
            double.TryParse(suma04.Text, out double s04);
            double.TryParse(suma05.Text, out double s05);
            double.TryParse(suma06.Text, out double s06);
            double.TryParse(suma10.Text, out double s10);
            double.TryParse(suma11.Text, out double s11);
            double.TryParse(suma12.Text, out double s12);
            double.TryParse(suma13.Text, out double s13);
            double.TryParse(suma14.Text, out double s14);
            double.TryParse(suma15.Text, out double s15);
            double.TryParse(suma20.Text, out double s20);
            double.TryParse(suma21.Text, out double s21);
            double.TryParse(suma22.Text, out double s22);
            double.TryParse(suma23.Text, out double s23);
            double.TryParse(suma24.Text, out double s24);
            double.TryParse(suma30.Text, out double s30);
            double.TryParse(suma31.Text, out double s31);
            double.TryParse(suma32.Text, out double s32);
            double.TryParse(suma33.Text, out double s33);
            double.TryParse(suma40.Text, out double s40);
            double.TryParse(suma41.Text, out double s41);
            double.TryParse(suma42.Text, out double s42);
            double.TryParse(suma43.Text, out double s43);

            double result = s00 + s01 + s02 + s03 + s04 + s05 + s06 + s10 + s11 + s12 + s13 + s14 + s15 + s20 + s21 + s22 + s23 + s24 + s30 + s31 + s32 + s33 + s40 + s41 + s42 + s43;
            doZaplaty.Text = BetterPriceFormat(result.ToString());
        }

        private void q00_TextChanged(object sender, TextChangedEventArgs e)
        {
            string correctPrice = price00.Text;
            if (!(double.TryParse(correctPrice, out double price))) { price = 0; }
            if (!(double.TryParse(q00.Text, out double quantity))) { quantity = 0; }
            double result = price * quantity;
            suma00.Text = BetterPriceFormat(result.ToString());
            SumUp();
        }

        private void q01_TextChanged(object sender, TextChangedEventArgs e)
        {
            string correctPrice = price01.Text;
            if (!(double.TryParse(correctPrice, out double price))) { price = 0; }
            if (!(double.TryParse(q01.Text, out double quantity))) { quantity = 0; }
            double result = price * quantity;
            suma01.Text = BetterPriceFormat(result.ToString());
            SumUp();
        }

        private void q02_TextChanged(object sender, TextChangedEventArgs e)
        {
            string correctPrice = price02.Text;
            if (!(double.TryParse(correctPrice, out double price))) { price = 0; }
            if (!(double.TryParse(q02.Text, out double quantity))) { quantity = 0; }
            double result = price * quantity;
            suma02.Text = BetterPriceFormat(result.ToString());
            SumUp();
        }

        private void q03_TextChanged(object sender, TextChangedEventArgs e)
        {
            string correctPrice = price03.Text;
            if (!(double.TryParse(correctPrice, out double price))) { price = 0; }
            if (!(double.TryParse(q03.Text, out double quantity))) { quantity = 0; }
            double result = price * quantity;
            suma03.Text = BetterPriceFormat(result.ToString());
            SumUp();
        }

        private void q04_TextChanged(object sender, TextChangedEventArgs e)
        {
            string correctPrice = price04.Text;
            if (!(double.TryParse(correctPrice, out double price))) { price = 0; }
            if (!(double.TryParse(q04.Text, out double quantity))) { quantity = 0; }
            double result = price * quantity;
            suma04.Text = BetterPriceFormat(result.ToString());
            SumUp();
        }

        private void q05_TextChanged(object sender, TextChangedEventArgs e)
        {
            string correctPrice = price05.Text;
            if (!(double.TryParse(correctPrice, out double price))) { price = 0; }
            if (!(double.TryParse(q05.Text, out double quantity))) { quantity = 0; }
            double result = price * quantity;
            suma05.Text = BetterPriceFormat(result.ToString());
            SumUp();
        }

        private void q06_TextChanged(object sender, TextChangedEventArgs e)
        {
            string correctPrice = price06.Text;
            if (!(double.TryParse(correctPrice, out double price))) { price = 0; }
            if (!(double.TryParse(q06.Text, out double quantity))) { quantity = 0; }
            double result = price * quantity;
            suma06.Text = BetterPriceFormat(result.ToString());
            SumUp();
        }

        private void q10_TextChanged(object sender, TextChangedEventArgs e)
        {
            string correctPrice = price10.Text;
            if (!(double.TryParse(correctPrice, out double price))) { price = 0; }
            if (!(double.TryParse(q10.Text, out double quantity))) { quantity = 0; }
            double result = price * quantity;
            suma10.Text = BetterPriceFormat(result.ToString());
            SumUp();
        }

        private void q11_TextChanged(object sender, TextChangedEventArgs e)
        {
            string correctPrice = price11.Text;
            if (!(double.TryParse(correctPrice, out double price))) { price = 0; }
            if (!(double.TryParse(q11.Text, out double quantity))) { quantity = 0; }
            double result = price * quantity;
            suma11.Text = BetterPriceFormat(result.ToString());
            SumUp();
        }

        private void q12_TextChanged(object sender, TextChangedEventArgs e)
        {
            string correctPrice = price12.Text;
            if (!(double.TryParse(correctPrice, out double price))) { price = 0; }
            if (!(double.TryParse(q12.Text, out double quantity))) { quantity = 0; }
            double result = price * quantity;
            suma12.Text = BetterPriceFormat(result.ToString());
            SumUp();
        }

        private void q13_TextChanged(object sender, TextChangedEventArgs e)
        {
            string correctPrice = price13.Text;
            if (!(double.TryParse(correctPrice, out double price))) { price = 0; }
            if (!(double.TryParse(q13.Text, out double quantity))) { quantity = 0; }
            double result = price * quantity;
            suma13.Text = BetterPriceFormat(result.ToString());
            SumUp();
        }

        private void q14_TextChanged(object sender, TextChangedEventArgs e)
        {
            string correctPrice = price14.Text;
            if (!(double.TryParse(correctPrice, out double price))) { price = 0; }
            if (!(double.TryParse(q14.Text, out double quantity))) { quantity = 0; }
            double result = price * quantity;
            suma14.Text = BetterPriceFormat(result.ToString());
            SumUp();
        }

        private void q15_TextChanged(object sender, TextChangedEventArgs e)
        {
            string correctPrice = price15.Text;
            if (!(double.TryParse(correctPrice, out double price))) { price = 0; }
            if (!(double.TryParse(q15.Text, out double quantity))) { quantity = 0; }
            double result = price * quantity;
            suma15.Text = BetterPriceFormat(result.ToString());
            SumUp();
        }

        private void q20_TextChanged(object sender, TextChangedEventArgs e)
        {
            string correctPrice = price20.Text;
            if (!(double.TryParse(correctPrice, out double price))) { price = 0; }
            if (!(double.TryParse(q20.Text, out double quantity))) { quantity = 0; }
            double result = price * quantity;
            suma20.Text = BetterPriceFormat(result.ToString());
            SumUp();
        }

        private void q21_TextChanged(object sender, TextChangedEventArgs e)
        {
            string correctPrice = price21.Text;
            if (!(double.TryParse(correctPrice, out double price))) { price = 0; }
            if (!(double.TryParse(q21.Text, out double quantity))) { quantity = 0; }
            double result = price * quantity;
            suma21.Text = BetterPriceFormat(result.ToString());
            SumUp();
        }

        private void q22_TextChanged(object sender, TextChangedEventArgs e)
        {
            string correctPrice = price22.Text;
            if (!(double.TryParse(correctPrice, out double price))) { price = 0; }
            if (!(double.TryParse(q22.Text, out double quantity))) { quantity = 0; }
            double result = price * quantity;
            suma22.Text = BetterPriceFormat(result.ToString());
            SumUp();
        }

        private void q23_TextChanged(object sender, TextChangedEventArgs e)
        {
            string correctPrice = price23.Text;
            if (!(double.TryParse(correctPrice, out double price))) { price = 0; }
            if (!(double.TryParse(q23.Text, out double quantity))) { quantity = 0; }
            double result = price * quantity;
            suma23.Text = BetterPriceFormat(result.ToString());
            SumUp();
        }

        private void q24_TextChanged(object sender, TextChangedEventArgs e)
        {
            string correctPrice = price24.Text;
            if (!(double.TryParse(correctPrice, out double price))) { price = 0; }
            if (!(double.TryParse(q24.Text, out double quantity))) { quantity = 0; }
            double result = price * quantity;
            suma24.Text = BetterPriceFormat(result.ToString());
            SumUp();
        }

        private void q30_TextChanged(object sender, TextChangedEventArgs e)
        {
            string correctPrice = price30.Text;
            if (!(double.TryParse(correctPrice, out double price))) { price = 0; }
            if (!(double.TryParse(q30.Text, out double quantity))) { quantity = 0; }
            double result = price * quantity;
            suma30.Text = BetterPriceFormat(result.ToString());
            SumUp();
        }

        private void q31_TextChanged(object sender, TextChangedEventArgs e)
        {
            string correctPrice = price31.Text;
            if (!(double.TryParse(correctPrice, out double price))) { price = 0; }
            if (!(double.TryParse(q31.Text, out double quantity))) { quantity = 0; }
            double result = price * quantity;
            suma31.Text = BetterPriceFormat(result.ToString());
            SumUp();
        }

        private void q32_TextChanged(object sender, TextChangedEventArgs e)
        {
            string correctPrice = price32.Text;
            if (!(double.TryParse(correctPrice, out double price))) { price = 0; }
            if (!(double.TryParse(q32.Text, out double quantity))) { quantity = 0; }
            double result = price * quantity;
            suma32.Text = BetterPriceFormat(result.ToString());
            SumUp();
        }

        private void q33_TextChanged(object sender, TextChangedEventArgs e)
        {
            string correctPrice = price33.Text;
            if (!(double.TryParse(correctPrice, out double price))) { price = 0; }
            if (!(double.TryParse(q33.Text, out double quantity))) { quantity = 0; }
            double result = price * quantity;
            suma33.Text = BetterPriceFormat(result.ToString());
            SumUp();
        }

        private void q40_TextChanged(object sender, TextChangedEventArgs e)
        {
            string correctPrice = price40.Text;
            if (!(double.TryParse(correctPrice, out double price))) { price = 0; }
            if (!(double.TryParse(q40.Text, out double quantity))) { quantity = 0; }
            double result = price * quantity;
            suma40.Text = BetterPriceFormat(result.ToString());
            SumUp();
        }

        private void q41_TextChanged(object sender, TextChangedEventArgs e)
        {
            string correctPrice = price41.Text;
            if (!(double.TryParse(correctPrice, out double price))) { price = 0; }
            if (!(double.TryParse(q41.Text, out double quantity))) { quantity = 0; }
            double result = price * quantity;
            suma41.Text = BetterPriceFormat(result.ToString());
            SumUp();
        }

        private void q42_TextChanged(object sender, TextChangedEventArgs e)
        {
            string correctPrice = price42.Text;
            if (!(double.TryParse(correctPrice, out double price))) { price = 0; }
            if (!(double.TryParse(q42.Text, out double quantity))) { quantity = 0; }
            double result = price * quantity;
            suma42.Text = BetterPriceFormat(result.ToString());
            SumUp();
        }

        private void q43_TextChanged(object sender, TextChangedEventArgs e)
        {
            string correctPrice = price43.Text;
            if (!(double.TryParse(correctPrice, out double price))) { price = 0; }
            if (!(double.TryParse(q43.Text, out double quantity))) { quantity = 0; }
            double result = price * quantity;
            suma43.Text = BetterPriceFormat(result.ToString());
            SumUp();
        }

        private void nazwa00_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TextChangedEventArgs w = null;
            List<IInventory> Inventories = new InventoryService().GetInventories();
            price00.Text = BetterPriceFormat(((Item)Inventories[0].Items[nazwa00.SelectedIndex]).Price.ToString());
            q00_TextChanged(sender, w);
            SumUp();
        }

        private void nazwa01_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TextChangedEventArgs w = null;
            List<IInventory> Inventories = new InventoryService().GetInventories();
            price01.Text = BetterPriceFormat(((Item)Inventories[0].Items[nazwa01.SelectedIndex]).Price.ToString());
            q01_TextChanged(sender, w);
            SumUp();
        }

        private void nazwa02_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TextChangedEventArgs w = null;
            List<IInventory> Inventories = new InventoryService().GetInventories();
            price02.Text = BetterPriceFormat(((Item)Inventories[0].Items[nazwa02.SelectedIndex]).Price.ToString());
            q02_TextChanged(sender, w);
            SumUp();
        }

        private void nazwa03_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TextChangedEventArgs w = null;
            List<IInventory> Inventories = new InventoryService().GetInventories();
            price03.Text = BetterPriceFormat(((Item)Inventories[0].Items[nazwa03.SelectedIndex]).Price.ToString());
            q03_TextChanged(sender, w);
            SumUp();
        }

        private void nazwa04_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TextChangedEventArgs w = null;
            List<IInventory> Inventories = new InventoryService().GetInventories();
            price04.Text = BetterPriceFormat(((Item)Inventories[0].Items[nazwa04.SelectedIndex]).Price.ToString());
            q04_TextChanged(sender, w);
            SumUp();
        }

        private void nazwa05_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TextChangedEventArgs w = null;
            List<IInventory> Inventories = new InventoryService().GetInventories();
            price05.Text = BetterPriceFormat(((Item)Inventories[0].Items[nazwa05.SelectedIndex]).Price.ToString());
            q05_TextChanged(sender, w);
            SumUp();
        }

        private void nazwa06_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TextChangedEventArgs w = null;
            List<IInventory> Inventories = new InventoryService().GetInventories();
            price06.Text = BetterPriceFormat(((Item)Inventories[0].Items[nazwa06.SelectedIndex]).Price.ToString());
            q06_TextChanged(sender, w);
            SumUp();
        }

        private void nazwa10_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TextChangedEventArgs w = null;
            List<IInventory> Inventories = new InventoryService().GetInventories();
            price10.Text = BetterPriceFormat(((Item)Inventories[1].Items[nazwa10.SelectedIndex]).Price.ToString());
            q10_TextChanged(sender, w);
            SumUp();
        }

        private void nazwa11_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TextChangedEventArgs w = null;
            List<IInventory> Inventories = new InventoryService().GetInventories();
            price11.Text = BetterPriceFormat(((Item)Inventories[1].Items[nazwa11.SelectedIndex]).Price.ToString());
            q11_TextChanged(sender, w);
            SumUp();
        }

        private void nazwa12_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TextChangedEventArgs w = null;
            List<IInventory> Inventories = new InventoryService().GetInventories();
            price12.Text = BetterPriceFormat(((Item)Inventories[1].Items[nazwa12.SelectedIndex]).Price.ToString());
            q12_TextChanged(sender, w);
            SumUp();
        }

        private void nazwa13_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TextChangedEventArgs w = null;
            List<IInventory> Inventories = new InventoryService().GetInventories();
            price13.Text = BetterPriceFormat(((Item)Inventories[1].Items[nazwa13.SelectedIndex]).Price.ToString());
            q13_TextChanged(sender, w);
            SumUp();
        }

        private void nazwa14_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TextChangedEventArgs w = null;
            List<IInventory> Inventories = new InventoryService().GetInventories();
            price14.Text = BetterPriceFormat(((Item)Inventories[1].Items[nazwa14.SelectedIndex]).Price.ToString());
            q14_TextChanged(sender, w);
            SumUp();
        }

        private void nazwa15_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TextChangedEventArgs w = null;
            List<IInventory> Inventories = new InventoryService().GetInventories();
            price15.Text = BetterPriceFormat(((Item)Inventories[1].Items[nazwa15.SelectedIndex]).Price.ToString());
            q15_TextChanged(sender, w);
            SumUp();
        }

        private void nazwa20_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TextChangedEventArgs w = null;
            List<IInventory> Inventories = new InventoryService().GetInventories();
            price20.Text = BetterPriceFormat(((Item)Inventories[2].Items[nazwa20.SelectedIndex]).Price.ToString());
            q20_TextChanged(sender, w);
            SumUp();
        }

        private void nazwa21_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TextChangedEventArgs w = null;
            List<IInventory> Inventories = new InventoryService().GetInventories();
            price21.Text = BetterPriceFormat(((Item)Inventories[2].Items[nazwa21.SelectedIndex]).Price.ToString());
            q21_TextChanged(sender, w);
            SumUp();
        }

        private void nazwa22_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TextChangedEventArgs w = null;
            List<IInventory> Inventories = new InventoryService().GetInventories();
            price22.Text = BetterPriceFormat(((Item)Inventories[2].Items[nazwa22.SelectedIndex]).Price.ToString());
            q22_TextChanged(sender, w);
            SumUp();
        }

        private void nazwa23_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TextChangedEventArgs w = null;
            List<IInventory> Inventories = new InventoryService().GetInventories();
            price23.Text = BetterPriceFormat(((Item)Inventories[2].Items[nazwa23.SelectedIndex]).Price.ToString());
            q23_TextChanged(sender, w);
            SumUp();
        }

        private void nazwa24_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TextChangedEventArgs w = null;
            List<IInventory> Inventories = new InventoryService().GetInventories();
            price24.Text = BetterPriceFormat(((Item)Inventories[2].Items[nazwa24.SelectedIndex]).Price.ToString());
            q24_TextChanged(sender, w);
            SumUp();
        }

        private void nazwa30_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TextChangedEventArgs w = null;
            List<IInventory> Inventories = new InventoryService().GetInventories();
            price30.Text = BetterPriceFormat(((Item)Inventories[3].Items[nazwa30.SelectedIndex]).Price.ToString());
            q30_TextChanged(sender, w);
            SumUp();
        }

        private void nazwa31_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TextChangedEventArgs w = null;
            List<IInventory> Inventories = new InventoryService().GetInventories();
            price31.Text = BetterPriceFormat(((Item)Inventories[3].Items[nazwa31.SelectedIndex]).Price.ToString());
            q31_TextChanged(sender, w);
            SumUp();
        }

        private void nazwa32_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TextChangedEventArgs w = null;
            List<IInventory> Inventories = new InventoryService().GetInventories();
            price32.Text = BetterPriceFormat(((Item)Inventories[3].Items[nazwa32.SelectedIndex]).Price.ToString());
            q32_TextChanged(sender, w);
        }

        private void nazwa33_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TextChangedEventArgs w = null;
            List<IInventory> Inventories = new InventoryService().GetInventories();
            price33.Text = BetterPriceFormat(((Item)Inventories[3].Items[nazwa33.SelectedIndex]).Price.ToString());
            q33_TextChanged(sender, w);
            SumUp();
        }

        private void nazwa40_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TextChangedEventArgs w = null;
            List<IInventory> Inventories = new InventoryService().GetInventories();
            price40.Text = BetterPriceFormat(((Item)Inventories[4].Items[nazwa40.SelectedIndex]).Price.ToString());
            q40_TextChanged(sender, w);
            SumUp();
        }

        private void nazwa41_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TextChangedEventArgs w = null;
            List<IInventory> Inventories = new InventoryService().GetInventories();
            price41.Text = BetterPriceFormat(((Item)Inventories[4].Items[nazwa41.SelectedIndex]).Price.ToString());
            q41_TextChanged(sender, w);
            SumUp();
        }

        private void nazwa42_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TextChangedEventArgs w = null;
            List<IInventory> Inventories = new InventoryService().GetInventories();
            price42.Text = BetterPriceFormat(((Item)Inventories[4].Items[nazwa42.SelectedIndex]).Price.ToString());
            q42_TextChanged(sender, w);
            SumUp();
        }

        private void nazwa43_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TextChangedEventArgs w = null;
            List<IInventory> Inventories = new InventoryService().GetInventories();
            price43.Text = BetterPriceFormat(((Item)Inventories[4].Items[nazwa43.SelectedIndex]).Price.ToString());
            q43_TextChanged(sender, w);
            SumUp();
        }

        private void OrderSubmitFilter_Click(object sender, RoutedEventArgs e)
        {
            ReadData(Orders, Details, OrderNumber, DetailsPaymentSum);
        }

        private void DetailsSubmitFilter_Click(object sender, RoutedEventArgs e)
        {
            ReadData(Orders, Details, OrderNumber, DetailsPaymentSum);
        }
    }
}
