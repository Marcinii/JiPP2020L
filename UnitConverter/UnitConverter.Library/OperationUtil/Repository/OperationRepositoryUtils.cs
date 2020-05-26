using System.Collections.Generic;
using UnitConverter.Library.TaskUtil;

namespace UnitConverter.Library.OperationUtil.Repository
{
    /// <summary>
    /// Klasa zawierająca zestaw metod do wykonywania dodatkowych operacji na repoztorium
    /// </summary>
    class OperationRepositoryUtils
    {

        /// <summary>
        /// Metoda przeszukuję listę operacji według jej nazwy
        /// </summary>
        /// <param name="res">Zmienna, przechowująca znalezioną operację</param>
        /// <param name="operations">Lista operacji</param>
        /// <param name="name">Nazwa operacji</param>
        public static void findOperationByName(ref Operation res, List<Operation> operations, string name)
        {
            foreach (Operation operation in operations)
            {
                if (operation.task is ISelectableTask)
                {
                    findOperationByName(
                        ref res,
                        ((ISelectableTask)operation.task).getOperations(),
                        name
                    );
                }
                else
                {
                    if (operation.name == name)
                    {
                        res = operation;
                        break;
                    }
                }
            }
        }
    }
}
