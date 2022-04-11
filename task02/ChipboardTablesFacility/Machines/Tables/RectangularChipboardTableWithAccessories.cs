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
        public override bool Equals(object obj)
        {
            if (obj == null || obj is not RectangularChipboardTableWithAccessories)
                return false;
            else
            {
                RectangularChipboardTableWithAccessories newObj = obj as RectangularChipboardTableWithAccessories;

                bool isEqual = true;
                foreach (KeyValuePair<TableAccessoriesType, int> item in TableAccessories)
                {
                    if (newObj.TableAccessories.ContainsKey(item.Key))
                    {
                        if (item.Value != newObj.TableAccessories[item.Key])
                        {
                            isEqual = false;
                            break;
                        }
                    }
                    else
                    {
                        isEqual = false;
                        break;
                    }
                }

                return Name == newObj.Name && TableLeg.Equals(newObj.TableLeg) && TableTop.Equals(newObj.TableTop) &&
                        Price == newObj.Price && LegsCount == newObj.LegsCount && isEqual;
            }
        }
    }
}
