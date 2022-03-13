using Facility.Tables;
using Facility.TableDetails;
using Facility.TablesCreator.Interfaces;

namespace Facility.TablesCreator
{
    public class RectangularChipboardTableCreator : ITableCreator <RectangularTableTop, RectangleChipboardLeg, RectangularChipboardTable>
    {
        public RectangularChipboardTable CreateTable(string name, RectangularTableTop top, int countOfLegs, RectangleChipboardLeg leg)
        {
            return new RectangularChipboardTable(name, top, countOfLegs, leg);
        }
    }
}
