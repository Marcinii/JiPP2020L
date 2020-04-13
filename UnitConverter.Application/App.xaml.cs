using System.Windows;
using UnitConverter.Library.History;
using UnitConverter.Library.OperationUtil.Repository;

namespace UnitConverter.Application
{
    /// <summary>
    /// Logika interakcji dla klasy App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
        public OperationRepository repository { get; private set; }
        protected OperationRepositoryInitializer initializer;
        protected CustomDatabaseContext customDatabaseContext;

        protected override void OnStartup(StartupEventArgs e)
        {
            this.repository = new OperationRepository();
            this.customDatabaseContext = new CustomDatabaseContext();
            this.initializer = new OperationRepositoryInitializer(this.repository, this.customDatabaseContext);


            this.initializer.initializeRepository();
        }
    }
}
