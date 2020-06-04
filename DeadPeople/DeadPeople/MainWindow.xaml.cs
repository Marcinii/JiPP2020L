using DeadLogic;
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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DeadPeople
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            DeadPeopleManagmentDBEntities db = new DeadPeopleManagmentDBEntities();
            DeadTime dt = new DeadTime();
            int result = dt.deadEnd(int.Parse(txtAge.Text), int.Parse(txtLeft.Text), int.Parse(txtTraning.Text));

            Dead deadObject = new Dead()
            {

                Name = txtName.Text,
                Age = int.Parse(txtAge.Text) ,
                FinalAge = result
            };

            db.Deads.Add(deadObject);
            db.SaveChanges();
        }

        private void btnLoadGrid_Click(object sender, RoutedEventArgs e)
        {
            DeadPeopleManagmentDBEntities db = new DeadPeopleManagmentDBEntities();

            
            Thread.Sleep(3000);
            Thread watek = new Thread(mess);
            this.gridDead.ItemsSource = db.Deads.ToList();
        }

        
        static void mess()
        {
           MessageBox.Show("Proszę poczekać trwa ładowanie!");
        }
    }
}
