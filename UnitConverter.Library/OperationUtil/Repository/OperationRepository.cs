using System.Linq;
using System.Collections.Generic;
using UnitConverter.Library.OperationUtil.OpException;
using UnitConverter.Library.TypeUtil;

namespace UnitConverter.Library.OperationUtil.Repository
{
    /// <summary>
    /// Klasa abstrakcyjna przechowująca i zarządzająca listą operacji.
    /// 
    /// <param name="units">
    ///     Lista jednostek miar. Ważne, aby elementy tej listy były elementami typu <see cref="Operation"/>
    /// </param>
    /// <param name="selectedOperationIndex">
    ///     Indeks, który przechowuje wybraną operację
    /// </param>
    /// </summary>
    /// <see cref="Operation"/>
    public abstract class OperationRepository<T> where T : Operation
    {
        public List<T> operations { get; private set; }
        public CustomInteger selectedOperationIndex { get; private set; }
        
        public OperationRepository()
        {
            this.operations = new List<T>();
            this.selectedOperationIndex = -1;
        }


        /// <summary>
        /// Metoda dodaje nową operacje do listy
        /// </summary>
        /// <param name="operation">Skonfigurowana operacja</param>
        /// <exception cref="OperationExistsException">
        ///     Wyjątek wyrzucany w przypadku, gdy operacja z podanym numerem już istnieje w repozytorium
        /// </exception>
        public void addOperation(T operation)
        {
            if (this.operations.Where(op => op.id == operation.id).Count() > 0)
                throw new OperationExistsException();

            this.operations.Add(operation);
        }



        /// <summary>
        /// Metoda, która ma za zadanie wybranie wykonywanej operacji według zaznaczonego indeksu
        /// </summary>
        /// <param name="command">Numer operacji</param>
        /// <exception cref="OperationNotFoundException">
        ///     Rzutowany jest w przypadku, gdy operacja wwedług numeru operacji nie istnieje
        /// </exception>
        public void selectOperation(CustomInteger command)
        {
            if(this.operations.Where(operation => operation.id == command).Count() == 0)
                throw new OperationNotFoundException();

            this.selectedOperationIndex = command - 1;
        }



        /// <summary>
        /// Metoda, która restartuje wybraną operacje, czyli usuwa zaznaczoną operację
        /// </summary>
        public void resetOperation() => this.selectedOperationIndex = -1;



        /// <summary>
        /// Metoda zwracająca zaznaczoną operacje.
        /// Jeżeli nie ma wybranej żadnej operacji, wówczas zwraca null
        /// </summary>
        /// <returns>Zwraca element typu <see cref="Operation"/></returns>
        public T getSelectedOperation() => selectedOperationIndex > -1 
                            ? this.operations[selectedOperationIndex.toPrimitiveValue()] : null;
    }
}
