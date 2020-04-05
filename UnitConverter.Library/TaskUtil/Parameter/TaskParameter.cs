namespace UnitConverter.Library.TaskUtil.Parameter
{
    /// <summary>
    /// Klasa reprezentująca model parametru zadania. Parametry posłużą do utworzenia zadań,
    /// które będziemy mogli wykorzystać w kilku innych miejscach. Rozwiązuje to problem,
    /// który polegał na tym, że musilibyśmy tworzyć nowe zadanie, które miało dokładnie takie
    /// same instrukcje, lecz ze zmienionyi argumentami
    /// </summary>
    /// <param name="name">Nazwa parametru</param>
    /// <param name="value">Wartość parametru</param>
    /// <param name="required">Pole przechowujące informacje o tym, czy dany parametr jest wymagany do wprowadzenia</param
    public abstract class TaskParameter
    {
        public string name { get; private set; }
        public object value { get; set; }
        public bool required { get; set; }

        protected TaskParameter(string name, object value, bool required = true)
        {
            this.name = name;
            this.value = value;
            this.required = required;
        }
    }
}
