using Facility.Interfaces;
using Facility.TableDetails;

namespace Facility.Tables
{
    public class RectangularChipboardTable : ITable<RectangularTableTop, RectangleChipboardLeg>
    {
        public string Name { get; set; }
        public RectangleChipboardLeg TableLeg { get; }
        public RectangularTableTop TableTop { get; }
        public double Price { get; }
        public int LegsCount { get; }
        public RectangularChipboardTable(string name, RectangularTableTop top, int countOfLegs, RectangleChipboardLeg leg)
        {
            Name = name;
            LegsCount = countOfLegs;
            TableLeg = leg;
            TableTop = top;
            Price = top.Price + LegsCount * leg.Price;
        }

        public double GetChipboardConsumption()
        {
            return TableTop.Square * TableTop.Height + LegsCount * TableLeg.Height * TableLeg.Square;
        }

        public override int GetHashCode() => Name.GetHashCode() + TableLeg.GetHashCode() + TableTop.GetHashCode() + Price.GetHashCode() + LegsCount.GetHashCode();
        public override bool Equals(object obj)
        {
            if (obj == null || obj is not RectangularChipboardTable)
                return false;
            else
            {
                RectangularChipboardTable newObj = obj as RectangularChipboardTable;

                return Name == newObj.Name && TableLeg == newObj.TableLeg && TableTop == newObj.TableTop &&
                        Price == newObj.Price && LegsCount == newObj.LegsCount;
            }
        }
        public override string ToString()
        {
            return $"Rectangular table with rectangular legs. Name = {Name}";
        }
    }
}
