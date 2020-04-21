using UnitConverter.Library.History;
using UnitConverter.Library.OperationUtil;
using UnitConverter.Library.OperationUtil.Repository;
using UnitConverter.Library.TaskUtil;
using UnitConverter.Library.TaskUtil.Group;
using UnitConverter.Terminal.Runner;
using UnitConverter.Terminal.Task;
using UnitConverter.Terminal.Util;

namespace UnitConverter.Terminal
{

    /// <summary>
    /// Klasa uruchamiająca całą aplikację konsolową
    /// </summary>
    class Program
    {
        private OperationRepository repository;
        private OperationRepositoryInitializer initializer;
        private CustomDatabaseContext customDatabaseContext;

        public Program()
        {
            this.repository = new OperationRepository();
            this.customDatabaseContext = new CustomDatabaseContext();
            this.initializer = new OperationRepositoryInitializer(repository, customDatabaseContext);
            initializer.initializeRepository();

            repository.addOperation(
                new VoidOperation(0, "Wyjście z programu", new FinishTask())
            );

            ((SelectableTask)repository.findOperationById(1).task).getOperations().ForEach(op =>
            {
                op.beforeRun(new ConversionOperationBeforeRunTaskRunFunction());
                op.afterRun(new ConversionOperationAfterRunTaskRunFunction());
            });

            Operation conversionOperation = repository.findOperationByName("Wyświetl statystyki konwersji");

            conversionOperation.beforeRun(new FindAllConversionHistoryBeforeRunTaskTunFunction());
            conversionOperation.afterRun(new FindAllConversionHistoryAfterRunTaskRunFunction());

            Operation ratingOperation = repository.findOperationByName("Oceń aplikację");

            ((TaskGroup)ratingOperation.task).getAllTasks()[1].beforeRun(new RatingBeforeRunTaskRunFunction());
            ((TaskGroup)ratingOperation.task).getAllTasks()[1].afterRun(new RatingAfterRunTaskRunFunction());

            ProgramUtils.prepareGoBackOperations(repository.operations);
        }

        internal void run()
        {
            CommandLineOperationRunner runner = new CommandLineOperationRunner();
            runner.run(
                new VoidOperation(-1, "", new SelectableTask(repository))
            );
        }

        static void Main(string[] args) => new Program().run();
    }
}
