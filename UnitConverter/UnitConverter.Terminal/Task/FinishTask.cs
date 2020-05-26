using UnitConverter.Library.OperationUtil;
using UnitConverter.Library.TaskUtil;
using UnitConverter.Library.TypeUtil.Void;
using UnitConverter.Terminal.Runner;

namespace UnitConverter.Terminal.Task
{
    /// <summary>
    /// Klasa dziedzicząca klasę abstrakcyjną <see cref="Task"/>.
    /// Klasa ta reprezentuje zadanie do wywołania i służy ono do zakończenia wykonywania
    /// operacji, w których należałoby wybrać podoperacje. Innymi słowy: pozwala na cofanie się w hierarchii
    /// operacji.
    /// </summary>
    public class FinishTask : Task<CustomVoid>
    {
        protected override CustomVoid apply(Operation operation) => new CustomVoid(() => 
        {
            ((CommandLineOperationRunner) parameters["commandLineRunner"].value).finish();
        });
    }
}
