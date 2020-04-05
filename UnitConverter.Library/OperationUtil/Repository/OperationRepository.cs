using System.Linq;
using System.Collections.Generic;
using UnitConverter.Library.OperationUtil.OpException;
using UnitConverter.Library.TypeUtil;

namespace UnitConverter.Library.OperationUtil.Repository
{
    /// <summary>
    /// Klasa przechowująca i zarządzająca listą operacji.
    /// 
    /// <param name="operations">
    ///     Lista operacji do wykonania
    /// </param>
    /// <param name="selectedOperationIndex">
    ///     Indeks, który przechowuje wybraną operację
    /// </param>
    /// </summary>
    /// <see cref="Operation"/>
    /// <see cref="CustomInteger"/>
    public class OperationRepository
    {
        public List<Operation> operations { get; private set; }
        public CustomInteger selectedOperationIndex { get; private set; }
        
        public OperationRepository(params Operation[] operations)
        {
            this.operations = new List<Operation>(operations);
            this.selectedOperationIndex = -1;
        }


        /// <summary>
        /// Metoda zwracająca zaznaczoną operacje.
        /// Jeżeli nie ma wybranej żadnej operacji, wówczas zwraca null
        /// </summary>
        /// <returns>Zwraca element typu <see cref="Operation"/></returns>
        /// <see cref="Operation"/>
        public Operation getSelectedOperation() => selectedOperationIndex > -1
                            ? this.operations[selectedOperationIndex.toPrimitiveValue()] : null;




        /// <summary>
        /// Metoda, która ma za zadanie znalezienie operacji po wartości atybutu {id}
        /// </summary>
        /// <param name="id">Identyfikator operacji</param>
        /// <returns>Zwraca znalezioną w liście operację</returns>
        /// <exception cref="OperationNotFoundException">
        ///     Wyjątk rzucany w momencie, gdy operacja o podanym identyfikatorze nie istnieje
        /// </exception>
        /// <see cref="Operation"/>
        /// <see cref="CustomInteger"/>
        public Operation findOperationById(CustomInteger id)
        {
            foreach (Operation operation in operations)
                if (operation.id == id)
                    return operation;

            throw new OperationNotFoundException();
        }




        /// <summary>
        /// Metoda, która ma za zadanie znaleść operację według jej nazwy
        /// </summary>
        /// <param name="name">Nazwa operacji</param>
        /// <returns>Zwraca znalezioną w liście operację</returns>
        /// <exception cref="OperationNotFoundException">
        ///     Wyjątk rzucany w momencie, gdy operacja o podanym identyfikatorze nie istnieje
        /// </exception>
        /// <see cref="Operation"/>
        public Operation findOperationByName(string name)
        {
            Operation res = null;
            OperationRepositoryUtils.findOperationByName(ref res, this.operations, name);

            if(res == null)
                throw new OperationNotFoundException();

            return res;
        }



        /// <summary>
        /// Metoda, która ma za zadanie wybranie wykonywanej operacji według zaznaczonego indeksu
        /// </summary>
        /// <param name="command">Numer operacji</param>
        /// <exception cref="OperationNotFoundException">
        ///     Rzutowany jest w przypadku, gdy operacja wwedług numeru operacji nie istnieje
        /// </exception>
        /// <see cref="CustomInteger"/>
        public void selectOperation(CustomInteger command)
        {
            for(int i = 0; i < operations.Count; i++)
            {
                if(operations[i].id == command)
                {
                    this.selectedOperationIndex = i;
                    return;
                }
            }

            throw new OperationNotFoundException();
        }



        /// <summary>
        /// Metoda dodaje nową operacje do listy
        /// </summary>
        /// <param name="operation">Skonfigurowana operacja</param>
        /// <exception cref="OperationExistsException">
        ///     Wyjątek wyrzucany w przypadku, gdy operacja z podanym numerem już istnieje w repozytorium
        /// </exception>
        /// <see cref="Operation"/>
        public void addOperation(Operation operation)
        {
            if (this.operations.Where(op => op.id == operation.id).Count() > 0)
                throw new OperationExistsException();

            this.operations.Add(operation);
        }


        /// <summary>
        /// Metoda, która restartuje wybraną operacje, czyli usuwa zaznaczoną operację
        /// </summary>
        public void resetOperation() => this.selectedOperationIndex = -1;
    }
}
