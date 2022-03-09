using Facility.Interfaces;
using Facility.TableDetails;

namespace Facility.Tables
{
    public class RectangularChipboardTable : ITable <RectangularTableTop, ChipboardRectangleLeg>
    {
        public string Name { get; set; }
        public List<ChipboardRectangleLeg> TableLegs { get; }
        public RectangularTableTop TableTop { get; }
        public double Price { get; }
        public int LegsCount { get; }
        public RectangularChipboardTable(string name, RectangularTableTop top, int countOfLegs ,ChipboardRectangleLeg leg)
        {
            Name = name;
            LegsCount = countOfLegs;
            TableLegs = new List<ChipboardRectangleLeg>();
            double priceForLegs = 0;
            for(int i = 0; i < countOfLegs; i++)
            {
                TableLegs.Add(leg);
                priceForLegs += leg.Price;
            }

            TableTop = top;
            Price = top.Price + priceForLegs;
        }

        public double GetChipboardConsumption()
        {
            double consumption = TableTop.Height * TableTop.Square;

            foreach (var leg in TableLegs)
                consumption += leg.Height * leg.Square;
            
            return consumption;
        }

        public override int GetHashCode() => Name.GetHashCode() + TableLegs.GetHashCode() + TableTop.GetHashCode() + Price.GetHashCode() + LegsCount.GetHashCode();
        public override bool Equals(object obj)
        {
            if (obj == null || obj is not RectangularChipboardTable)
                return false;
            else
            {
                RectangularChipboardTable newObj = obj as RectangularChipboardTable;

                return Name == newObj.Name && TableLegs == newObj.TableLegs && TableTop == newObj.TableTop &&
                        Price == newObj.Price && LegsCount == newObj.LegsCount;
            }
        }
        public override string ToString()
        {
            return $"Rectangular table with rectangular legs. Name = {Name}";
        }
    }
}
