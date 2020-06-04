using BankApplication.GUI.AppUserControl.AccountListItemControl;
using BankApplication.Library.AccountUtil;
using BankApplication.Library.LoginUtil;
using System;
using System.Windows;
using UnitConverter.Application.Command;

namespace BankApplication.GUI.AppWindow
{
    /// <summary>
    /// Interaction logic for AccountListWindow.xaml
    /// </summary>
    public partial class AccountListWindow : Window
    {
        private LoginService loginService;
        private AccountService accountService;
        private int selectedAccountItemIndex;

        public AccountListWindow()
        {
            this.loginService = ((App)Application.Current).loginService;
            this.accountService = ((App)Application.Current).accountService;
            this.selectedAccountItemIndex = 0;

            InitializeComponent();

            this.Title = "JakiśBankXD - Lista kont użytkownika " + this.loginService.currentUser.firstName + " " + this.loginService.currentUser.lastName;

            this.loginService.currentUser.accounts.ForEach(account =>
            {
                AccountListItem item = new AccountListItem
                {
                    text = account.name,
                    selected = this.accountService.currentAccount.name == account.name
                };

                item.onChecked += Item_onChecked;

                this.accountListStackPanel.Children.Add(item);
            });

            this.selectAccountItemButton.Command = new ButtonCommand(
                x => selectAccount(),
                x =>
                {
                    for(int i = 0; i < this.accountListStackPanel.Children.Count; i++)
                        if (((AccountListItem)this.accountListStackPanel.Children[i]).selected)
                            return true;

                    return false;
                }
            );

            this.createAccountButton.Command = new ButtonCommand(x => createAccount());

            this.accountService.onCreate += AccountService_onCreate;
        }



        /// <summary>
        /// Metoda, która wykonuje się w momencie zmiany stanu zaznaczenia kontrolki <see cref="AccountListItem"/>.
        /// Metoda ta wyłącza zaznaczenie kontrolek oprócz tej, która została aktualnie kliknięta
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Item_onChecked(object sender, EventArgs e)
        {
            for (int i = 0; i < this.accountListStackPanel.Children.Count; i++)
                ((AccountListItem)this.accountListStackPanel.Children[i]).selected = false;

            ((AccountListItem)sender).selected = true;

            this.selectedAccountItemIndex = this.accountListStackPanel.Children.IndexOf((AccountListItem)sender);
        }



        /// <summary>
        /// Metoda, ma za zadanie wybrać aktualnie zaznaczone konto bankowe
        /// </summary>
        private void selectAccount()
        {
            this.accountService.selectAccount(this.selectedAccountItemIndex);
            this.Close();
        }



        /// <summary>
        /// Metoda otwiera nowe okno do tworzenia nowego konta bankowego
        /// </summary>
        /// <see cref="CreateBankAccountWindow"/>
        private void createAccount() => new CreateBankAccountWindow().ShowDialog();



        /// <summary>
        /// Metoda wywołująca się w momencie utworzenia nowego konta bankowego.
        /// Po utworzeniu konta metoda ta dodaje do wyświetlanej listy nowe konto, które
        /// użytkownik może sobie wybrać.
        /// </summary>
        /// <param name="account"></param>
        private void AccountService_onCreate(Account account)
        {
            AccountListItem item = new AccountListItem
            {
                text = account.name,
                selected = this.accountService.currentAccount.name == account.name
            };

            item.onChecked += Item_onChecked;

            this.accountListStackPanel.Children.Add(item);
        }
    }
}
