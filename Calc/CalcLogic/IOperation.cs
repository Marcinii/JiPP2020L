namespace CalcLogic
{
    public interface IOperation
    {
        string Name { get; }
        double Execute(double x, double y);
    }
}
