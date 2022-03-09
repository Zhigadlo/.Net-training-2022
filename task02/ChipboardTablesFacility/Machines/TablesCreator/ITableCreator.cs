using Facility.Interfaces;

namespace Facility.TablesCreator
{
    public interface ITableCreator <Top, Leg, Table>  
        where Top : IDetail 
        where Leg : IDetail
        where Table : ITable<Top, Leg>
    {
        public Table CreateTable(string name, Top top, int countOfLegs, Leg leg);

    }
}
