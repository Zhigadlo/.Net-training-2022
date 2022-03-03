using Facility.TableDetails;

namespace Facility.Tables
{
    public class TableWithAccessories : Table
    {

        private Dictionary<TableAccessories, int> _tableAccessories;

        public TableWithAccessories(List<ITableLeg> legs, ITableTop top, Dictionary<TableAccessories, int> tableAccessories) : base(legs, top)
        {
            _tableAccessories = tableAccessories;
            foreach (var accessory in tableAccessories)
                Price += accessory.Value * (int)accessory.Key;
        }
    }
}
