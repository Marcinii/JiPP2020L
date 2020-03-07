using System;
using System.Collections.Generic;
using System.Text;

namespace UnitConverter.OperationUtil
{
    /// <summary>
    /// Klasa przechowująca i zarządzająca listą operacji.
    /// <param name="units">Lista jednostek miar</param>
    /// </summary>
    /// <see cref="Operation"/>
    public class OperationRepository
    {
        public List<Operation> operations;
        
        public OperationRepository()
        {
            this.operations = new List<Operation>();
        }


        /// <summary>
        /// Metoda dodaje nową operacje do listy
        /// </summary>
        /// <param name="operation">Skonfigurowana operacja</param>
        public void addOperation(Operation operation)
        {
            this.operations.Add(operation);
        }


        /// <summary>
        /// Metoda wyświetla pełną listę wszystkich opeacji (potrzebna w aplikacji konsolowej)
        /// </summary>
        public void print()
        {
            this.operations.ForEach(operation => Console.WriteLine("# {0}. {1}", operation.id, operation.name));
        }
    }
}
