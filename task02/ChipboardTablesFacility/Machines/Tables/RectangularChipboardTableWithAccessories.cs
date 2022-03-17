using Facility.Interfaces;
using Facility.TableDetails;

namespace Facility.Tables
{
    public class RectangularChipboardTableWithAccessories : RectangularChipboardTable, ITableWithAccessories
    {
        public Dictionary<TableAccessoriesType, int> TableAccessories { get; }

        public RectangularChipboardTableWithAccessories(string name, RectangularTableTop tableTop, int legsCount, RectangleChipboardLeg tableLeg, Dictionary<TableAccessoriesType, int> TableAccessories) : base(name, tableTop, legsCount, tableLeg)
        {
            this.TableAccessories = TableAccessories;
        }
    }
}
