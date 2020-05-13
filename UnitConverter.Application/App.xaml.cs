using System.Reflection.Emit;
using System.Windows;
using UnitConverter.Application.AppUserControl.LoadingSpinnerControl;
using UnitConverter.Application.AppWindow;
using UnitConverter.Application.Runner;
using UnitConverter.Library.History;
using UnitConverter.Library.OperationUtil;
using UnitConverter.Library.OperationUtil.Repository;
using UnitConverter.Library.TaskUtil.Group;
using UnitConverter.Library.TaskUtil.Parameter;
using UnitConverter.Library.TypeUtil.Number;

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

            TaskGroup group = (TaskGroup)this.repository.findOperationById(3).task;

            this.repository.findOperationById(3).task.addParameter(new InputTaskParameter("spinner", typeof(LoadingSpinner)));

            group.getAllTasks()[0].addParameter(new InputTaskParameter("label", typeof(Label)));
            group.getAllTasks()[0].addParameter(new InputTaskParameter("ratingInfoWindow", typeof(RatingInfoWindow)));
            group.getAllTasks()[0].beforeRun(new SpinnerShowBeforeRunTaskRunFunction());
            group.getAllTasks()[0].afterRun(new FindLastRatingAfterRunTaskRunFunction());


            group.getAllTasks()[1].addParameter(new InputTaskParameter("ratingInfoWindow", typeof(RatingInfoWindow)));
            group.getAllTasks()[1].beforeRun(new SpinnerShowBeforeRunTaskRunFunction());
            group.getAllTasks()[1].afterRun(new RatingAfterRunTaskRunFunction());


            Operation operation = this.repository.findOperationById(2);
            operation.task.addParameter(new InputTaskParameter("currentPage", typeof(CustomInteger), TaskParameterLevel.HIDDEN));
            operation.task.addParameter(new InputTaskParameter("pageSize", typeof(CustomInteger), TaskParameterLevel.HIDDEN));
            operation.task.addParameter(new InputTaskParameter("spinner", typeof(LoadingSpinner)));
            operation.task.addParameter(new InputTaskParameter("statisticsWindow", typeof(StatisticsWindow)));
            operation.task.beforeRun(new SpinnerShowBeforeRunTaskRunFunction());
            operation.afterRun(new StatisticsWindowFindAllConversionHistoryAfterRunTaskRunFunction());
        }
    }
}
