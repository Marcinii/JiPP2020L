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
using przelicznik;
using przelicznik.Logic;
using UnitConverter.Desktop;

namespace DesktopAPP
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int clock = 0;
      

        public MainWindow()
        {

            InitializeComponent();
            convCombobox.ItemsSource = new KonwerterService().GetConverters();
            statscombobox.ItemsSource = new KonwerterService().GetConverters();

            using (HomebaseEntities1 context = new HomebaseEntities1())
            {
                int results = context.ocenatable
                    .OrderByDescending(o => o.idocena)
                    .Select(o => o.ocena).FirstOrDefault();
                rateControl.Rate =results;
               
            }
            ConvertCommand = new RelayCommand(obj => Convert(), obj => unitFrombox.SelectedItem != null && unitTobox.SelectedItem != null && string.IsNullOrEmpty(inputTextBox.Text) != true);
            Button.Command = ConvertCommand;
            ConvertCommand = new RelayCommand(obj => clockbtn(), obj => unitFrombox.SelectedItem != null && unitTobox.SelectedItem != null && string.IsNullOrEmpty(inputTextBox.Text) != true);
            clockbutton.Command = ConvertCommand;
            ConvertCommand = new RelayCommand(obj => btnfordate(), obj => unitFrombox.SelectedItem != null && unitTobox.SelectedItem != null && string.IsNullOrEmpty(inputTextBox.Text) != true);
            buttonfordate.Command = ConvertCommand;
            ConvertCommand = new RelayCommand(obj => leftbtncl(), obj => unitFrombox.SelectedItem != null && unitTobox.SelectedItem != null && string.IsNullOrEmpty(inputTextBox.Text) != true);
            leftbtn.Command = ConvertCommand;
            ConvertCommand = new RelayCommand(obj => rightbtncl(), obj => unitFrombox.SelectedItem != null && unitTobox.SelectedItem != null && string.IsNullOrEmpty(inputTextBox.Text) != true);
            rightbtn.Command = ConvertCommand;
            ConvertCommand = new RelayCommand(obj => mousebtn(), obj => unitFrombox.SelectedItem != null && unitTobox.SelectedItem != null && string.IsNullOrEmpty(inputTextBox.Text) != true);
            mostusedbtn.Command = ConvertCommand;
            

        }
        private void convCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            unitFrombox.ItemsSource = ((IConverter)convCombobox.SelectedItem).Units;
            unitTobox.ItemsSource = ((IConverter)convCombobox.SelectedItem).Units;
        }
        private void clockbtn()
        {      
            dwukropektext.Text = ":";
            minutybox.Visibility = 0;
            minutesb.Visibility = 0;
            clock = 1;          

        }
        private RelayCommand ConvertCommand;
        public void Convert()
        {

            string inputText = inputTextBox.Text;
            decimal inputValue = decimal.Parse(inputText);
            decimal result = ((IConverter)convCombobox.SelectedItem).Convert(
                unitFrombox.SelectedItem.ToString(),
                unitTobox.SelectedItem.ToString(),
                inputValue);
            DateTime TimeNow = DateTime.Now;
            unitFrombox.SelectedItem.ToString();
            using (HomebaseEntities1 context = new HomebaseEntities1())
            {
                zapissql tabela = new zapissql()
                {
                    converter = ((IConverter)convCombobox.SelectedItem).Name,
                    unitfrom = unitFrombox.SelectedItem.ToString(),
                    unitto = unitTobox.SelectedItem.ToString(),
                    inputvalue = inputValue,
                    outputvalue = result.ToString(),
                    time = TimeNow,

                };
                context.zapissql.Add(tabela);              
                context.SaveChanges();
             
            }
            outputText.Text = result.ToString();
            if (clock == 1)
            {
                if (inputValue < 12)
                {
                    clocktextblock.Text = "AM";                  
                }
                if (inputValue >= 12)
                {
                    clocktextblock.Text = "PM";                   
                }
                minutesb.Text = ":" + minutybox.Text;
             
                double min = Decimal.ToInt32(result)*30 + (Double.Parse(minutybox.Text) * 0.5);             
                clockRotation.Angle = min+90;
                ((Storyboard)Resources["Storyboard1"]).Begin();
                using (HomebaseEntities1 context = new HomebaseEntities1())
                {
                    zapissql tabela = new zapissql()
                    {
                        converter = ((IConverter)convCombobox.SelectedItem).Name,
                    unitfrom = unitFrombox.SelectedItem.ToString(),
                        unitto = unitTobox.SelectedItem.ToString(),
                        inputvalue = inputValue,
                        outputvalue = result.ToString(),
                        time = TimeNow,
                    };
                    context.zapissql.Add(tabela);
                    context.SaveChanges();
                }
            }
        }
        private int nextpage = 0;
        public void metodakonwertera()
        {

            Dispatcher.Invoke(() => rodzajbox = ((IConverter)statscombobox.SelectedItem).Name);
           
            if (rodzajbox == "Temperatury")
                using (HomebaseEntities1 context = new HomebaseEntities1())
                {
                    List<zapissql> tabela = context.zapissql
                        .Where(b => b.converter == "Temperatury")
                        .OrderBy(b => b.id)
                        .Skip(nextpage)
                        .Take(20)
                        .ToList();

                    Dispatcher.Invoke(() => BazaStatystyk.ItemsSource = tabela);
                }
            else if (rodzajbox == "Długości")
                using (HomebaseEntities1 context = new HomebaseEntities1())
                {
                    List<zapissql> tabela = context.zapissql
                        .Where(b => b.converter == "Długości")
                        .OrderBy(b => b.id)
                        .Skip(nextpage)
                        .Take(20)
                        .ToList();

                    Dispatcher.Invoke(() => BazaStatystyk.ItemsSource = tabela);
                }
            else if (rodzajbox == "wagi")
                using (HomebaseEntities1 context = new HomebaseEntities1())
                {
                    List<zapissql> tabela = context.zapissql
                        .Where(b => b.converter == "wagi")
                        .OrderBy(b => b.id)
                        .Skip(nextpage)
                        .Take(20)
                        .ToList();

                    Dispatcher.Invoke(() => BazaStatystyk.ItemsSource = tabela);
                }
            else if (rodzajbox == "Czas24")
                using (HomebaseEntities1 context = new HomebaseEntities1())
                {
                    List<zapissql> tabela = context.zapissql
                        .Where(b => b.converter == "Czas24")
                        .OrderBy(b => b.id)
                        .Skip(nextpage)
                        .Take(20)
                        .ToList();

                    Dispatcher.Invoke(() => BazaStatystyk.ItemsSource = tabela);
                }
            else if (rodzajbox == "Czas")
                using (HomebaseEntities1 context = new HomebaseEntities1())
                {
                    List<zapissql> tabela = context.zapissql
                        .Where(b => b.converter == "Czas")
                        .OrderBy(b => b.id)
                        .Skip(nextpage)
                        .Take(20)
                        .ToList();

                    Dispatcher.Invoke(() => BazaStatystyk.ItemsSource = tabela);
                }
        }

     
        public void konwertowaniepodacie()
        {
            
                string date1 = Datefrom.Text;
                DateTime date11 = DateTime.Parse(date1);

                string date2 = Dateto.Text;
                DateTime date22 = DateTime.Parse(date2);

                using (HomebaseEntities1 context = new HomebaseEntities1())
                {
                    List<zapissql> tabela = context.zapissql
                        .Where(b => b.time > date11)
                        .Where(b => b.time < date22)
                        .OrderBy(b => b.id)
                        .Skip(nextpage)
                        .Take(20)
                        .ToList();

                    foreach (zapissql b in tabela)
                    {
                    Dispatcher.Invoke(() => BazaStatystyk.ItemsSource = tabela);
                }
                }
            }
        
        private void inputTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void unitFrombox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
       

        private void LoadData(CancellationToken ct)
        {
            
                
            for (int i = 0; i < 10; i++)
            {
                ct.ThrowIfCancellationRequested();

                Thread.Sleep(100);
            }
           
        }
        private void anulujbtn(object sender, RoutedEventArgs e)
        {
            tokenSource.Cancel();
        }
        CancellationTokenSource tokenSource;
        private string rodzajbox;

        private void statscombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            tokenSource = new CancellationTokenSource();
            gridzacm.Visibility = Visibility.Visible;
            path.Visibility = Visibility.Visible;
           ((Storyboard)Resources["Storyboard3"]).Begin();
            Task task1 = new Task(() => metodakonwertera());
            task1.Start();
            Task task2 = new Task(() => LoadData(tokenSource.Token), tokenSource.Token);
            task2.Start();
            Task.WhenAll(task1, task2).ContinueWith(t =>
            {
                if (t.IsFaulted)
                {
                    MessageBox.Show("Wystąpił błąd");
                }

                Dispatcher.Invoke(() => gridzacm.Visibility = Visibility.Hidden);
                Dispatcher.Invoke(() => path.Visibility = Visibility.Hidden);
            });
            
        }

       

        private void btnfordate()
        {
            konwertowaniepodacie();
        }

        private void leftbtncl()
        {
            nextpage = nextpage - 20;
            pagenumber.Text = nextpage.ToString();
            metodakonwertera();
        }

        private void rightbtncl()
        {
            nextpage = nextpage + 20;
            pagenumber.Text = nextpage.ToString();
            metodakonwertera();
        }

        private void mousebtn()
        
        {
            using (HomebaseEntities1 context = new HomebaseEntities1())
            {
 
                    string date1 = Datefrom.Text;
                    DateTime date11 = DateTime.Parse(date1);

                    string date2 = Dateto.Text;
                    DateTime date22 = DateTime.Parse(date2);

                    var asdasdasd = context.zapissql.AsEnumerable()
                                   .Where(b => b.time > date11)
                                   .Where(b => b.time < date22)
                                   .GroupBy(b => b.converter)
                                   .Select(b => new { Str = b.Key, Count = b.Count() })
                                   .OrderByDescending(b => b.Count)
                                   .Take(3);
                    foreach (var item in asdasdasd)
                    {
                        BazaStatystyk.ItemsSource = asdasdasd;
                    }              
            }
        }

        private void rateControl_RateValueChanged(object sender, Common.Controls.RateEventArgs e)
            
        {
            int idoceny;
            using (HomebaseEntities1 context = new HomebaseEntities1())
            {
                    idoceny = context.ocenatable
                    .OrderByDescending(o => o.idocena)
                    .Select(o => o.idocena).FirstOrDefault();         
            }

            using (HomebaseEntities1 context = new HomebaseEntities1())
            {
                ocenatable tabela = new ocenatable()
                {
                    idocena=idoceny+1,
                    ocena=e.Value
                };
                context.ocenatable.Add(tabela);
                context.SaveChanges();
            }
        }

      
    }
}

