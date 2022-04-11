using Facility.Interfaces;

namespace Facility.TablesCreator.Interfaces
{
    public interface ITableCreator<Top, Leg, Table>
        where Top : IDetail
        where Leg : IDetail
        where Table : ITable<Top, Leg>
    {
        public Table CreateTable(string name, Top top, int countOfLegs, Leg leg);
        public List<Table> GetTablesFromXmlFile(string path);
        public List<Table> GetTablesFromXmlFileStream(string path);
    }
}
