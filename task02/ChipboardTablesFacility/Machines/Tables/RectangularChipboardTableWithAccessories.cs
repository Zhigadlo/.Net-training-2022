using Facility.Interfaces;
using Facility.Materials;
using Facility.TableDetails;

namespace Facility.Tables
{
    public class RectangularChipboardTableWithAccessories : RectangularChipboardTable, ITableWithAccessories
    {
        public Dictionary<TableAccessoriesType, int> TableAccessories { get; }

        public RectangularChipboardTableWithAccessories(string name, RectangularTableTop top, int countOfLegs, ChipboardRectangleLeg leg,Dictionary<TableAccessoriesType, int> TableAccessories) : base(name, top, countOfLegs, leg)
        {
            this.TableAccessories = TableAccessories;
        }
    }
}
