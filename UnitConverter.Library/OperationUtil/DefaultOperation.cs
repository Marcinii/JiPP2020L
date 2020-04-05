using UnitConverter.Library.TaskUtil;
using UnitConverter.Library.TypeUtil;

namespace UnitConverter.Library.OperationUtil
{
    /// <summary>
    /// Klasa, która dziedziczy klasę abstrakcyjną <see cref="Operation"/>, która służy do utworzenia
    /// domyślnej operacji, która po wykonaniu operacji zwraca wartość
    /// </summary>
    /// <see cref="Operation"/>
    public class DefaultOperation : Operation
    {
        public DefaultOperation(CustomInteger id, string name, Task<ICustomType> task) : base(id, name, task) {}

        public override void afterRun(TaskRunFunction taskAfterRunFunction) => ((Task<ICustomType>)task).afterRun(taskAfterRunFunction);
        public override void beforeRun(TaskRunFunction taskBeforeRunFunction) => ((Task<ICustomType>)task).beforeRun(taskBeforeRunFunction);
        public override void run() => ((Task<ICustomType>)task).run(this);
    }
}
