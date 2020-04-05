using UnitConverter.Library.Converter;
using UnitConverter.Library.OperationUtil;
using UnitConverter.Library.TypeUtil;
using UnitConverter.Library.UnitUtil;

namespace UnitConverter.Library.TaskUtil.Impl
{
    /// <summary>
    /// Klasa, dziedzicząca klasę abbstrakcyjną <see cref="Task{T}"/>, który jest implementacją nowego zadania.
    /// Ma on za zadanie przekonwertować wprowadzone jednostki miar.
    /// </summary>
    /// <see cref="Task{T}"/>
    /// <see cref="ICustomType"/>
    public class ConversionTask : Task<ICustomType>
    {
        protected override ICustomType apply(Operation operation)
        {
            DefaultConverter converter = new DefaultConverter(
               CustomTypeUtils.createInstanceFrom(
                   ((Unit)parameters["fromConversion"].value).type,
                   parameters["value"].value.ToString()
               ),
               (Unit) parameters["fromConversion"].value,
               (Unit) parameters["toConversion"].value
            );

            return converter.convert();
        }
    }
}
