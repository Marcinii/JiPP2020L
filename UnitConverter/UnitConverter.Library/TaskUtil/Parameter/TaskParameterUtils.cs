namespace UnitConverter.Library.TaskUtil.Parameter
{
    /// <summary>
    /// Klasa przechowująca zeestaw metod, służąca do zarządzania parametrami zadania
    /// </summary>
    /// <see cref="TaskParameter"/>
    /// <see cref="SelectableTaskParameter"/>
    /// <see cref="InputTaskParameter"/>
    public class TaskParameterUtils
    {

        /// <summary>
        /// Metoda, sprawdzająca, czy podany parametr jest parametrem wyboru opcji
        /// </summary>
        /// <param name="parameter">Parametr do sprawdzenia</param>
        /// <returns>
        ///     Zwraca true, jeżeli przekazany parametr jest parametrem wyboru opcji,
        ///     lub false w przeciwnym przupadku
        /// </returns>
        /// <see cref="TaskParameter"/>
        /// <see cref="SelectableTaskParameter"/>
        public static bool isSelectableTaskParameter(TaskParameter parameter) => 
            parameter.GetType() == typeof(SelectableTaskParameter);



        /// <summary>
        /// Metoda zwracający parametr jako parametr wyboru opcji
        /// </summary>
        /// <param name="parameter">Parametr do przekonwertowania</param>
        /// <returns>Zwraca przekonwertowany parametr</returns>
        /// <see cref="TaskParameter"/>
        /// <see cref="SelectableTaskParameter"/>
        public static SelectableTaskParameter toSelectableTaskParameter(TaskParameter parameter) =>
            (SelectableTaskParameter)parameter;



        /// <summary>
        /// Metoda sprawdzająca, czy podany parametr jest parametrem, reprezentującym pole wejściowe,
        /// w którą należy wprowadzić wartość
        /// </summary>
        /// <param name="parameter">Parametr do sprawdzenia</param>
        /// <returns>
        ///     Zwraca true jeżeli parametr jest parametrem reprezentującym pole wejściowe,
        ///     w przeciwnym wypadku zwraca false
        /// </returns>
        /// <see cref="TaskParameter"/>
        /// <see cref="InputTaskParameter"/>
        public static bool isInputTaskParameter(TaskParameter parameter) =>
            parameter.GetType() == typeof(InputTaskParameter);



        /// <summary>
        /// Metoda zwracająca pparametr jako parametr reprezentujący pole wejściowe
        /// </summary>
        /// <param name="parameter">Parametr do przekonwertowania</param>
        /// <returns>Zwraca przekonwertowany parametr</returns>
        /// <see cref="TaskParameter"/>
        /// <see cref="InputTaskParameter"/>
        public static InputTaskParameter toInputTaskParameter(TaskParameter parameter) =>
            (InputTaskParameter)parameter;
    }
}
