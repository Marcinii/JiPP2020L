using BankApplication.Library.AccountUtil;
using BankApplication.Library.Context;
using BankApplication.Library.LoginUtil;
using BankApplication.Library.RegisterUtil;
using BankApplication.Library.TransactionUtil;
using BankApplication.Library.UserUtil;
using System.Windows;

namespace BankApplication.GUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public CustomDatabaseContext customDatabaseContext { get; private set; }
        public UserService userService { get; private set; }
        public LoginService loginService { get; private set; }
        public RegisterService registerService { get; private set; }
        public AccountService accountService { get; private set; }
        public TransactionService transactionService { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            this.customDatabaseContext = new CustomDatabaseContext();
            this.userService = new UserService(this.customDatabaseContext);
            this.loginService = new LoginService(this.customDatabaseContext);
            this.registerService = new RegisterService(this.customDatabaseContext);
            this.accountService = new AccountService(this.customDatabaseContext, this.loginService);
            this.transactionService = new TransactionService(this.accountService, this.customDatabaseContext);
        }
    }
}
