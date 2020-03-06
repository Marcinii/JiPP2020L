namespace UnitConverter.UnitUtil
{
    /// <summary>
    /// Prosty delegat, służący do wprowadzenia równania niezbędnemu do konwertowania jednostek miar
    /// </summary>
    /// <param name="value">Wartość, którą chcemy skonwertować zgodnie ze zwracanym równaniem</param>
    /// <returns>Zwraca równanie, które wylicza nam wartość na podstawie parametru {value}</returns>
    public delegate double UnitFormula(double value);
}
