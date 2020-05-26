using System;
using System.Collections.Generic;
using System.Linq;
using UnitConverter.Library.OperationUtil;
using UnitConverter.Library.TaskUtil.Parameter;
using UnitConverter.Library.TypeUtil;
using UnitConverter.Library.TypeUtil.Void;

namespace UnitConverter.Library.TaskUtil
{

    /// <summary>
    /// Klasa implementująca interfejs <see cref="IRunnable"/>, 
    /// która ma posłużyc do utworzenia zadania, które będzie się wywoływało w momecie, gdy
    /// wywołamy operację, do którego to zadanie zostało przypisane
    /// </summary>
    /// <typeparam name="T">
    ///     Typ danych, który to zadanie będzie zwracało.
    ///     Bardzo ważne, by typ danych był typen zgodnym z <see cref="IObject"/>
    /// </typeparam>
    /// <param name="parameters">
    ///     Lista parametrów zadania. Można powiedzieć, że są one rozwiązaniem na problem związany
    ///     z tym, że niektóre zadania wymagają wprowadzenia dynamicznych argumentów.. To sprawia,
    ///     że takie zadanie jest nieco bardziej uniwersalne i można wykorzystać go w kilku miejscach.
    ///     Wystarczy pozmieniać wartości parametrów.
    /// </param>
    /// <param name="taskBeforeRunFunctions">
    ///     Lista funkcji, która będzie uruchamiana przed właściwym uruchomieniem zadania.
    ///     To daje nam możliwość zmanimulowania parametrami, lub odpowiednim przygotowaniem środowiska
    ///     do wyywołania zadania
    /// </param>
    /// <param name="taskAfterRunFunctions">
    ///     Lista funkcji, która wywołuje funkcje tuż po właściwym wywkonaniu zadania.
    ///     Taki zabieg ma pomóć w odpowiednim przetworzeniu wyniku zadania.
    /// </param>
    /// <param name="result">Pole przechowujące wynik wykonania zadania</param>
    /// <see cref="TaskParameterCollection"/>
    /// <see cref="TaskRunFunction"/>
    public abstract class Task<T> : IRunnable
    {
        protected TaskParameterCollection parameters { get; set; }
        protected HashSet<TaskRunFunction> taskBeforeRunFunctions { get; set; }
        protected HashSet<TaskRunFunction> taskAfterRunFunctions { get; set; }

        protected T result { get; set; }

        public Task()
        {
            this.parameters = this.addParametres();
            this.taskBeforeRunFunctions = new HashSet<TaskRunFunction>();
            this.taskAfterRunFunctions = new HashSet<TaskRunFunction>();
            this.result = default;
        }


        /// <summary>
        /// Metoda, w której musimy zaimplementować to, co dokładnie ma się stać w momencie wywoływania zadania
        /// </summary>
        /// <param name="operation">Operacja, z którego dane zadanie zostało wywołane</param>
        /// <returns>Metoda zwraca obiekt, ktory będzie poitem przypisany do pola {result}</returns>
        /// <see cref="Operation"/>
        protected abstract T apply(Operation operation);



        /// <summary>
        /// Metoda, za pomocą której możemy dodawać nowe parametry do zadania.
        /// Metoda ta jest wirtualna, co oznacza, że w klasach potomnych możemy ją nadpisać
        /// i "na sztywno" ustawić parametry
        /// </summary>
        /// <returns>Zwraca listę wszystkich parametrów</returns>
        /// <see cref="TaskParameterCollection"/>
        protected virtual TaskParameterCollection addParametres() => new TaskParameterCollection();



        /// <summary>
        /// Metoda, która dodaje nowy parametr dla zadania
        /// </summary>
        /// <param name="parameter">Instancja obiektu reprezentujący parametr do zadania</param>
        /// <see cref="TaskParameter"/>
        public virtual void addParameter(TaskParameter parameter) => this.parameters.add(parameter);



        /// <summary>
        /// Metoda, która ma za zadanie aktualizację danego parametru
        /// </summary>
        /// <param name="name">Nazwa parametru</param>
        /// <param name="value">Wartość parametru</param>
        public virtual void setParameter(string name, object value) => this.parameters[name].value = value;


        /// <summary>
        /// Metoda zwracająca kolekcję z parametrami
        /// </summary>
        /// <returns>Lista parametrów</returns>
        /// <see cref="TaskParameterCollection"/>
        public TaskParameterCollection getParameters() => this.parameters;


        /// <summary>
        /// Metoda wyszukująca i zwracająca parametr według jej nazwy
        /// </summary>
        /// <param name="name">nazwa parametru</param>
        /// <returns>Zwraca istniejący w liscie parametr o podanej nazwie</returns>
        /// <see cref="TaskParameter"/>
        public TaskParameter getParameter(string name) => this.parameters[name];



        /// <summary>
        /// Metoda zwracająca rezultat wykonanego zadania
        /// </summary>
        /// <returns>Obiekt przechowujący wynik działania</returns>
        public object getResult() => this.result;



        /// <summary>
        /// Metoda zwracająca typ danych wyniku zadania
        /// </summary>
        /// <returns>Zwraca obiekt przechowujący dane na temat typu danych wyniku zadania</returns>
        public Type getResultType() => typeof(T);


        /// <summary>
        /// Metoda, która ma za zadanie dodać nową funckję do listy funkcji, które będą się uruchamiały przed
        /// właściwym wywołaniem zadania
        /// </summary>
        /// <param name="taskBeforeRunFunction">
        ///     Instancja funckji, która ma się wywołać
        /// </param>
        /// <see cref="TaskRunFunction"/>
        public void beforeRun(TaskRunFunction taskBeforeRunFunction) => this.taskBeforeRunFunctions.Add(taskBeforeRunFunction);



        /// <summary>
        /// Metoda, która ma za zadanie dodać nową funckję do listy funkcji, które będą się uruchamiały po
        /// właściwym wywołaniu zadania
        /// </summary>
        /// <param name="taskBeforeRunFunction">
        ///     Instancja funckji, która ma się wywołać
        /// </param>
        /// <see cref="TaskRunFunction"/>
        public void afterRun(TaskRunFunction taskAfterRunFunction) => this.taskAfterRunFunctions.Add(taskAfterRunFunction);



        /// <summary>
        /// Metoda, która uruchamia zadanie. Najpierw wywołuje listę funkcji z pola <see cref="taskBeforeRunFunctions"/>,
        /// potem wywołuje właściwe zadanie, a na koniec wywołuje listę funckji z pola <see cref="taskAfterRunFunctions"/>
        /// </summary>
        /// <param name="operation">Operacja, z którego dane zadanie zostało wywołane</param>
        /// <returns>Zwraca obiekt, który jest wynikiem działania funkcji</returns>
        /// <see cref="Operation"/>
        public object run(Operation operation)
        {
            this.taskBeforeRunFunctions.ToList().ForEach(f => f.apply(this));
            this.result = apply(operation);

            if (typeof(T) == typeof(CustomVoid))
                ((CustomVoid)Convert.ChangeType(this.result, typeof(CustomVoid))).run();

            this.taskAfterRunFunctions.ToList().ForEach(f => f.apply(this));

            return this.result;
        }
    }
}
