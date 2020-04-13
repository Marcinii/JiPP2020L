using System;
using System.Collections.Generic;
using UnitConverter.Library.TaskUtil.TaskException;

namespace UnitConverter.Library.TaskUtil.Parameter
{

    /// <summary>
    /// Klasa, która przechowuje i zarządza listą parametrów zadania
    /// </summary>
    /// <param name="parameters">Lista z parametrami</param>
    /// <see cref="TaskParameter"/>
    public class TaskParameterCollection
    {
        private List<TaskParameter> parameters;




        public TaskParameterCollection(params TaskParameter[] parameters)
        {
            this.parameters = new List<TaskParameter>(parameters);
        }




        /// <summary>
        /// Przeciążenie operatora, którego możemy wykorzystać do wybrania parametru według nazwy lub jego aktualizacji.
        /// </summary>
        /// <param name="name">Nazwa parametru</param>
        /// <returns>W przypadku wybierania, metoda zwraca znaleziony parametr</returns>
        /// <exception cref="TaskParameterNotFoundException">
        ///     Rzutowany jest w momencie, gdy parametr o podanej nazwie nie istnieje na liście
        /// </exception>
        public TaskParameter this[string name]
        {
            get
            {
                foreach (TaskParameter parameter in parameters)
                    if (parameter.name == name)
                        return parameter;

                throw new TaskParameterNotFoundException(name);
            }
            set
            {
                parameters.ForEach(parameter =>
                {
                    if(parameter.name == value.name)
                    {
                        parameter = value;
                        return;
                    }
                });
            }
        }



        /// <summary>
        /// Metoda, która dodaje nowy parametr do listy
        /// </summary>
        /// <param name="parameter">Parametr do dodania</param>
        /// <see cref="TaskParameter"/>
        public void add(TaskParameter parameter)
        {
            foreach (TaskParameter p in parameters)
                if (p.name == parameter.name)
                    throw new Exception(string.Format("Parametr o identyfikatorze \'{0}\' już istnieje", parameter.name));

            parameters.Add(parameter);
        }



        /// <summary>
        /// Metoda, która przechodzi po liście wszystkich parametrów i wywołuje funckcję przekazaną jako parametr
        /// </summary>
        /// <param name="function">Funkcja, która ma się wywołać podczas iteracji</param>
        /// <see cref="TaskParameterCollectionForEachFunction"/>
        public void forEach(TaskParameterCollectionForEachFunction function)
        {
            foreach (TaskParameter parameter in parameters)
                function(parameter);
        }



        /// <summary>
        /// Metoda, która przechodzi po liście wszystkich parametrów i wywołuje funckcję przekazaną jako parametr.
        /// Z tą różnicą, że wybieramy tylko te parametry, które są wymagane do wprowadzenia
        /// </summary>
        /// <param name="function"></param>
        /// <see cref="TaskParameterCollectionForEachFunction"/>
        public void forEachRequired(TaskParameterCollectionForEachFunction function)
        {
            foreach (TaskParameter parameter in parameters)
                if (parameter.level != TaskParameterLevel.HIDDEN)
                    function(parameter);
        }



        /// <summary>
        /// Metoda sprawdzająca, czy parametr o podanej nazwie istnieje w liście
        /// </summary>
        /// <param name="name">Nazwa parametru</param>
        /// <returns>
        ///     Zwraca true jeżeli parametr o podanej nazwie istnieje na liście,
        ///     w przeciwnym przypadku zwraca false
        /// </returns>
        public bool exists(string name)
        {
            foreach (TaskParameter parameter in parameters)
                if (parameter.name == name)
                    return true;

            return false;
        }
    }
}
