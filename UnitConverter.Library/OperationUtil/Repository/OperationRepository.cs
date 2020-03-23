using System.Collections.Generic;

namespace UnitConverter.Library.OperationUtil.Repository
{
    /// <summary>
    /// Klasa przechowująca i zarządzająca listą operacji.
    /// <param name="units">Lista jednostek miar</param>
    /// </summary>
    /// <see cref="Operation"/>
    public abstract class OperationRepository<T> where T : Operation
    {
        public List<T> operations { get; private set; }
        public int selectedOperationIndex { get; private set; }
        
        public OperationRepository()
        {
            this.operations = new List<T>();
            this.selectedOperationIndex = -1;
        }


        /// <summary>
        /// Metoda dodaje nową operacje do listy
        /// </summary>
        /// <param name="operation">Skonfigurowana operacja</param>
        public void addOperation(T operation) => this.operations.Add(operation);
        public void selectOperation(int command) => this.selectedOperationIndex = command;
        public void resetOperation() => this.selectedOperationIndex = -1;
        public T getSelectedOperation() => selectedOperationIndex > -1 ? this.operations[selectedOperationIndex] : null;
    }
}
