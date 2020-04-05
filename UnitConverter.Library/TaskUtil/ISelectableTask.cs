using System.Collections.Generic;
using UnitConverter.Library.OperationUtil;
using UnitConverter.Library.TypeUtil;

namespace UnitConverter.Library.TaskUtil
{
    /// <summary>
    /// Interfejs, który posluży do utworzenia zadania, w którym musimy dokonać wyboru
    /// innego podzadania
    /// </summary>
    public interface ISelectableTask
    {
        /// <summary>
        /// Metoda, która zwraca listę podoperacji w zadaniu
        /// </summary>
        /// <returns>Lista z obiektami Operation</returns>
        List<Operation> getOperations();


        /// <summary>
        /// Metoda, która wyszukuje operację po parametrze {index} i ustawiającą ją jako tą,
        /// którą należy wykonać
        /// </summary>
        /// <param name="index">Numer operacji</param>
        void selectOperation(CustomInteger index);


        /// <summary>
        /// Metoda dodająca nową operację do zadania
        /// </summary>
        /// <param name="operation"></param>
        void addOperation(Operation operation);


        /// <summary>
        /// Metoda zwracająca zaznaczoną operację
        /// </summary>
        /// <returns>Zwraca obiekt typu Operation</returns>
        Operation getSelectedOperation();
    }
}
