using System;

namespace UnitConverter.Library.TaskUtil.Parameter
{
    /// <summary>
    /// Klasa reprezentująca model opcji parametru w którym mozemy dokonać wyboru między tymi opcjami
    /// </summary>
    /// <param name="id">Identyfikator opcji</param>
    /// <param name="name">Nazwa operacji. Pozłuży ona do wyszukiwania operacji według tego parametru</param>
    /// <param name="typ">Typ danycj, która dana opcja przechowuje</param>
    /// <param name="value">Wartość danej opcji</param>
    public class SelectableTaskParameterOption
    {
        public int id { get; private set; }
        public string name { get; private set; }
        public Type type { get; private set; }
        public object value { get; private set; }

        public SelectableTaskParameterOption(int id, string name, Type type, object value)
        {
            this.id = id;
            this.name = name;
            this.type = type;
            this.value = value;
        }
    }
}
