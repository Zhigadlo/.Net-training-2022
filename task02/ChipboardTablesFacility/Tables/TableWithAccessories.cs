using TableDetails;

namespace Tables
{
    public class TableWithAccessories : Table
    {

        private Dictionary<TableAccessories, int> _tableAccessories;

        public TableWithAccessories(TableLeg leg, int countOfLegs, TableTop top, Dictionary<TableAccessories, int> tableAccessories) : base(leg, countOfLegs, top)
        {
            _tableAccessories = tableAccessories;
            foreach (var accessory in tableAccessories)
                Price += (int)accessory.Value;
        }
    }
}
