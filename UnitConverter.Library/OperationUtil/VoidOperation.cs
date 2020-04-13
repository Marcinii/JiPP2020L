using UnitConverter.Library.TaskUtil;
using UnitConverter.Library.TypeUtil.Number;
using UnitConverter.Library.TypeUtil.Void;

namespace UnitConverter.Library.OperationUtil
{
    /// <summary>
    /// Klasa dziedzicząca klasę abstrakcyjną <see cref="Operation"/>, za pomocą której możemy
    /// utworzyć operację, która ma za zadanie wywołać zadanie bez zwracania wartości
    /// </summary>
    public class VoidOperation : Operation
    {
        public VoidOperation(CustomInteger id, string name, Task<CustomVoid> task) : base(id, name, task) {}

        public override void afterRun(TaskRunFunction taskAfterRunFunction) => ((Task<CustomVoid>)task).afterRun(taskAfterRunFunction);
        public override void beforeRun(TaskRunFunction taskBeforeRunFunction) => ((Task<CustomVoid>)task).beforeRun(taskBeforeRunFunction);
        public override void run() => ((CustomVoid)task.run(this)).run();
    }
}
