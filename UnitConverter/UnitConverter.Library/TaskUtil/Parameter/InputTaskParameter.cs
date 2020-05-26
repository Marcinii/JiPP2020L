using System;

namespace UnitConverter.Library.TaskUtil.Parameter
{
    /// <summary>
    /// Klasa dziedzicząca klasę abstrakcyjną <see cref="TaskParameter"/>, za pomocą której będziemy mogli utworzyć
    /// parametr, który należy wprowadzić
    /// </summary>
    /// <param name="type">Typ danch, który ten parametr będzie przechowywał</param>
    /// <see cref="TaskParameter"/>
    public class InputTaskParameter : TaskParameter
    {
        public Type type { get; private set; }

        public InputTaskParameter(string name, Type type, TaskParameterLevel level = TaskParameterLevel.REQUIRED)
            : base(name, level) 
        {
            this.type = type;

            if (level != TaskParameterLevel.REQUIRED)
                this.value = Activator.CreateInstance(type);
        }
    }
}
