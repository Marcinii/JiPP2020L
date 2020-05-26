namespace UnitConverter.Library.TaskUtil.Parameter
{
    /// <summary>
    /// Delegat, który posłuży jako funkcja, która będzie wywoływana podczas iteracji 
    /// po liście parametrów
    /// </summary>
    /// <param name="parameter">Parametr, który będzie przekazywany w trakcie iteracji</param>
    /// <see cref="TaskParameter"/>
    public delegate void TaskParameterCollectionForEachFunction(TaskParameter parameter);
}
