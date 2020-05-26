using UnitConverter.Library.TaskUtil;
using UnitConverter.Library.TypeUtil.Number;

namespace UnitConverter.Library.OperationUtil
{
    /// <summary>
    /// Klasa, która dziedziczy klasę abstrakcyjną <see cref="Operation"/>, która służy do utworzenia
    /// domyślnej operacji, która po wykonaniu operacji zwraca wartość
    /// </summary>
    /// <see cref="Operation"/>
    public class DefaultOperation : Operation
    {
        public DefaultOperation(CustomInteger id, string name, IRunnable task) : base(id, name, task) {}

        public override void afterRun(TaskRunFunction taskAfterRunFunction) => task.afterRun(taskAfterRunFunction);
        public override void beforeRun(TaskRunFunction taskBeforeRunFunction) => task.beforeRun(taskBeforeRunFunction);
        public override void run() => task.run(this);
    }
}
