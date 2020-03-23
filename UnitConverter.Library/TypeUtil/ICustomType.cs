namespace UnitConverter.Library.TypeUtil
{
    public interface ICustomType {
        ICustomType fromString(string input);
        string ToString();
    }
}
