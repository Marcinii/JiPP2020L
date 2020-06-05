using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
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
using AccountCreator;
using Microsoft.VisualBasic;
using AccountCreator2.Desktop;
using System.Windows.Forms;

namespace AccountCreator2.Desktop
{
    
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string password = Membership.GeneratePassword(15, 3);
        private RelayCommand ConvertCommand;
        public MainWindow()
        {
            InitializeComponent();
            serwercombo.ItemsSource = new ServersService().GetServers();
            Task task1 = new Task(() => TOCOUNTACC());
            task1.Start();
            animacja.Visibility = Visibility.Visible;
            ((Storyboard)Resources["WelcomeStoryboard"]).Begin();
            

            ConvertCommand = new RelayCommand(obj => createaccbutton(), obj => serwercombo.SelectedItem!=null && string.IsNullOrEmpty(emailbox.Text) != true && string.IsNullOrEmpty(HowManyACC.Text) != true);
            createaccbtn.Command = ConvertCommand;
            ConvertCommand = new RelayCommand(obj => ADDUsernames());
            ADDUsernamesbtn.Command = ConvertCommand;

        }
        
    
        private void TOCOUNTACC()
        {
            using(AccountCreatorEntities context = new AccountCreatorEntities())
            {
                int Count;
                Count= context.Usernames.Count<Usernames>();
                Dispatcher.Invoke(() => TOCOUNT.Text = Count.ToString());
                
            }
            
        }

        private string GetAccount()
        {
            string nickname;
            using (AccountCreatorEntities context =new AccountCreatorEntities())
            {
                nickname = context.Usernames.OrderByDescending(o => o.id).Select(o => o.username).Where(o => o.Length>1).FirstOrDefault();
                context.Database.ExecuteSqlCommand("Delete FROM Usernames Where username="+"'"+nickname + "'");
               
                AccountsAlreadyMade accounts = new AccountsAlreadyMade
                {
                   
                    username = nickname,
                    status = "Created",
                    password = password,
                };
                context.AccountsAlreadyMade.Add(accounts);
                context.SaveChanges();
            }
            
            return nickname;
        }
        private void serwercombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            
        }
        private void CreateAccount()
        {
            string serwer = ((IServer)serwercombo.SelectedItem).Serwer;
            string LastEmail = emailbox.Text;
            ((IServer)serwercombo.SelectedItem).Account_creator(serwer, LastEmail, GetAccount(), password);
           
        }
        private void createaccbutton()
        {
            if (int.Parse(TOCOUNT.Text) >= int.Parse(HowManyACC.Text))
            {
                for (int i = 0; i <= (int.Parse(HowManyACC.Text)-1); i++)
                {
                    CreateAccount();
                    Task task1 = new Task(() => TOCOUNTACC());
                    task1.Start();
                }
            }
            else
            {
                System.Windows.MessageBox.Show("Dodaj nicki do bazy");
            }
        }

        private void ADDUsernames()
        {

            string addaccount;
            
            addaccount = Interaction.InputBox("Usernames", "Dodaj nazwe konta", "", -1);
            if (addaccount.Length <= 0)
            {
                System.Windows.MessageBox.Show("Nie wpisano nicku");
            }
            else
            {
                using (AccountCreatorEntities context = new AccountCreatorEntities())
                {

                    Usernames accounts = new Usernames
                    {

                        username = addaccount
                    };
                    context.Usernames.Add(accounts);
                    context.SaveChanges();
                }
                Task task1 = new Task(() => TOCOUNTACC());
                task1.Start();
            }
           

        }
        private void rateControl_RateValueChanged(object sender, Common.Controls.RateEventArgs e)

        {
            

            using (AccountCreatorEntities context = new AccountCreatorEntities())
            {
                ocenaTable tabela = new ocenaTable()
                {
                    
                    ocena = e.Value
                };
                context.ocenaTable.Add(tabela);
                context.SaveChanges();
            }
        }
     

        private void animacjaa_Click(object sender, RoutedEventArgs e)
        {
            animacja.Visibility = Visibility.Hidden;

        }
    }
}
