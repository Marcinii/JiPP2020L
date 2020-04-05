namespace UnitConverter.Library.TaskUtil.Parameter
{
    /// <summary>
    /// Klasa dziedzicząca klasę abstrakcyjną <see cref="TaskParameter"/>, za pomocą której będziemy mogli utworzyć
    /// parametr, który należy wprowadzić
    /// </summary>
    /// <see cref="TaskParameter"/>
    public class InputTaskParameter : TaskParameter
    {
        public InputTaskParameter(string name, object value, bool required = true) : base(name, value, required) {}
    }
}
