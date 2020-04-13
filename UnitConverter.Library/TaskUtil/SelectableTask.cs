using System.Collections.Generic;
using UnitConverter.Library.OperationUtil;
using UnitConverter.Library.OperationUtil.Repository;
using UnitConverter.Library.TypeUtil.Number;
using UnitConverter.Library.TypeUtil.Void;

namespace UnitConverter.Library.TaskUtil
{
    /// <summary>
    /// Klasa, która dziedziczy klasę abstrakcyjną <see cref="Task{T}"/> i implemeentuje interfejs <see cref="ISelectableTask"/>,
    /// która posłuży do utworzenia zadania, w którym musimy dokonać wyboru wykonania podzadania
    /// </summary>
    /// <param name="repository">Repozytoorium z podzadaniami</param>
    /// <see cref="Task{T}"/>
    /// <see cref="CustomVoid"/>
    /// <see cref="ISelectableTask"/>
    public class SelectableTask : Task<CustomVoid>, ISelectableTask
    {
        private OperationRepository repository;

        public SelectableTask(OperationRepository repository)
        {
            this.repository = repository;
        }

        public SelectableTask(params Operation[] operations)
        {
            this.repository = new OperationRepository(operations);
        }

        public void addOperation(Operation operation) => repository.addOperation(operation);
        public List<Operation> getOperations() => repository.operations;
        public Operation getSelectedOperation() => repository.getSelectedOperation();
        public void selectOperation(CustomInteger index) => repository.selectOperation(index);

        protected override CustomVoid apply(Operation operation)
        {
            if (repository.operations.Count == 1)
                repository.selectOperation(0);

            repository.getSelectedOperation().run();
            return new CustomVoid(() => repository.getSelectedOperation().task.getResult());
        }
    }
}
