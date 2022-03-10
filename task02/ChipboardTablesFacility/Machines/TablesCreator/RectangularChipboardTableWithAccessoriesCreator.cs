using Facility.Tables;
using Facility.TableDetails;
using Facility.TablesCreator.Interfaces;

namespace Facility.TablesCreator
{
    public class RectangularChipboardTableWithAccessoriesCreator : ITableWIthAccessoriesCreator<RectangularTableTop, ChipboardRectangleLeg, RectangularChipboardTableWithAccessories>
    {
        public RectangularChipboardTableWithAccessories CreateTable(string name, RectangularTableTop top, int countOfLegs, ChipboardRectangleLeg leg, Dictionary<TableAccessoriesType, int> tableAccessories)
        {
            return new RectangularChipboardTableWithAccessories(name, top, countOfLegs, leg, tableAccessories);
        }
    }
}
