using System;
using UnitConverter.Library.OperationUtil;
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
        /// Metoda, która ma za zadanie dodać nową funckję do listy funkcji, które będą się uruchamiały przed
        /// właściwym wywołaniem zadania
        /// </summary>
        /// <param name="taskBeforeRunFunction">
        ///     Instancja funckji, która ma się wywołać
        /// </param>
        /// <see cref="TaskRunFunction"/>
        void beforeRun(TaskRunFunction taskBeforeRunFunction);



        /// <summary>
        /// Metoda, która ma za zadanie dodać nową funckję do listy funkcji, które będą się uruchamiały po
        /// właściwym wywołaniu zadania
        /// </summary>
        /// <param name="taskBeforeRunFunction">
        ///     Instancja funckji, która ma się wywołać
        /// </param>
        /// <see cref="TaskRunFunction"/>
        void afterRun(TaskRunFunction taskAfterRunFunction);



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



        /// <summary>
        /// Metoda, która uruchamia zadanie. Najpierw wywołuje listę funkcji z pola <see cref="taskBeforeRunFunctions"/>,
        /// potem wywołuje właściwe zadanie, a na koniec wywołuje listę funckji z pola <see cref="taskAfterRunFunctions"/>
        /// </summary>
        /// <param name="operation">Operacja, z którego dane zadanie zostało wywołane</param>
        /// <returns>Zwraca obiekt, który jest wynikiem działania funkcji</returns>
        /// <see cref="Operation"/>
        object run(Operation operation);
    }
}
