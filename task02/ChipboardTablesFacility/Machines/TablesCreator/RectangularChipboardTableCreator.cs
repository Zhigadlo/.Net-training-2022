using Facility.Tables;
using Facility.TableDetails;

namespace Facility.TablesCreator
{
    public class RectangularChipboardTableCreator : ITableCreator <RectangularTableTop, ChipboardRectangleLeg, RectangularChipboardTable>
    {
        public RectangularChipboardTable CreateTable(string name, RectangularTableTop top, int countOfLegs, ChipboardRectangleLeg leg)
        {
            return new RectangularChipboardTable(name, top, countOfLegs, leg);
        }
    }
}
