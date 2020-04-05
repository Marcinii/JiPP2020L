using System;
using UnitConverter.Library.TaskUtil.Parameter;

namespace UnitConverter.Library.TaskUtil
{

    /// <summary>
    /// Interfejs, który posłuży do utworzenia zadania, które będzie uruchamiane w momencie,
    /// gdy uruchomimmy operację.
    /// </summary>
    public interface IRunnable
    {
        /// <summary>
        /// Metoda, która dodaje nowy parametr dla zadania
        /// </summary>
        /// <param name="parameter">Instancja obiektu reprezentujący parametr do zadania</param>
        /// <see cref="TaskParameter"/>
        void addParameter(TaskParameter parameter);



        /// <summary>
        /// Metoda, która ma za zadanie aktualizację danego parametru
        /// </summary>
        /// <param name="name">Nazwa parametru</param>
        /// <param name="value">Wartość parametru</param
        void setParameter(string name, object value);



        /// <summary>
        /// Metoda zwracająca rezultat wykonanego zadania
        /// </summary>
        /// <returns>Obiekt przechowujący wynik działania</returns>
        object getResult();



        /// <summary>
        /// Metoda zwracająca typ danych wyniku zadania
        /// </summary>
        /// <returns>Zwraca obiekt przechowujący dane na temat typu danych wyniku zadania</returns>
        Type getResultType();



        /// <summary>
        /// Metoda zwracająca kolekcję z parametrami
        /// </summary>
        /// <returns>Lista parametrów</returns>
        /// <see cref="TaskParameterCollection"/>
        TaskParameterCollection getParameters();



        /// <summary>
        /// Metoda wyszukująca i zwracająca parametr według jej nazwy
        /// </summary>
        /// <param name="name">nazwa parametru</param>
        /// <returns>Zwraca istniejący w liscie parametr o podanej nazwie</returns>
        /// <see cref="TaskParameter"/>
        TaskParameter getParameter(string name);
    }
}
