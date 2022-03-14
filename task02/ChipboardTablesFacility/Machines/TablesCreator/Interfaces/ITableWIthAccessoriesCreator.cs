using Facility.Interfaces;
using Facility.TableDetails;

namespace Facility.TablesCreator.Interfaces
{
    public interface ITableWIthAccessoriesCreator<Top, Leg, Table>
        where Top : IDetail
        where Leg : IDetail
        where Table : ITable<Top, Leg>
    {
        public Table CreateTable(string name, Top top, int countOfLegs, Leg leg, Dictionary<TableAccessoriesType, int> tableAccessories);
        public List<Table> GetTablesFromXmlFile(string path);
    }
}
