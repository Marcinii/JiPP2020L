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
using System.Data.SqlClient;
using System.Data;

namespace Wspolne.Kontrolki
{
    /// <summary>
    /// Interaction logic for Ocen.xaml
    /// </summary>
    public partial class Ocen : UserControl
    {

        public Ocen()
        {
            InitializeComponent();
            WartoscOcenyZmieniona += Ocen_WartoscOcenyZmieniona1;
        }

        private void Ocen_WartoscOcenyZmieniona1(int wartosc)
        {
            using (SqlConnection connection = new SqlConnection("Data Source=(local)\\SQLEXPRESS;Initial Catalog=jipp4;Integrated Security=True;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {

                connection.Open();

                SqlCommand command = new SqlCommand("INSERT INTO ZADANIE6(Ocena) VALUES(@param1)", connection);

                command.Parameters.AddWithValue("@param1", wartosc);
                command.ExecuteNonQuery();
            }
        }



        public int ocenWartosc;
        public int test=0;
        public int doBD;

        public event DOcena WartoscOcenyZmieniona;

        public int OcenWartosc
        {
            get { return ocenWartosc; }
            set 
            { 
                   ocenWartosc = value;
                    //ZaktualizujPrzyciski();
                if (WartoscOcenyZmieniona != null)
                {
                    WartoscOcenyZmieniona(ocenWartosc);
                }
                ZaktualizujPrzyciski();
            }
            
        }










        private void ZaktualizujPrzyciski()
        {
            //MessageBox.Show(test.ToString());
            //Funkcja sprawdzajaca czy przycisk byl juz wcisniety
            if (test == ocenWartosc)
            {
                //MessageBox.Show(test.ToString());
                ZerujPrzyciski();
                test = 0;
                return;
            }

            foreach (var b in ocenyGrid.Children)
            {
                ((Button)b).Background = new SolidColorBrush(Colors.White);
            }
            if(OcenWartosc>0)
            {
                ((Button)ocenyGrid.Children[OcenWartosc - 1]).Background = new SolidColorBrush(Colors.Yellow);

                for(int i=0;i<OcenWartosc;i++)
                {
                    ((Button)ocenyGrid.Children[i]).Background = new SolidColorBrush(Colors.Yellow);
                }
            }
            
            test = OcenWartosc;        }





        //Sluzy do zerowania kolorow do białego jesli przycisk byl juz wcisniety
        private void ZerujPrzyciski()
        {
            foreach (var b in ocenyGrid.Children)
            {
                ((Button)b).Background = new SolidColorBrush(Colors.White);
            }
        }





        public void buttonOcen1_Click_1(object sender, RoutedEventArgs e)
        {
            OcenWartosc = ocenyGrid.Children.IndexOf((Button)sender) + 1;
            ocenWartosc = OcenWartosc;
            //ZaktualizujPrzyciski();
        }
        public delegate void DOcena(int wartosc);
    }
}
