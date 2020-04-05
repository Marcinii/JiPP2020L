using System.Collections.Generic;
using UnitConverter.Library.TypeUtil;

namespace UnitConverter.Library.TaskUtil.Parameter
{
    /// <summary>
    /// Klasa dziedzicząca klasę abstrakcyjną <see cref="TaskParameter"/>, za pomoca której
    /// będziemy mogli utworzyć nowy parmetr zadania, w którym będziemy mogli dokonać wyboru opcji
    /// </summary>
    /// <param name="selectedOptionIndex">Indeks wybranej opcji</param>
    /// <param name="options">Lista wszystkich możliwych opcji</param>
    /// <param name="label">
    ///     Ciąg wyrazów, który posłuży do wyświetlenia opcji w aplikacjach.
    /// </param>
    public class SelectableTaskParameter : TaskParameter
    {
        private int selectedOptionIndex;
        public List<SelectableTaskParameterOption> options { get; private set; }
        public string label { get; private set; }

        public SelectableTaskParameter(string name, string label, bool required = true) : base(name, default, required) {
            this.selectedOptionIndex = -1;
            this.label = label;
            this.options = new List<SelectableTaskParameterOption>();
        }



        /// <summary>
        /// Metoda zwracająca aktualnie zaznaczoną opcję
        /// </summary>
        /// <returns>Obiekt reprezentujący opcję</returns>
        /// <see cref="SelectableTaskParameterOption"/>
        public SelectableTaskParameterOption getSelectedOption() => this.options[this.selectedOptionIndex];



        /// <summary>
        /// Metoda, która dodaje opcje wprowadzone w argumencie funckji do listy opcji w parametrze
        /// </summary>
        /// <param name="values">Lista opcji do dodania</param>
        /// <see cref="SelectableTaskParameterOption"/>
        public void addOptions(params SelectableTaskParameterOption[] values)
        {
            foreach (SelectableTaskParameterOption value in values)
                this.options.Add(value);
        }



        /// <summary>
        /// Metoda, która wyszukuje i następnie zaznacza daną opcję.
        /// </summary>
        /// <param name="index">Numer opcji</param>
        /// <see cref="CustomInteger"/>
        public void selectOption(CustomInteger index)
        {
            for(int i = 0; i < options.Count; i++)
            {
                if (options[i].id == index)
                {
                    this.selectedOptionIndex = i;
                    this.value = options[i].value;
                    break;
                }
            }
        }



        /// <summary>
        /// Metoda sprawdzająca, czy jakakolwiek opcja została wybrana
        /// </summary>
        /// <returns>
        ///     Zwraca true, jeśli opcja została wybrana, w przeciwnym przypadku zwraca false
        /// </returns>
        public bool isOptionSelected() => this.selectedOptionIndex > -1;
    }
}
