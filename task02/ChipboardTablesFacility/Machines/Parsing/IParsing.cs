
namespace Facility.Parsing
{
    public interface IParsing
    {
        public void WriteObject(string path, object obj);
        public void WriteListOfObjects(string path, params object[] objectList);
    }
}
