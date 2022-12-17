namespace DataMunging.Common.Utilities.Parsing
{
    public interface IParser
    {
        T Parse<T>(string input);
    }
}
