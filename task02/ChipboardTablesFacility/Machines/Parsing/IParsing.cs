
namespace Facility.Parsing
{
    /// <summary>
    /// Interface for parsers data to some file
    /// </summary>
    public interface IParsing
    {
        public void WriteObject(string path, object obj);
        public void WriteListOfObjects(string path, params object[] objectList);
    }
}
