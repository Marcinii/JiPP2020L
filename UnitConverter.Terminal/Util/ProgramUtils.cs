using System.Collections.Generic;
using System.Linq;
using UnitConverter.Library.OperationUtil;
using UnitConverter.Library.TaskUtil;
using UnitConverter.Terminal.Task;

namespace UnitConverter.Terminal.Util
{
    /// <summary>
    /// Klasa przechowująca zestaw danych do zarządzania klasą rozruchową applikacji konsolowej.
    /// </summary>
    public class ProgramUtils
    {
        /// <summary>
        /// Metoda dodająca nową operacje do tych operacji, które są operacjami wyboru podpoeracji
        /// </summary>
        /// <param name="operations">Lista operacji</param>
        public static void prepareGoBackOperations(List<Operation> operations)
        {
            operations.ForEach(operation =>
            {
                if(operation.task is ISelectableTask)
                {
                    if (((ISelectableTask)operation.task).getOperations().Where(x => x.task is ISelectableTask).Count() > 0)
                        prepareGoBackOperations(((ISelectableTask)operation.task).getOperations());

                    ((ISelectableTask)operation.task).addOperation(
                        new VoidOperation(0, "Powrót", new FinishTask())
                    );
                }
            });
        }
    }
}
