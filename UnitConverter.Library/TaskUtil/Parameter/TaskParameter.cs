using UnitConverter.Library.TypeUtil;

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
    /// <param name="level">Pole przechowujące informacje odnośnie widoczności danego parametru</param>
    /// <see cref="TaskParameterLevel"/>
    public abstract class TaskParameter
    {
        public string name { get; private set; }
        public object value { get; set; }
        public TaskParameterLevel level { get; private set; }

        protected TaskParameter(string name, TaskParameterLevel level = TaskParameterLevel.REQUIRED)
        {
            this.name = name;
            this.level = level;
        }
    }
}
